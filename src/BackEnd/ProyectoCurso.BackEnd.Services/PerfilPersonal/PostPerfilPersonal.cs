using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using ProyectoCurso.BackEnd.Model.Entity;
using ProyectoCurso.BackEnd.Services.Mappers;
using ProyectoCurso.Shared.DTO;
using ProyectoCurso.Shared.ROP;

namespace ProyectoCurso.BackEnd.Services.PerfilPersonal;

public interface IPostPerfilPersonalDependencies
{
    Task<Result<PerfilPersonalEntity>> InsertPerfilPersonal(PerfilPersonalEntity perfilPersonal);
    Task CommitTransaction();
}
public class PostPerfilPersonal
    {
    private readonly IDataProtector _provider;
    private readonly IPostPerfilPersonalDependencies _dependencies;
    public PostPerfilPersonal(IPostPerfilPersonalDependencies dependencies, IDataProtectionProvider provider)
    {
        _dependencies= dependencies;
        _provider = provider.CreateProtector("PostPerfilPersonal.Protector"); ;
    }
    public async Task<Result<PerfilPersonalEntity>> Create(PerfilPersonalDto perfilPersonal)
    {
        return await SaveNewPerfilPersonal(perfilPersonal);
    }

    private Task<Result<PerfilPersonalEntity>> SaveNewPerfilPersonal(PerfilPersonalDto perfilPersonal)
    {
        return _dependencies.InsertPerfilPersonal(perfilPersonal.Map(perfilPersonal.userid, _provider)).
             Bind(CommitTransaction);

             
    }

    private PerfilPersonalEntity Map(PerfilPersonalDto perfilPersonal)
    {
        
         PerfilPersonalEntity perfil = new PerfilPersonalEntity
        {
            apellido= perfilPersonal.apellido,
            descripcion = perfilPersonal.descripcion,
            email= perfilPersonal.email,
            id = perfilPersonal.idperfilpersonal,
            nombre= perfilPersonal.nombre,
            telefono= perfilPersonal.telefono,
            userid = perfilPersonal.userid
        };
        return  perfil;
    }
    private async Task<Result<PerfilPersonalEntity>> CommitTransaction(PerfilPersonalEntity perfilPersonalEntity)
    {
        await _dependencies.CommitTransaction();
        return perfilPersonalEntity;
    }
}
