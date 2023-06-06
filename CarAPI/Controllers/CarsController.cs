using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAPI.DAL.EFCore;
using CarAPI.Entities;
using AutoMapper;
using CarAPI.Entities.Dtos.Color;
using CarAPI.Entities.Dtos.Car;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CarsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCarDto>>> GetCars()
        {
            if (_context.Cars == null)
            {
                return NotFound();
            }
            var result = await _context.Cars.ToListAsync();
            List<GetCarDto> getCarDtos = _mapper.Map<List<GetCarDto>>(result);

            return getCarDtos;
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCarDto>> GetCar(int id)
        {
            if (_context.Cars == null)
            {
                return NotFound();
            }
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            GetCarDto result = _mapper.Map<GetCarDto>(car);
            return result;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, UpdateCarDto carDto)
        {
            if (!CarExists(id))
            {
                return NotFound();
            }
            Car car = _mapper.Map<Car>(carDto);
            car.ColorId = carDto.ColorId;
            car.BrandId = carDto.BrandId;
            car.Description = carDto.Description;
            car.DailyPrice = carDto.DailyPrice;
            car.ModelYear = carDto.ModelYear;

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
          if (_context.Cars == null)
          {
              return Problem("Entity set 'AppDbContext.Cars'  is null.");
          }
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (_context.Cars == null)
            {
                return NotFound();
            }
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return (_context.Cars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
