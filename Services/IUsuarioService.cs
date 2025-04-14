using ParfumBD.API.DTOs;

namespace ParfumBD.API.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetAllUsuariosAsync();
        Task<UsuarioDTO?> GetUsuarioByIdAsync(int id);
        Task<UsuarioDTO?> CreateUsuarioAsync(UsuarioCreateDTO usuarioDto);
        Task<UsuarioDTO?> UpdateUsuarioAsync(int id, UsuarioUpdateDTO usuarioDto);
        Task<bool> DeleteUsuarioAsync(int id);
        Task<UsuarioDTO?> AuthenticateAsync(UsuarioLoginDTO loginDto);
    }
}
