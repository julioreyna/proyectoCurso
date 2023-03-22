using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using ProyectoCurso.BackEnd.Model.Entity;
using ProyectoCurso.Shared.DTO;
using ProyectoCurso.Shared.ROP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCurso.BackEnd.Services.PerfilPersonal;

public interface IGetPerfilPersonalDependencies
{
    Task<PerfilPersonalEntity?> GetPersonalProfile(int userId);
}

public class GetPerfilPersonal
{
    private readonly IGetPerfilPersonalDependencies _dependencies;
    private readonly IDataProtector _protector;
    public GetPerfilPersonal(IGetPerfilPersonalDependencies dependencies, IDataProtectionProvider provider , IHttpContextAccessor httpContextAccesor     )
    {
        _dependencies = dependencies;
        _protector = provider.CreateProtector("GetPerfilPersonal.Protector");
    }

    public async Task<Result<PerfilPersonalDto>> GetPerfilPersonalDto(int username)
    {
        Result<PerfilPersonalEntity> id = await GetProfile(username);

        return await id.Async()
            .MapAsync(x => Map(x));
            
    }
    private async Task<Result<PerfilPersonalEntity>> GetProfile(int userid) 
    {
        var perfilPersonal = await _dependencies.GetPersonalProfile(userid);

        return perfilPersonal == null ?
                Result.Failure<PerfilPersonalEntity>(Error.Create("No se ha encontrado el perfil")) 
                : perfilPersonal;

    }
    private Task<PerfilPersonalDto> Map(PerfilPersonalEntity values ) 
    {
        PerfilPersonalDto perfil = new PerfilPersonalDto()
        {
            descripcion = values.Descripcion,
            idperfilpersonal= values.Idperfilpersonal,
            userid = values.Userid,
            apellido = values.Apellido,
            nombre= values.Nombre,
            email= values.Email,
            telefono= values.Telefono
        };
        return Task.FromResult( perfil );
    }
}
