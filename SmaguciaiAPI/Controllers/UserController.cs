using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.User;

namespace SmaguciaiAPI.Controllers;

public class UserController : BaseController
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;
    
    public UserController(IAuthService authService, IUserService userService, IJwtService jwtService)
    {
        _authService = authService;
        _userService = userService;
        _jwtService = jwtService;
    }

    [HttpPost]
    public IActionResult Login(LoginRequest request)
    {
        var user = _authService.Login(request);
        var jwt = _jwtService.BuildJwt(user);

        return Ok(jwt);
    }

    [HttpPost]
    public IActionResult Register(RegisterRequest request)
    {
        var response = _authService.Register(request);
        return Ok(response);
    }
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult GetMe()
    {
        var user = _userService.GetById(Guid.Parse(User.FindFirstValue(ClaimTypes.Sid)));
        return Ok(user);
    }
    [HttpPut("{id:guid}")]
    public IActionResult EditUser(Guid id, UserEditRequest request)
    {
        var res = _userService.EditUser(id,request);
        return Ok(res);
    }
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteUser(Guid id)
    {
        return Ok(_userService.DeleteUser(id));
    }
    [HttpPut("{id:guid}")]
    public IActionResult EditPassword(Guid id, PasswordEditRequest request)
    {
        var res = _userService.EditPassword(id,request);
        return Ok(res);
    }
}