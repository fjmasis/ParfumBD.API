using Microsoft.AspNetCore.Mvc;
using ParfumBD.API.DTOs;
using ParfumBD.API.Models;
using ParfumBD.API.Repositories;

namespace ParfumBD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritosController : ControllerBase
    {
        private readonly IGenericRepository<Carrito> _carritoRepository;
        private readonly IGenericRepository<DetalleCarrito> _detalleCarritoRepository;
        private readonly IGenericRepository<Perfume> _perfumeRepository;

        public CarritosController(
            IGenericRepository<Carrito> carritoRepository,
            IGenericRepository<DetalleCarrito> detalleCarritoRepository,
            IGenericRepository<Perfume> perfumeRepository)
        {
            _carritoRepository = carritoRepository;
            _detalleCarritoRepository = detalleCarritoRepository;
            _perfumeRepository = perfumeRepository;
        }

        // GET: api/carritos/usuario/{idUsuario}
        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult<Carrito>> GetCarritoByUsuario(int idUsuario)
        {
            var carritos = await _carritoRepository.FindAsync(c => c.IdUsuario == idUsuario && c.Estado == "Activo");
            var carrito = carritos.FirstOrDefault();

            if (carrito == null)
            {
                return NotFound();
            }

            // Get cart details
            var detalles = await _detalleCarritoRepository.FindAsync(d => d.IdCarrito == carrito.IdCarrito);

            // For each detail, get the perfume information
            foreach (var detalle in detalles)
            {
                var perfume = await _perfumeRepository.GetByIdAsync(detalle.IdPerfume);
                if (perfume != null)
                {
                    detalle.Perfume = perfume;
                }
            }

            carrito.DetallesCarrito = detalles.ToList();

            return Ok(carrito);
        }

        // POST: api/carritos
        [HttpPost]
        public async Task<ActionResult<Carrito>> CreateCarrito(CarritoCreateDTO carritoDto)
        {
            var carrito = new Carrito
            {
                IdUsuario = carritoDto.IdUsuario,
                FechaCreacion = DateTime.Now,
                Estado = carritoDto.Estado
            };

            await _carritoRepository.AddAsync(carrito);
            await _carritoRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarritoByUsuario), new { idUsuario = carrito.IdUsuario }, carrito);
        }

        // PUT: api/carritos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarrito(int id, CarritoUpdateDTO carritoDto)
        {
            var carrito = await _carritoRepository.GetByIdAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }

            carrito.Estado = carritoDto.Estado;

            _carritoRepository.Update(carrito);
            await _carritoRepository.SaveChangesAsync();

            return NoContent();
        }
    }

    public class CarritoCreateDTO
    {
        public int IdUsuario { get; set; }
        public string Estado { get; set; } = string.Empty;
    }

    public class CarritoUpdateDTO
    {
        public string Estado { get; set; } = string.Empty;
    }
}
