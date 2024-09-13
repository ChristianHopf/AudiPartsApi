using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceRecordApi.Models;
using ServiceRecordApi.Repositories;

namespace RecordsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordRepository _repository;
        public RecordsController(IRecordRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Record>>> GetRecords()
        {
            return await _repository.GetRecords();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Record>> GetRecord(Guid id)
        {

            var record = await _repository.GetRecord(id);
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
            var createdRecord = await _repository.CreateRecordAsync(record);

            return CreatedAtAction(nameof(GetRecord), new { id = record.Id }, record);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecord(Guid id, UpdateRecordDTO updateRecordDTO)
        {
            //if (id != record.Id)
            //{
            //    return BadRequest();
            //}
            var updatedRecord = await _repository.UpdateRecord(id, updateRecordDTO);
            if (updatedRecord == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord(Guid id)
        {
            var deletedRecord = await _repository.DeleteRecord(id);
            if (deletedRecord == null)
            {
                return NotFound();
            }

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