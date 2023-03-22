using ProyectoCurso.BackEnd.Data.Repositories;
using ProyectoCurso.BackEnd.Model.Entity;
using ProyectoCurso.BackEnd.Services.PerfilPersonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCurso.BackEnd.ServicesDependencies.Services.PerfilPersonal
{
    public class GetPerfilPersonalDependencies : IGetPerfilPersonalDependencies
    {
        private readonly PerfilPersonalRepository _perfilPersonalRepository;
        public GetPerfilPersonalDependencies(PerfilPersonalRepository perfilPersonalRepository)
        {
            _perfilPersonalRepository= perfilPersonalRepository;
        }
        public Task<PerfilPersonalEntity?> GetPersonalProfile(int userId)
        {
            return  _perfilPersonalRepository.GetByUserId(userId);
        }
    }
}
