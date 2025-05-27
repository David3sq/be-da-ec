using ecommerce.auth_ecommerce.Dto;

namespace ecommerce.auth_ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UtentiDto utenti)
        {
            var response = await _auth.Register(
                new Utenti { Username = utenti.Username }, utenti.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UtentiDto utenti)
        {
            var response = await _auth.Login(utenti.Username, utenti.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
