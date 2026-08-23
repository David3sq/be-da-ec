using Electro.Core.Dto;
using Electro.Core.Services;
using Electro.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Electro.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GetInfoUser : ControllerBase
    {
        private readonly InfoUserServices info;

        public GetInfoUser(InfoUserServices info)
        {
            this.info = info;
        }

        // Info di un utente qualsiasi: policy "Admin" definita in InfrastructureExtensions.
        [HttpGet("{id:int}")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult<ServiceResponse<UtenteInfoDto?>>> ById(int id)
        {
            var response = await info.GetInfo(id);

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet("GetInfoDisabletUser")]
        [Authorize(Policy = "User")]
        public async Task<ActionResult<ServiceResponse<List<UtenteInfoDto?>>>> GetInfoDisabletUser()
        {
            var response = await info.GetInfoDisabledUser();
            if (!response.Success)
                return NotFound(response);
            return Ok(response);
        }
    }
}
