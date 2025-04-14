namespace ParfumBD.API.Models
{
    public class DetallePedido
    {
        public int IdDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdPerfume { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        // Navigation properties
        public virtual Pedido? Pedido { get; set; }
        public virtual Perfume? Perfume { get; set; }
    }
}
