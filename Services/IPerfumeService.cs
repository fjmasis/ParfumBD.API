using ParfumBD.API.DTOs;

namespace ParfumBD.API.Services
{
    public interface IPerfumeService
    {
        Task<IEnumerable<PerfumeDTO>> GetAllPerfumesAsync();
        Task<IEnumerable<PerfumeDTO>> GetActivePerfumesAsync();
        Task<PerfumeDTO?> GetPerfumeByIdAsync(int id);
        Task<IEnumerable<PerfumeDTO>> GetPerfumesByMarcaAsync(string marca);
        Task<PerfumeDTO?> CreatePerfumeAsync(PerfumeCreateDTO perfumeDto);
        Task<PerfumeDTO?> UpdatePerfumeAsync(int id, PerfumeUpdateDTO perfumeDto);
        Task<bool> DeletePerfumeAsync(int id);
    }
}
