using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoCurso.Shared.DTO;
using ProyectoCurso.Shared.ROP;

namespace ProyectoCurso.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PerfilPersonalController : ControllerBase
    {
        [HttpGet("userId")]
        public async Task<ResultDto<PerfilPersonalDto>> Get(string userId)
        {
            return new ResultDto<PerfilPersonalDto>();
        }
    }
}
