namespace ParfumBD.API.Models
{
    public class LogAdmin
    {
        public int IdLog { get; set; }
        public int IdAdmin { get; set; }
        public string? Accion { get; set; }
        public DateTime Fecha { get; set; }
        public string? EntidadAfectada { get; set; }

        // Navigation properties
        public virtual Usuario? Admin { get; set; }
    }
}
