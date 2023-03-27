using ProyectoCurso.BackEnd.Data.Repositories;
using ProyectoCurso.BackEnd.Model.Entity;
using ProyectoCurso.BackEnd.Services.PerfilPersonal;
using ProyectoCurso.Shared.ROP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCurso.BackEnd.ServicesDependencies.Services.PerfilPersonal
{
    public class PostPerfilPersonalDependencies : IPostPerfilPersonalDependencies
    {
        private readonly PerfilPersonalRepository _perfilPersonalRepository;
        public PostPerfilPersonalDependencies(PerfilPersonalRepository perfilPersonalRepository)
        {
            _perfilPersonalRepository = perfilPersonalRepository;
        }
        public async Task CommitTransaction()
        {
            await _perfilPersonalRepository.CommitTransaction();
        }

        public async Task<Result<PerfilPersonalEntity>> InsertPerfilPersonal(PerfilPersonalEntity perfilPersonal)
        {
            return await _perfilPersonalRepository.InsertSingle(perfilPersonal);
        }
    }
}
