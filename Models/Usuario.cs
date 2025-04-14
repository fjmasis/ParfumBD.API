namespace ParfumBD.API.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public string? TipoUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }

        // Navigation properties
        public virtual ICollection<Carrito>? Carritos { get; set; }
        public virtual ICollection<Pedido>? Pedidos { get; set; }
        public virtual ICollection<Direccion>? Direcciones { get; set; }
        public virtual ICollection<LogAdmin>? LogsAdmin { get; set; }
    }
}
