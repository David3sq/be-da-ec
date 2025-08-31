using ecommerce.auth_ecommerce.Dto;

namespace ecommerce.auth_ecommerce.Controllers
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
    }
}
