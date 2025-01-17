using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService _userService;

    public AuthController(IUsersService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (registerRequest == null)
        {
            return BadRequest("Invalid registration data");
        }

        AuthResponse? response = await _userService.Register(registerRequest);

        if (response == null || response.Success == false)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(Loginrequest loginrequest)
    {
        if (loginrequest == null)
        {
            return BadRequest("Invalid login data");
        }

        AuthResponse? response = await _userService.Login(loginrequest);

        if(response == null || response.Success == false)
        {
            return Unauthorized(response);
        }

        return Ok(response);
    }
}
