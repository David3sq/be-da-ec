using Electro.AuthJWT.Dto;
using Electro.AuthJWT.Services;
using Electro.Domain.Entities;
using Electro.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Electro.AuthJWT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService auth;

        public AuthController(AuthService auth)
        {
            this.auth = auth;
        }

        [HttpPost("register")]
        [EndpointDescription("User Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UtentiDto utenti)
        {
            var response = await auth.Register(
                new Utente { Username = utenti.Username }, utenti.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpPost("login")]
        [EndpointDescription("User Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UtentiDto utenti)
        {
            var response = await auth.Login(utenti.Username, utenti.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("Delete Account")]
        [EndpointDescription("Delete Account")]
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteAccount(UtentiDto utenti)
        {
            var response = await auth.DeleteAccount(utenti.Username, utenti.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Change Password")]
        [EndpointDescription("Change Password")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<string>>> ChangePassword(UtentiDto utenti)
        {
            var response = await auth.ChangePassword(utenti.Username, utenti.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Enable User")]
        [EndpointDescription("Enable User")]
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult<ServiceResponse<bool>>> EnableUser(UtentiDto utenti)
        {
            var response = await auth.EnableUser(utenti.Username);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Disable User")]
        [EndpointDescription("Disable User")]
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult<ServiceResponse<bool>>> DisableUser(UtentiDto utenti)
        {
            var response = await auth.DisableUser(utenti.Username);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
