using ParfumBD.API.DTOs;
using ParfumBD.API.Models;
using ParfumBD.API.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace ParfumBD.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return usuarios.Select(MapToDto);
        }

        public async Task<UsuarioDTO?> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            return usuario != null ? MapToDto(usuario) : null;
        }

        public async Task<UsuarioDTO?> CreateUsuarioAsync(UsuarioCreateDTO usuarioDto)
        {
            if (await _usuarioRepository.ExistsAsync(usuarioDto.Correo))
            {
                return null; // Email already exists
            }

            var usuario = new Usuario
            {
                Nombre = usuarioDto.Nombre,
                Correo = usuarioDto.Correo,
                Contraseña = HashPassword(usuarioDto.Contraseña),
                TipoUsuario = usuarioDto.TipoUsuario,
                FechaRegistro = DateTime.Now
            };

            await _usuarioRepository.AddAsync(usuario);
            await _usuarioRepository.SaveChangesAsync();

            return MapToDto(usuario);
        }

        public async Task<UsuarioDTO?> UpdateUsuarioAsync(int id, UsuarioUpdateDTO usuarioDto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                return null;
            }

            // Check if email is being changed and if it already exists
            if (usuario.Correo != usuarioDto.Correo && await _usuarioRepository.ExistsAsync(usuarioDto.Correo))
            {
                return null; // New email already exists
            }

            usuario.Nombre = usuarioDto.Nombre;
            usuario.Correo = usuarioDto.Correo;
            usuario.TipoUsuario = usuarioDto.TipoUsuario;

            _usuarioRepository.Update(usuario);
            await _usuarioRepository.SaveChangesAsync();

            return MapToDto(usuario);
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                return false;
            }

            _usuarioRepository.Remove(usuario);
            await _usuarioRepository.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioDTO?> AuthenticateAsync(UsuarioLoginDTO loginDto)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(loginDto.Correo);
            if (usuario == null)
            {
                return null;
            }

            // Verify password
            if (usuario.Contraseña != HashPassword(loginDto.Contraseña))
            {
                return null;
            }

            return MapToDto(usuario);
        }

        private static string HashPassword(string password)
        {
            // In a real application, use a proper password hashing library like BCrypt
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        private static UsuarioDTO MapToDto(Usuario usuario)
        {
            return new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                TipoUsuario = usuario.TipoUsuario,
                FechaRegistro = usuario.FechaRegistro
            };
        }
    }
}
