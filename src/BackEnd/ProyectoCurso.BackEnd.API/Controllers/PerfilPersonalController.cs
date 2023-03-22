using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoCurso.BackEnd.Services.PerfilPersonal;
using ProyectoCurso.Shared.DTO;
using ProyectoCurso.Shared.ROP;

namespace ProyectoCurso.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PerfilPersonalController : ControllerBase
    {
        private readonly GetPerfilPersonal _getPerfilPersonal;
        public PerfilPersonalController(GetPerfilPersonal getPerfilPersonal)
        {
            _getPerfilPersonal = getPerfilPersonal;

        }
        [HttpGet("userId")]
        public async Task<ResultDto<PerfilPersonalDto>> Get(string userId)
        {
            var a = await GetPerfilPersonal(int.Parse(userId));
            return a.MapDto(x => x);
        }

        private async Task<Result<PerfilPersonalDto>> GetPerfilPersonal(int userid)
        {
            return await _getPerfilPersonal.GetPerfilPersonalDto(userid);
        }

    }
}
