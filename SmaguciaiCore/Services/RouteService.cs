using System.Globalization;
using AutoMapper;
using Newtonsoft.Json.Linq;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Responses.Order;
using SmaguciaiCore.Responses.User;
using SmaguciaiDomain.Entities;
namespace SmaguciaiCore.Services;

public class RouteService : IRouteService
{
    public static List<Distance> Distances = new List<Distance>();
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRouteRepository _routeRepository;
    private readonly IMapper _mapper;

    public RouteService(IOrderRepository orderRepository, IUserRepository userRepository, IRouteRepository routeRepository, IMapper mapper)
    {
	    _orderRepository = orderRepository;
	    _userRepository = userRepository;
	    _routeRepository = routeRepository;
	    _mapper = mapper;
    }

    public async Task GenerateRoute()
    {
        Console.WriteLine("Starting work.");
        int maxTime = 28800;

        List<Order> orders = _orderRepository.GetAllPaidOrdersWithUsers().ToList();
        List<Location> locations = await GenerateLocations(orders);
        List<Location> removedLocations = new List<Location>();
        Generation bestGen = new Generation();
        List<Distance> orderedDistances = await OrderLocationsFromWarehouse(locations);
        int removedLocationsCount = 0;

        double bestTime = double.MaxValue;
        while(bestTime > maxTime)
        {
	        bestGen = await DoTask(locations);
            bestTime = bestGen.Time;
            if(bestTime > maxTime)
            {
                double timeOver = bestTime - maxTime;
                double timeGot = 0;
                while (timeOver > timeGot)
                {
                    timeGot += orderedDistances[removedLocationsCount].Time;
                    removedLocations.Add(orderedDistances[removedLocationsCount].To);
                    locations.Remove(orderedDistances[removedLocationsCount].To);
                    removedLocationsCount++;
                }

            }
        }

        var id  = _routeRepository.CreateNewRoute(new Route
        {
	        TimeInSeconds = (int)bestGen.Time
        });
        for (int i = 1; i < bestGen.Locations.Count - 1; i++)
        {
	        _orderRepository.UpdateRoute(bestGen.Locations[i].OrderId, id, i);
        }
        Console.WriteLine("Finished work.");
    }

    public IEnumerable<Tuple<UserResponse, OrderResponse>> GetRoute()
    {
	    throw new Exception("dfdfdfdfdfdf");
    }

    public static double exists(Distance distance)
    {
	    for(int i = 0; i < Distances.Count; i++)
	    {
		    if(distance.From == Distances[i].From && distance.To == Distances[i].To)return Distances[i].Time;
	    }
	    return -1;
    }
    public static async Task<List<Distance>> OrderLocationsFromWarehouse(List<Location> locations)
	{
		List<Distance> distances = new List<Distance>();
		for(int i = 1; i < locations.Count - 1; i++)
		{
			Distance distance = new Distance(locations[0], locations[i]);
			double exist = exists(distance);
			if (exist == -1)
			{
				await distance.CalcTime();
				Distances.Add(distance);
			}
			else
			{
				distance.Time = exist;
			}
			distances.Add(distance);
		}
		distances = distances.OrderByDescending(g => g.Time).ToList();
		
		return distances;
	}

	public static async Task<Generation> DoTask(List<Location> locations)
	{
		Random random = new Random();

		List<Generation> generations = GenerateInitialPopulation(locations);

		foreach (var generation in generations)
		{
			double totalTravelTime = 0;

			// Calculate total travel time for each route within the generation
			for (int i = 0; i < generation.Locations.Count - 1; i++)
			{
				Location currentLocation = generation.Locations[i];
				Location nextLocation = generation.Locations[i + 1];
				Distance distance = new Distance(currentLocation, nextLocation);
				double exist = exists(distance);
				if (exist == -1)
				{
					await distance.CalcTime();
					Distances.Add(distance);
				}
				else
				{
					distance.Time = exist;
				}
				totalTravelTime += distance.Time;
			}

			// Assign total travel time to the generation
			generation.Time = totalTravelTime;

			Console.WriteLine($"Total travel time for generation: {totalTravelTime} seconds");
		}

		//List<Generation> nextGeneration = new List<Generation>();

		int loopDuration = 1800;
		DateTime startTime = DateTime.Now;
		int counter = 2;
		int SameBestCounter = 0;
		Generation BestLast = generations[0];
		while ((DateTime.Now - startTime).TotalSeconds < loopDuration && SameBestCounter < generations.Count)
		{
			await Console.Out.WriteLineAsync("Generating " + counter + " population for " + locations.Count + " location amount");
			generations = await GenerateNextPopulation(generations, locations);
			if (generations[0] == BestLast) SameBestCounter++;
			else
			{
				BestLast = generations[0];
				SameBestCounter = 0;
			}
			counter++;
		}
		for (int i = 0; i < generations.Count; i++)
		{
			await Console.Out.WriteLineAsync(i + " generacijos laikas: " + generations[i].Time);
		}

		await Console.Out.WriteLineAsync("Geriausias rastas kelias: ");
		foreach (var location in generations[0].Locations)
		{
			await Console.Out.WriteLineAsync("X: " + location.X + ", Y: " + location.Y + ", OrderID: " + location.OrderId.ToString());
		}

		await Console.Out.WriteLineAsync("");

		return generations[0];
	}

	public static async Task<List<Generation>> GenerateNextPopulation(List<Generation> generations, List<Location> locations)
	{
		Random random = new Random();
		int populationSize = generations.Count;
		int bestRoutesCount = (int)(populationSize * 0.2);
		int randomRoutesCount = (int)(populationSize * 0.1);
		int mutationRoutesCount = (int)(populationSize * 0.4);
		int crossoverRoutesCount = (int)(populationSize * 0.3);
		int sum = bestRoutesCount + randomRoutesCount + mutationRoutesCount + crossoverRoutesCount;

		if (populationSize != sum)
		{
			randomRoutesCount += populationSize - sum;
		}
		// Sort generations by time (assuming lower time is better)
		generations = generations.OrderBy(g => g.Time).ToList();

		// Keep the best routes
		List<Generation> nextGeneration = generations.Take(bestRoutesCount).ToList();

		// Add random generations
		for (int i = 0; i < randomRoutesCount; i++)
		{
			nextGeneration.Add(new Generation(Shuffle(locations), 0));
		}

		// Mutate routes
		for (int i = 0; i < mutationRoutesCount; i++)
		{
			int index = random.Next(bestRoutesCount, populationSize);
			Mutate(generations[index]);
			nextGeneration.Add(generations[index]);
		}

		// Crossover routes
		for (int i = 0; i < crossoverRoutesCount; i++)
		{
			int index1 = random.Next(bestRoutesCount, populationSize);
			int index2 = random.Next(bestRoutesCount, populationSize);
			Generation child = Crossover(generations[index1], generations[index2]);
			nextGeneration.Add(child);
		}

		foreach (var generation in nextGeneration)
		{
			double totalTravelTime = 0;

			if (generation.Time < 1)
			{
				// Calculate total travel time for each route within the generation
				for (int i = 0; i < generation.Locations.Count - 1; i++)
				{
					Location currentLocation = generation.Locations[i];
					Location nextLocation = generation.Locations[i + 1];
					Distance distance = new Distance(currentLocation, nextLocation);
					double exist = exists(distance);
					if (exist == -1)
					{
						await distance.CalcTime();
						Distances.Add(distance);
					}
					else
					{
						distance.Time = exist;
					}
					totalTravelTime += distance.Time;
				}

				// Assign total travel time to the generation
				generation.Time = totalTravelTime;
			}
			else
			{
				totalTravelTime = generation.Time;
			}
			//Console.WriteLine($"Total travel time for generation: {totalTravelTime} seconds");
		}

		nextGeneration = nextGeneration.OrderBy(g => g.Time).ToList();

		return nextGeneration;
	}

	public static async void CalcTimes(List<Generation> generations)
	{
		// Iterate over generations
		foreach (var generation in generations)
		{
			double totalTravelTime = 0;

			// Calculate total travel time for each route within the generation
			for (int i = 0; i < generation.Locations.Count - 1; i++)
			{
				Location currentLocation = generation.Locations[i];
				Location nextLocation = generation.Locations[i + 1];
				Distance distance = new Distance(currentLocation, nextLocation);
				await distance.CalcTime();
				totalTravelTime += distance.Time;
			}

			// Assign total travel time to the generation
			generation.Time = totalTravelTime;

			Console.WriteLine($"Total travel time for generation: {totalTravelTime} seconds");
		}
	}

	public static void Mutate(Generation generation)
	{
		Random random = new Random();

		// Randomly select two distinct indices within the range of the location list
		int index1 = random.Next(1, generation.Locations.Count-1);
		int index2;
		do
		{
			index2 = random.Next(1, generation.Locations.Count - 1);
		} while (index2 == index1 || index1 == generation.Locations.Count - 1 || index2 == 0 || index2 == generation.Locations.Count - 1);

		// Swap the locations at the selected indices
		Swap(generation.Locations, index1, index2);
	}

	private static void Swap<T>(List<T> list, int index1, int index2)
	{
		T temp = list[index1];
		list[index1] = list[index2];
		list[index2] = temp;
	}


	public static Generation Crossover(Generation parent1, Generation parent2)
	{
		Random random = new Random();
		int crossoverPoint = random.Next(1, parent1.Locations.Count - 1);

		List<Location> childLocations = new List<Location>();

		// Add locations from parent1 up to the crossover point
		for (int i = 0; i < crossoverPoint; i++)
		{
			childLocations.Add(parent1.Locations[i]);
		}

		// Add remaining locations from parent2
		for (int i = 0; i < parent2.Locations.Count; i++)
		{
			if (!childLocations.Contains(parent2.Locations[i]))
			{
				childLocations.Add(parent2.Locations[i]);
			}
		}

		return new Generation(childLocations, 0);
	}


	public static List<Generation> GenerateInitialPopulation(List<Location> locations)
	{
		List<Generation> locationsList = new List<Generation>();

		for (int i = 0; i < locations.Count*5; i++)
		{
			locationsList.Add(new Generation(Shuffle(locations), 0));
		}

		return locationsList;
	}

	static List<T> Shuffle<T>(List<T> list)
	{
		Random random = new Random();
		List<T> shuffledList = new List<T>(list); // Create a new instance of the list

		int n = shuffledList.Count;
		if (n > 2)
		{
			for (int i = n - 2; i > 1; i--)
			{
				int k = random.Next(1, i + 1);
				T value = shuffledList[k];
				shuffledList[k] = shuffledList[i];
				shuffledList[i] = value;
			}
		}
		return shuffledList;
	}
	public static async Task<List<Location>> GenerateLocations(List<Order> orders)
	{
		List<Location> locations = new List<Location>();
		locations.Add(await GetCoordinatesAsync("Studentu 50 Kaunas Kaunas Lietuva", new Guid()));
		foreach (Order order in orders)
		{
			string address1 = order.User.Street + " " + order.User.HouseNumber + " " + order.User.City + " " + order.User.District + " " + order.User.Country;

			try
			{
				locations.Add(await GetCoordinatesAsync(address1, order.Id));
			}
			catch
			{
				return locations;
			}
		}
		locations.Add(await GetCoordinatesAsync("Studentu 50 Kaunas Kaunas Lietuva", new Guid()));
		return locations;
	}
	public static async Task<double> GetTravelTimeAsync(double startLat, double startLon, double endLat, double endLon)
	{
		//string apiKey = "2n6LEOyrYk7lpKesDS0ANEnXfwoTADHd";
		//string apiKey = "fZoGWnAcckXfGAz9XdzsBMrwtIl83zZ6";
		//string apiKey = "CG7t7ztAWr6Gqnt2uxhoGj5Fc0Gza1OO";
		//string apiKey = "l1rQxNSzOXkpjd8AdsVxKGRK4kImfQLB";
		//string apiKey = "ghdNrk12dxLgFuZ0oTTBEyiRVra4GxrZ";
		//string apiKey = "II0iWvWRamVw9iFaHBkecIoKqqua9FJt";
		//string apiKey = "CI8mGOQ8o6ZtxtVqNSmPZN2FYPxdAkGf";
		string apiKey = "xqxsCZhji0r4iXx5QOa5447D6pdfYAEm";
		//string apiKey = "pjYCAE4EEAu79G5LmtOLbbF2WvREf4Yg";
		string versionNumber = "1";
		string contentType = "json";
		string startCoordinates = $"{startLat.ToString(CultureInfo.InvariantCulture)},{startLon.ToString(CultureInfo.InvariantCulture)}";
		string endCoordinates = $"{endLat.ToString(CultureInfo.InvariantCulture)},{endLon.ToString(CultureInfo.InvariantCulture)}";
		string url = $"https://api.tomtom.com/routing/{versionNumber}/calculateRoute/{startCoordinates}:{endCoordinates}/{contentType}?key={apiKey}";

		using (HttpClient client = new HttpClient())
		{
			HttpResponseMessage response = await client.GetAsync(url);
			string responseBody = await response.Content.ReadAsStringAsync();

			if (!response.IsSuccessStatusCode)
			{
				Console.WriteLine($"Error: {responseBody}");
				response.EnsureSuccessStatusCode();
			}

			JObject json = JObject.Parse(responseBody);
			var routes = json["routes"];
			if (routes != null && routes.HasValues)
			{
				var summary = routes[0]["summary"];
				double travelTimeInSeconds = (double)summary["travelTimeInSeconds"];
				return travelTimeInSeconds;
			}
			else
			{
				throw new Exception("No routes found.");
			}
		}
	}

	public static async Task<Location> GetCoordinatesAsync(string address, Guid orderId)
	{
		//string apiKey = "2n6LEOyrYk7lpKesDS0ANEnXfwoTADHd";
		//string apiKey = "fZoGWnAcckXfGAz9XdzsBMrwtIl83zZ6";
		//string apiKey = "CG7t7ztAWr6Gqnt2uxhoGj5Fc0Gza1OO";
		//string apiKey = "II0iWvWRamVw9iFaHBkecIoKqqua9FJt";
		//string apiKey = "CI8mGOQ8o6ZtxtVqNSmPZN2FYPxdAkGf";
		string apiKey = "xqxsCZhji0r4iXx5QOa5447D6pdfYAEm";
		//string apiKey = "pjYCAE4EEAu79G5LmtOLbbF2WvREf4Yg";
		string url = $"https://api.tomtom.com/search/2/geocode/{Uri.EscapeDataString(address)}.json?key={apiKey}";
		Location location = new Location(0, 0, orderId);

		using (HttpClient client = new HttpClient())
		{
			HttpResponseMessage response = await client.GetAsync(url);
			string responseBody = await response.Content.ReadAsStringAsync();

			if (!response.IsSuccessStatusCode)
			{
				Console.WriteLine($"Error: {responseBody}");
				response.EnsureSuccessStatusCode();
			}

			JObject json = JObject.Parse(responseBody);
			var results = json["results"];
			if (results != null && results.HasValues)
			{
				var position = results[0]["position"];
				double lat = (double)position["lat"];
				double lon = (double)position["lon"];

				location.X = lat;
				location.Y = lon;
			}
			else
			{
				throw new Exception("No results found.");
			}
		}

		return location;
	}
}

public class Location
{
	public double X { get; set; }
	public double Y { get; set; }
	public Guid OrderId { get; set; }

	public Location(double x, double y, Guid orderId)
	{
		X = x;
		Y = y;
		OrderId = orderId;
	}
}

public class Distance
{
	public Location From { get; set; }
	public Location To { get; set; }
	public double Time { get; set; }

	public Distance(Location from, Location to)
	{
		From = from;
		To = to;
	}


	public async Task<double> CalcTime()
	{
		try
		{
			if (Time == null || Time < 1)
			{
				Time = await RouteService.GetTravelTimeAsync(From.X, From.Y, To.X, To.Y);
			}
			return Time;
		}
		catch
		{
			return Time;
		}
	}
}

public class Generation
{
	public List<Location> Locations;

	public Generation()
	{
	}

	public double Time { get; set; }

	public Generation(List<Location> locations, double time)
	{
		Locations = locations;
		Time = time;
	}
}