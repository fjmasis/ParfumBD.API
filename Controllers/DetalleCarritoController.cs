using Microsoft.AspNetCore.Mvc;
using ParfumBD.API.DTOs;
using ParfumBD.API.Models;
using ParfumBD.API.Repositories;

namespace ParfumBD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCarritoController : ControllerBase
    {
        private readonly IGenericRepository<DetalleCarrito> _detalleCarritoRepository;
        private readonly IGenericRepository<Perfume> _perfumeRepository;

        public DetalleCarritoController(
            IGenericRepository<DetalleCarrito> detalleCarritoRepository,
            IGenericRepository<Perfume> perfumeRepository)
        {
            _detalleCarritoRepository = detalleCarritoRepository;
            _perfumeRepository = perfumeRepository;
        }

        // GET: api/detallecarrito/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleCarrito>> GetDetalleCarrito(int id)
        {
            var detalle = await _detalleCarritoRepository.GetByIdAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }

            return Ok(detalle);
        }

        // POST: api/detallecarrito
        [HttpPost]
        public async Task<ActionResult<DetalleCarrito>> CreateDetalleCarrito(DetalleCarritoCreateDTO detalleDto)
        {
            // Check if perfume exists and has enough stock
            var perfume = await _perfumeRepository.GetByIdAsync(detalleDto.IdPerfume);
            if (perfume == null)
            {
                return BadRequest("El perfume no existe");
            }

            if (perfume.Stock < detalleDto.Cantidad)
            {
                return BadRequest("No hay suficiente stock disponible");
            }

            var detalle = new DetalleCarrito
            {
                IdCarrito = detalleDto.IdCarrito,
                IdPerfume = detalleDto.IdPerfume,
                Cantidad = detalleDto.Cantidad,
                PrecioUnitario = detalleDto.PrecioUnitario
            };

            await _detalleCarritoRepository.AddAsync(detalle);
            await _detalleCarritoRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDetalleCarrito), new { id = detalle.IdDetalle }, detalle);
        }

        // PUT: api/detallecarrito/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDetalleCarrito(int id, DetalleCarritoUpdateDTO detalleDto)
        {
            var detalle = await _detalleCarritoRepository.GetByIdAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }

            detalle.Cantidad = detalleDto.Cantidad;
            detalle.PrecioUnitario = detalleDto.PrecioUnitario;

            _detalleCarritoRepository.Update(detalle);
            await _detalleCarritoRepository.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/detallecarrito/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleCarrito(int id)
        {
            var detalle = await _detalleCarritoRepository.GetByIdAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }

            _detalleCarritoRepository.Remove(detalle);
            await _detalleCarritoRepository.SaveChangesAsync();

            return NoContent();
        }
    }

    public class DetalleCarritoCreateDTO
    {
        public int IdCarrito { get; set; }
        public int IdPerfume { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

    public class DetalleCarritoUpdateDTO
    {
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}