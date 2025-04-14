using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ParfumBD.API.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaPedido { get; set; }
        public decimal Total { get; set; }
        public string? Estado { get; set; }

        // Navigation properties
        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<DetallePedido>? DetallesPedido { get; set; }
        public virtual ICollection<Pago>? Pagos { get; set; }
    }
}
