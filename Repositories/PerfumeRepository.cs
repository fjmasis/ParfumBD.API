using ParfumBD.API.Data;
using ParfumBD.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ParfumBD.API.Repositories
{
    public class PerfumeRepository : GenericRepository<Perfume>, IPerfumeRepository
    {
        public PerfumeRepository(ParfumBDContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Perfume>> GetActiveAsync()
        {
            return await _dbSet.Where(p => p.Estado).ToListAsync();
        }

        public async Task<IEnumerable<Perfume>> GetByMarcaAsync(string marca)
        {
            return await _dbSet.Where(p => p.Marca == marca && p.Estado).ToListAsync();
        }
    }
}
