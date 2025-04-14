namespace ParfumBD.API.DTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? TipoUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
    public class UsuarioCreateDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public string TipoUsuario { get; set; } = string.Empty;
    }

    public class UsuarioUpdateDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string TipoUsuario { get; set; } = string.Empty;
    }

    public class UsuarioLoginDTO
    {
        public string Correo { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
    }
}
