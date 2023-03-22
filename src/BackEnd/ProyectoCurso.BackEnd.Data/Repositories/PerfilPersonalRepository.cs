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
                            {nameof(PerfilPersonalEntity.userid)}, {nameof(PerfilPersonalEntity.email)},
                            {nameof(PerfilPersonalEntity.nombre)}, {nameof(PerfilPersonalEntity.apellido)},
                            {nameof(PerfilPersonalEntity.descripcion)}) 
                        values (@{nameof(PerfilPersonalEntity.userid)}, @{nameof(PerfilPersonalEntity.email)},
                            @{nameof(PerfilPersonalEntity.nombre)}, @{nameof(PerfilPersonalEntity.apellido)},
                            @{nameof(PerfilPersonalEntity.descripcion)}); 
                        Select LAST_INSERT_ID();";
            using (DbConnection connection = await _conexionWrapper.GetConnectionAsync())
            {
                var newId = (await connection.QueryAsync<int>(sql, new
                {
                    Userid = obj.userid,
                    Email = obj.email,
                    Nombre = obj.nombre,
                    Apellido = obj.apellido,
                    Descripcion = obj.descripcion
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
