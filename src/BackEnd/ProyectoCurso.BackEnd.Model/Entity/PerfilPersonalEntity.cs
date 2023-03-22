namespace ProyectoCurso.BackEnd.Model.Entity
{
    public class PerfilPersonalEntity
    {
        public int? id { get; set; }
        public string? email { get; set; }
        public string? telefono { get; set; }
        public int userid { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string? descripcion { get; set; }

        public PerfilPersonalEntity()
        {

        }
        public PerfilPersonalEntity(int? id, int userid, string? email, string? telefono, string nombre, string apellido, string? descripcion)
        {
            this.id = id;
            this.email = email;
            this.telefono = telefono;
            this.userid = userid;
            this.nombre = nombre;
            this.apellido = apellido;
            this.descripcion = descripcion;
            
        }

        public static PerfilPersonalEntity Create(int? id, int userid, string? email, string? telefono,
            string nombre, string apellido, string? descripcion)
            => new PerfilPersonalEntity(id, userid, email, telefono, nombre, apellido, descripcion);
        public static PerfilPersonalEntity Update(PerfilPersonalEntity perfilPersonal, int id) =>
            new PerfilPersonalEntity(id, perfilPersonal.userid, perfilPersonal.email, perfilPersonal.telefono,
                    perfilPersonal.nombre, perfilPersonal.apellido, perfilPersonal.descripcion);

    }
}
