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
using CarAPI.Entities.Dtos.Brand;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public BrandsController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetBrandDto>>> GetBrands()
        {
            if (_context.Brands == null)
            {
                return NotFound();
            }
            var result = await _context.Brands.ToListAsync();
            List<GetBrandDto> getBrandDtos = _mapper.Map<List<GetBrandDto>>(result);

            return getBrandDtos;
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetBrandDto>> GetBrand(int id)
        {
            if (_context.Brands == null)
            {
                return NotFound();
            }
            var color = await _context.Brands.FindAsync(id);

            if (color == null)
            {
                return NotFound();
            }

            GetBrandDto result = _mapper.Map<GetBrandDto>(color);
            return result;
        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, UpdateBrandDto brandDto)
        {
            if (!BrandExists(id))
            {
                return NotFound();
            }
            Brand brand = _mapper.Map<Brand>(brandDto);
            brand.Name = "hvfghbjn";
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Brands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostBrand([FromBody] CreateBrandDto brandDto)
        {
            Brand brand = _mapper.Map<Brand>(brandDto);

            brand.Name = brand.Name.Substring(0, 2);
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            if (_context.Brands == null)
            {
                return NotFound();
            }
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrandExists(int id)
        {
            return (_context.Brands?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
