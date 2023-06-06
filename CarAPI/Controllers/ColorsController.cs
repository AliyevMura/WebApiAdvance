using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAPI.DAL.EFCore;
using CarAPI.Entities;
using CarAPI.Entities.Dtos.Color;
using System.Net;
using AutoMapper;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ColorsController(AppDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Colors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetColorDto>>> GetColors()
        {
          if (_context.Colors == null)
          {
              return NotFound();
          }
          var result= await _context.Colors.ToListAsync();
            List<GetColorDto> getColorDtos = _mapper.Map<List<GetColorDto>>(result);

            return getColorDtos;
        }
       

        // GET: api/Colors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetColorDto>> GetColor(int id)
        {
          if (_context.Colors == null)
          {
              return NotFound();
          }
            var color = await _context.Colors.FindAsync(id);

            if (color == null)
            {
                return NotFound();
            }

            GetColorDto result = _mapper.Map<GetColorDto>(color);
            return result;
        }

        // PUT: api/Colors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(int id, UpdateColorDto colorDto)
        {
            if (!ColorExists(id))
            {
                return NotFound();
            }
            Color color = _mapper.Map<Color>(colorDto);
            color.Name = "hvfghbjn";
            _context.Colors.Update(color);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Colors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostColor([FromBody] CreateColorDto colorDto)
        {
            Color color = _mapper.Map<Color>(colorDto);
           
            color.Name = color.Name.Substring(0, 2);
            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Colors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            if (_context.Colors == null)
            {
                return NotFound();
            }
            var color = await _context.Colors.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }

            _context.Colors.Remove(color);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColorExists(int id)
        {
            return (_context.Colors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
