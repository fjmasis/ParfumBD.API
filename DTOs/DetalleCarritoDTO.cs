namespace ParfumBD.API.DTOs
{
    public class DetalleCarritoDTO
    {
        public int IdDetalle { get; set; }
        public int IdCarrito { get; set; }
        public int IdPerfume { get; set; }
        public string? NombrePerfume { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }

    public class DetalleCarritoCreateDTO
    {
        public int IdCarrito { get; set; }
        public int IdPerfume { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

    public class DetalleCarritoUpdateDTO
    {
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
