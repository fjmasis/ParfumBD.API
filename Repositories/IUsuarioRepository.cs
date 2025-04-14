using ParfumBD.API.Models;

namespace ParfumBD.API.Repositories
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario?> GetByEmailAsync(string email);
        Task<bool> ExistsAsync(string email);
    }
}
