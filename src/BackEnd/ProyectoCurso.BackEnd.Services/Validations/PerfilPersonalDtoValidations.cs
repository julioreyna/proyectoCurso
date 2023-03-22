using ProyectoCurso.Shared.DTO;
using ProyectoCurso.Shared.ROP;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCurso.BackEnd.Services.Validations
{
    public static class PerfilPersonalDtoValidations
    {
        public static Result<PerfilPersonalDto> ValidateDto(this PerfilPersonalDto perfilpersonal)
        {
            return ValidatePerfil(perfilpersonal);
        }
        
        public static Result<PerfilPersonalDto> ValidatePerfil(this PerfilPersonalDto perfilpersonal)
        {
            List<Error> errors = new List<Error>();
            if (perfilpersonal.apellido.Trim().Length == 0)
            {
                errors.Add(Error.Create("El campo Apellido no puede estar vacío"));
            }
            if(perfilpersonal.descripcion.Trim().Length > 200) 
            {
                errors.Add(Error.Create("El campo descripcion no puede superar los 200 caracteres"));
            }
            if (perfilpersonal.nombre.Trim().Length > 50)
            {
                errors.Add(Error.Create("El campo nombre no puede superar los 50 caracteres"));
            }
            if (perfilpersonal.apellido.Trim().Length > 50)
            {
                errors.Add(Error.Create("El campo apellido no puede superar los 50 caracteres"));
            }


            return errors.Any() ?
                Result.Failure<PerfilPersonalDto>(errors.ToImmutableArray()) :
                perfilpersonal;

        }

    }
    
}
