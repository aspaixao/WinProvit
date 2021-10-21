using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinProvit.AuthServices;
using WinProvit.Core.Interfaces;
using WinProvit.Entities;

namespace WinProvit.Api.Identity.Controllers
{
    [Route("api/identity/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController(IAuthServices authService)
        {
            AuthService = authService;
        }

        public IAuthServices AuthService { get; }

        [HttpPost]
        [AllowAnonymous]
        public async Task<dynamic> LoginAsync(LoginInput login)
        {
            var loginResult = await AuthService.AuthAsync(login);

            if(loginResult != null)
            {
                var token = TokenServices.GenerateToken(loginResult);
                loginResult.Token = token;

                return Ok(loginResult);
            }
            else
            {
                return NotFound(new { message = "User not found"});
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<dynamic> RegisterAsync(UserInput user)
        {
            var result = await AuthService.Register(user);
            if (result != null)
            {
                return Ok(result);
            }
            
            return Ok(new { message = "Can't use this username" });
        }

        [HttpGet]
        [Authorize]
        public async Task<dynamic> ValidateAsync()
        {
            return Ok(new { message = $"Token validated with user {User.Identity.Name}" });
        }

    }
}
