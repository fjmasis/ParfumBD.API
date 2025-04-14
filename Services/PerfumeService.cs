using ParfumBD.API.DTOs;
using ParfumBD.API.Models;
using ParfumBD.API.Repositories;

namespace ParfumBD.API.Services
{
    public class PerfumeService : IPerfumeService
    {
        private readonly IPerfumeRepository _perfumeRepository;

        public PerfumeService(IPerfumeRepository perfumeRepository)
        {
            _perfumeRepository = perfumeRepository;
        }

        public async Task<IEnumerable<PerfumeDTO>> GetAllPerfumesAsync()
        {
            var perfumes = await _perfumeRepository.GetAllAsync();
            return perfumes.Select(MapToDto);
        }

        public async Task<IEnumerable<PerfumeDTO>> GetActivePerfumesAsync()
        {
            var perfumes = await _perfumeRepository.GetActiveAsync();
            return perfumes.Select(MapToDto);
        }

        public async Task<PerfumeDTO?> GetPerfumeByIdAsync(int id)
        {
            var perfume = await _perfumeRepository.GetByIdAsync(id);
            return perfume != null ? MapToDto(perfume) : null;
        }

        public async Task<IEnumerable<PerfumeDTO>> GetPerfumesByMarcaAsync(string marca)
        {
            var perfumes = await _perfumeRepository.GetByMarcaAsync(marca);
            return perfumes.Select(MapToDto);
        }

        public async Task<PerfumeDTO?> CreatePerfumeAsync(PerfumeCreateDTO perfumeDto)
        {
            var perfume = new Perfume
            {
                Nombre = perfumeDto.Nombre,
                Marca = perfumeDto.Marca,
                Descripcion = perfumeDto.Descripcion,
                TipoFragancia = perfumeDto.TipoFragancia,
                Precio = perfumeDto.Precio,
                Imagen = perfumeDto.Imagen,
                Stock = perfumeDto.Stock,
                Estado = perfumeDto.Estado
            };

            await _perfumeRepository.AddAsync(perfume);
            await _perfumeRepository.SaveChangesAsync();

            return MapToDto(perfume);
        }

        public async Task<PerfumeDTO?> UpdatePerfumeAsync(int id, PerfumeUpdateDTO perfumeDto)
        {
            var perfume = await _perfumeRepository.GetByIdAsync(id);
            if (perfume == null)
            {
                return null;
            }

            perfume.Nombre = perfumeDto.Nombre;
            perfume.Marca = perfumeDto.Marca;
            perfume.Precio = perfumeDto.Precio;
            perfume.Stock = perfumeDto.Stock;
            perfume.Estado = perfumeDto.Estado;

            _perfumeRepository.Update(perfume);
            await _perfumeRepository.SaveChangesAsync();

            return MapToDto(perfume);
        }

        public async Task<bool> DeletePerfumeAsync(int id)
        {
            var perfume = await _perfumeRepository.GetByIdAsync(id);
            if (perfume == null)
            {
                return false;
            }

            _perfumeRepository.Remove(perfume);
            await _perfumeRepository.SaveChangesAsync();

            return true;
        }

        private static PerfumeDTO MapToDto(Perfume perfume)
        {
            return new PerfumeDTO
            {
                IdPerfume = perfume.IdPerfume,
                Nombre = perfume.Nombre,
                Marca = perfume.Marca,
                Descripcion = perfume.Descripcion,
                TipoFragancia = perfume.TipoFragancia,
                Precio = perfume.Precio,
                Imagen = perfume.Imagen,
                Stock = perfume.Stock,
                Estado = perfume.Estado
            };
        }
    }
}
