namespace ParfumBD.API.Models
{
    public class DetalleCarrito
    {
        public int IdDetalle { get; set; }
        public int IdCarrito { get; set; }
        public int IdPerfume { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        // Navigation properties
        public virtual Carrito? Carrito { get; set; }
        public virtual Perfume? Perfume { get; set; }
    }
}
