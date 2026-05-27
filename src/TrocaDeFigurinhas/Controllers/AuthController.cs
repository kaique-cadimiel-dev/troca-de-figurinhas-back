using Microsoft.AspNetCore.Mvc;
using TrocaDeFigurinhas.Interfaces;
using TrocaDeFigurinhas.Models;

namespace TrocaDeFigurinhas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public AuthController(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromBody] LoginRequest request)
    {
        var user = await _userService.GetUserByEmailAsync(request.Email);
        
        if (user == null || !_authService.VerifyPassword(request.Password, user.Password))
        {
            return Unauthorized("E-mail ou senha inválidos.");
        }

        var token = _authService.GenerateToken(user);
        
        return Ok(new { token, user = new { user.Id, user.Name, user.Email } });
    }
}

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
