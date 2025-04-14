namespace ParfumBD.API.DTOs
{
    public class CarritoDTO
    {
        public int IdCarrito { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? Estado { get; set; }
        public List<DetalleCarritoDTO>? DetallesCarrito { get; set; }
    }

    public class CarritoCreateDTO
    {
        public int IdUsuario { get; set; }
        public string Estado { get; set; } = string.Empty;
    }

    public class CarritoUpdateDTO
    {
        public string Estado { get; set; } = string.Empty;
    }
}
