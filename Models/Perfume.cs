﻿namespace ParfumBD.API.Models
{
    public class Perfume
    {
        public int IdPerfume { get; set; }
        public string? Nombre { get; set; }
        public string? Marca { get; set; }
        public string? Descripcion { get; set; }
        public string? TipoFragancia { get; set; }
        public decimal Precio { get; set; }
        public string? Imagen { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }

        // Navigation properties
        public virtual ICollection<DetalleCarrito>? DetallesCarrito { get; set; }
        public virtual ICollection<DetallePedido>? DetallesPedido { get; set; }
        public virtual ICollection<HistorialStock>? HistorialStock { get; set; }
    }
}
