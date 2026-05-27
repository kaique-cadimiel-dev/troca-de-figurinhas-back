using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TrocaDeFigurinhas.Models;

namespace TrocaDeFigurinhas.Interfaces;

public interface IAuthService
{
    string GenerateToken(User user);
    bool VerifyPassword(string password, string hashedPassword);
    string HashPassword(string password);
}
