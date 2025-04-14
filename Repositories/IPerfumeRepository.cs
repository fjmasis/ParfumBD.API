using ParfumBD.API.Models;

namespace ParfumBD.API.Repositories
{
    public interface IPerfumeRepository : IGenericRepository<Perfume>
    {
        Task<IEnumerable<Perfume>> GetActiveAsync();
        Task<IEnumerable<Perfume>> GetByMarcaAsync(string marca);
    }
}
