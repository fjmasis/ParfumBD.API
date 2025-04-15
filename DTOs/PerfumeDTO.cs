namespace ParfumBD.API.DTOs
{
    public class PerfumeDTO
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
    }
    public class PerfumeCreateDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string TipoFragancia { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Imagen { get; set; } = string.Empty;
        public int Stock { get; set; }
        public bool Estado { get; set; }
    }

    public class PerfumeUpdateDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string TipoFragancia { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Imagen { get; set; } = string.Empty;
        public int Stock { get; set; }
        public bool Estado { get; set; } 
    }
}
