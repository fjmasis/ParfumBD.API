using Microsoft.AspNetCore.Mvc;
using ParfumBD.API.DTOs;
using ParfumBD.API.Services;

namespace ParfumBD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumesController : ControllerBase
    {
        private readonly IPerfumeService _perfumeService;

        public PerfumesController(IPerfumeService perfumeService)
        {
            _perfumeService = perfumeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerfumeDTO>>> GetPerfumes()
        {
            var perfumes = await _perfumeService.GetAllPerfumesAsync();
            return Ok(perfumes);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<PerfumeDTO>>> GetActivePerfumes()
        {
            var perfumes = await _perfumeService.GetActivePerfumesAsync();
            return Ok(perfumes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PerfumeDTO>> GetPerfume(int id)
        {
            var perfume = await _perfumeService.GetPerfumeByIdAsync(id);
            if (perfume == null)
            {
                return NotFound();
            }
            return Ok(perfume);
        }

        [HttpGet("marca/{marca}")]
        public async Task<ActionResult<IEnumerable<PerfumeDTO>>> GetPerfumesByMarca(string marca)
        {
            var perfumes = await _perfumeService.GetPerfumesByMarcaAsync(marca);
            return Ok(perfumes);
        }

        [HttpPost]
        public async Task<ActionResult<PerfumeDTO>> CreatePerfume(PerfumeCreateDTO perfumeDto)
        {
            var perfume = await _perfumeService.CreatePerfumeAsync(perfumeDto);
            return CreatedAtAction(nameof(GetPerfume), new { id = perfume.IdPerfume }, perfume);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerfume(int id, PerfumeUpdateDTO perfumeDto)
        {
            var perfume = await _perfumeService.UpdatePerfumeAsync(id, perfumeDto);
            if (perfume == null)
            {
                return NotFound();
            }
            return Ok(perfume);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfume(int id)
        {
            var result = await _perfumeService.DeletePerfumeAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}