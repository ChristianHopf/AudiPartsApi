using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsApi.Models;

namespace PartsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly PartsContext _context;
        public PartsController(PartsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Part>>> GetParts()
        {
            return await _context.Parts.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<Part>> GetPart(Guid id)
        {

            var part = await _context.Parts.FindAsync(id);
            if (part == null)
            {
                return NotFound();
            }
            return Ok(part);
        }
    }
}