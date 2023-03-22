using Microsoft.AspNetCore.DataProtection;
using ProyectoCurso.BackEnd.Model.Entity;
using ProyectoCurso.Shared.DTO;


namespace ProyectoCurso.BackEnd.Services.Mappers;

public static class PerfilPersonalDtoMapper
{
    public static PostPerfilPersonalWrapper MapToWrapperEntities(this PerfilPersonalDto perfilDto, IDataProtector protector)
    {
        if(perfilDto.userid == null)
        {
            throw new Exception("Está intentando crear una entidad con el userId nulo, y eso no es admitido por el sistema");
        }
        string encriptedEmail = protector.Protect(perfilDto.email);
        string encriptedPhone = protector.Protect(perfilDto.telefono);

        PerfilPersonalEntity perfilPersonal = 
                        PerfilPersonalEntity.Create((int)perfilDto.idperfilpersonal, perfilDto.userid,
                        encriptedEmail, encriptedPhone, perfilDto.nombre, perfilDto.apellido, 
                        perfilDto.descripcion);

        return new PostPerfilPersonalWrapper(perfilPersonal);
    }

}

public class PostPerfilPersonalWrapper
{
    public readonly PerfilPersonalEntity perfilPersonal;

    public PostPerfilPersonalWrapper(PerfilPersonalEntity perfilPersonal)
    {
        this.perfilPersonal = perfilPersonal;
    }
}