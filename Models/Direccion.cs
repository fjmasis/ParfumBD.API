namespace ParfumBD.API.Models
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public int IdUsuario { get; set; }
        public string? Provincia { get; set; }
        public string? Canton { get; set; }
        public string? DireccionExacta { get; set; }

        // Navigation properties
        public virtual Usuario? Usuario { get; set; }
    }
}
