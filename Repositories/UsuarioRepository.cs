using Microsoft.EntityFrameworkCore;
using ParfumBD.API.Data;
using ParfumBD.API.Models;

namespace ParfumBD.API.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ParfumBDContext context) : base(context)
        {
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Correo == email);
        }

        public async Task<bool> ExistsAsync(string email)
        {
            return await _dbSet.AnyAsync(u => u.Correo == email);
        }
    }
}
