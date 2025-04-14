namespace ParfumBD.API.Models
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? Estado { get; set; }

        // Navigation properties
        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<DetalleCarrito>? DetallesCarrito { get; set; }
    }
}
