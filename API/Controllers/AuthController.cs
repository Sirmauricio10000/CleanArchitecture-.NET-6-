using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Authentication;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtServices _jwtServices;

    public AuthController(IJwtServices jwtServices)
    {
        _jwtServices = jwtServices;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User user)
    {
        if (user.UserName == "nombreusuario" && user.Password == "contraseña")
        {
            var token = await _jwtServices.GenerateToken(user);
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }

}
