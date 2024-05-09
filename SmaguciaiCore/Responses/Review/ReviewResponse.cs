namespace SmaguciaiCore.Responses.Review;

public class ReviewResponse
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime DateAdded { get; set; }
    public bool Reported { get; set; }
    public decimal Rating { get; set; }
}