using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceRecordApi.Models;

namespace RecordsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly RecordContext _context;
        public RecordsController(RecordContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Record>>> GetRecords()
        {
            return await _context.Records.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Record>> GetRecord(Guid id)
        {

            var record = await _context.Records.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost]
        public async Task<ActionResult<Record>> CreateRecord(Record record)
        {
            _context.Records.Add(record);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecord), new { id = record.Id }, record);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecord(Guid id, Record record)
        {
            if (id != record.Id)
            {
                return BadRequest();
            }

            var foundRecord = await _context.Records.FindAsync(id);
            if (foundRecord == null)
            {
                return NotFound();
            }

            foundRecord.Owner = record.Owner;
            foundRecord.Date = DateTime.Now;
            foundRecord.Make = record.Make;
            foundRecord.Model = record.Model;
            foundRecord.Year = record.Year;
            foundRecord.VIN = record.VIN;
            foundRecord.License = record.License;
            foundRecord.Mileage = record.Mileage;
            foundRecord.Service = record.Service;
            foundRecord.Charge = record.Charge;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord(Guid id)
        {
            var foundRecord = await _context.Records.FindAsync(id);
            if (foundRecord == null)
            {
                return NotFound();
            }

            _context.Records.Remove(foundRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}