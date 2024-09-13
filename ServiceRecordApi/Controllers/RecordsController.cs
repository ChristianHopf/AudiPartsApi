using Microsoft.AspNetCore.Diagnostics;
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
        public async Task<ActionResult<Record>> CreateRecord(CreateRecordDTO createRecordDTO)
        {
            var id = Guid.NewGuid();
            var record = new Record
            {
                Id = id,
                Owner = createRecordDTO.Owner,
                Date = createRecordDTO.Date,
                Make = createRecordDTO.Make,
                Model = createRecordDTO.Model,
                Year = createRecordDTO.Year,
                VIN = createRecordDTO.VIN,
                License = createRecordDTO.License,
                Mileage = createRecordDTO.Mileage,
                Service = createRecordDTO.Service,
                Charge = createRecordDTO.Charge
            };
            _context.Records.Add(record);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecord), new { id = record.Id }, record);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecord(Guid id, UpdateRecordDTO updateRecordDTO)
        {
            //if (id != record.Id)
            //{
            //    return BadRequest();
            //}

            var foundRecord = await _context.Records.FindAsync(id);
            if (foundRecord == null)
            {
                return NotFound();
            }

            foundRecord.Owner = updateRecordDTO.Owner;
            foundRecord.Date = updateRecordDTO.Date;
            foundRecord.Make = updateRecordDTO.Make;
            foundRecord.Model = updateRecordDTO.Model;
            foundRecord.Year = updateRecordDTO.Year;
            foundRecord.VIN = updateRecordDTO.VIN;
            foundRecord.License = updateRecordDTO.License;
            foundRecord.Mileage = updateRecordDTO.Mileage;
            foundRecord.Service = updateRecordDTO.Service;
            foundRecord.Charge = updateRecordDTO.Charge;

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

        [HttpGet("Throw")]
        public IActionResult Throw() => throw new Exception("Sample exception.");

        //[Route("/error-dev")]
        //public IActionResult HandleErrorDev([FromServices] IHostEnvironment hostEnvironment)
        //{
        //    if (!hostEnvironment.IsDevelopment())
        //    {
        //        return NotFound();
        //    }
        //    var exceptionhandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
        //    return Problem(
        //        detail: exceptionhandlerFeature.Error.StackTrace,
        //        title: exceptionhandlerFeature.Error.Message);
        //}

        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError() =>
            Problem();

        //private Record CreateRecordDTOToRecord(CreateRecordDTO createRecordDTO)
        //{
        //    Guid id = Guid.NewGuid();
        //    var record = new Record(
        //        id,
        //        createRecordDTO.Owner,
        //        createRecordDTO.Date,
        //        createRecordDTO.Make,
        //        createRecordDTO.Model,
        //        createRecordDTO.Year,
        //        createRecordDTO.VIN,
        //            createRecordDTO.License,
        //            createRecordDTO.Mileage,
        //            createRecordDTO.Service,
        //            createRecordDTO.Charge
        //        );
        //    return record;
        //}
    }
}