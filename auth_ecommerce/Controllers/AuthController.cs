using ASI_Model.Models;
using common.AuthJWT.Dto;
using common.AuthJWT.Services;
using common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace common.AuthJWT.Controllers
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
                new Utenti { Username = utenti.Username }, utenti.Password
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
    }
}
