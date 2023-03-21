namespace ProyectoCurso.BackEnd.Model.Entity
{
    public class PerfilPersonalEntity
    {
        public int? Idperfilpersonal { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int Userid { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Descripcion { get; set; }

        public PerfilPersonalEntity(int? id, int userid, string email, string telefono, string nombre, string apellido, string descripcion)
        {
            Idperfilpersonal = id;
            Email = email;
            Telefono = telefono;
            Userid = userid;
            Nombre = nombre;
            Apellido = apellido;
            Descripcion = descripcion;
        }

        public static PerfilPersonalEntity Create(int? id, int userid, string email, string telefono,
            string nombre, string apellido, string descripcion)
            => new PerfilPersonalEntity(id, userid, email, telefono, nombre, apellido, descripcion);
        public static PerfilPersonalEntity Update(PerfilPersonalEntity perfilPersonal, int id) =>
            new PerfilPersonalEntity(id, perfilPersonal.Userid, perfilPersonal.Email, perfilPersonal.Telefono,
                    perfilPersonal.Nombre, perfilPersonal.Apellido, perfilPersonal.Descripcion);

    }
}
