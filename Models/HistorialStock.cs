namespace ParfumBD.API.Models
{
    public class HistorialStock
    {
        public int IdHistorial { get; set; }
        public int IdPerfume { get; set; }
        public int CambioStock { get; set; }
        public string? Motivo { get; set; }
        public DateTime Fecha { get; set; }

        // Navigation properties
        public virtual Perfume? Perfume { get; set; }
    }
}
