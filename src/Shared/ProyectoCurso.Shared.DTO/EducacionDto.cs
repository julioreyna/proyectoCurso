namespace ProyectoCurso.Shared.DTO
{
    public class EducacionDto
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public string NombreCarrera { get; set; }
        public string Universidad { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }


    }
}
