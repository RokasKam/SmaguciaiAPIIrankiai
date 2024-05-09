using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.User;
using SmaguciaiCore.Responses.User;
using SmaguciaiDomain.Entities;
namespace SmaguciaiCore.Services;

public class UserService : IUserService
{
    private readonly IPasswordEditEmailService _passwordEditEmailService;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private static readonly Encoding HashEncoding = Encoding.UTF8;

    public UserService(IUserRepository userRepository, IMapper mapper, IPasswordEditEmailService passwordEditEmailService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordEditEmailService = passwordEditEmailService;
    }
    public UserResponse GetById(Guid id)
    {
        var user = _userRepository.GetById(id);
        var response = _mapper.Map<UserResponse>(user);
        return response;
    }
    public bool EditUser(Guid id,UserEditRequest request)
    {
        try
        {
            var placeToUpdate = _userRepository.GetById(id);
            if (placeToUpdate is null)
            {
                throw new Exception("Place with provided id does not exist");
            }

            var user = _mapper.Map<User>(request);
            user.Id = id;
            var res = _userRepository.EditUser(user);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteUser(Guid id)
    {
        try
        {
            _userRepository.DeleteUser(id);
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public bool EditPassword(Guid id,PasswordEditRequest request)
    {
        var userToEdit = _userRepository.GetById(id);
        if (userToEdit is null)
        {
            throw new Exception("User with provided id does not exist");
        }
        using var hmac = new HMACSHA512(userToEdit.PasswordSalt);
        var computedHash = hmac.ComputeHash(HashEncoding.GetBytes(request.OldPassword));

        if (!computedHash.SequenceEqual(userToEdit.PasswordHash))
        { 
            throw new Exception("Incorrect user password");
        }
        var password = HashPassword(request.Password);
        userToEdit.PasswordHash = password.PasswordHash;
        userToEdit.PasswordSalt = password.PasswordSalt; 
        var res = _userRepository.EditPassword(userToEdit);
        if (!_passwordEditEmailService.PasswordEditEmail(userToEdit.Email))
        { 
            throw new Exception("Email error");
        }
        return true;
    }
    private HashPasswordResponse HashPassword(string password)
    {
        using var hmac = new HMACSHA512();

        var response = new HashPasswordResponse(
            PasswordSalt: hmac.Key,
            PasswordHash: hmac.ComputeHash(HashEncoding.GetBytes(password))
        );

        return response;
    }

}