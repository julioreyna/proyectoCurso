using Dapper;
using ProyectoCurso.BackEnd.Model.Entity;
using ProyectoCurso.Shared.Data.Db;
using System.Data.Common;

namespace ProyectoCurso.BackEnd.Data.Repositories
{
    public class PerfilPersonalRepository : BaseRepository<PerfilPersonalEntity>
    {
        public PerfilPersonalRepository(TransactionalWrapper conexion) : base(conexion)
        {
        }

        public override string TableName => TablesNames.PerfilPersonal;

        public override async Task<PerfilPersonalEntity> InsertSingle(PerfilPersonalEntity obj)
        {
            string sql = @$"Insert into {TableName} (
                            {nameof(PerfilPersonalEntity.Userid)}, {nameof(PerfilPersonalEntity.Email)},
                            {nameof(PerfilPersonalEntity.Nombre)}, {nameof(PerfilPersonalEntity.Apellido)},
                            {nameof(PerfilPersonalEntity.Descripcion)}) 
                        values (@{nameof(PerfilPersonalEntity.Userid)}, @{nameof(PerfilPersonalEntity.Email)},
                            @{nameof(PerfilPersonalEntity.Nombre)}, @{nameof(PerfilPersonalEntity.Apellido)},
                            @{nameof(PerfilPersonalEntity.Descripcion)}); 
                        Select LAST_INSERT_ID();";
            using (DbConnection connection = await _conexionWrapper.GetConnectionAsync())
            {
                var newId = (await connection.QueryAsync<int>(sql, new
                {
                    Userid = obj.Userid,
                    Email = obj.Email,
                    Nombre = obj.Nombre,
                    Apellido = obj.Apellido,
                    Descripcion = obj.Descripcion
                }
                            ))
                            .First();
                return PerfilPersonalEntity.Update(obj, newId);
            }
        }

        public override Task<PerfilPersonalEntity> UpdateSingle(PerfilPersonalEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
