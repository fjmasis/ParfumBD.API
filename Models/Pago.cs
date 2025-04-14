namespace ParfumBD.API.Models
{
    public class Pago
    {
        public int IdPago { get; set; }
        public int IdPedido { get; set; }
        public DateTime FechaPago { get; set; }
        public string? MetodoPago { get; set; }
        public string? ReferenciaTransaccion { get; set; }

        // Navigation properties
        public virtual Pedido? Pedido { get; set; }
    }
}
