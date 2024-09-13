using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecordsApi.Controllers;
using Xunit.Sdk;
using ServiceRecordApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ServiceRecordApiTests
{
    public class RecordControllerTest
    {
        RecordsController _controller;

        //[Fact]
        //public void GetRecordsSuccess()
        //{
        //    // TODO: Mock a database to return a premade list
        //    // of records to GetRecords
        //    var records = _controller.GetRecords();
        //    Assert.NotNull(records);
        //}

        [Fact]
        public void CreateRecordSuccess()
        {
            var testRecord = new ServiceRecordApi.Models.CreateRecordDTO()
            {
                Owner = "Test",
                Date = DateTime.Now,
                Make = "Volkswagen",
                Model = "GTI",
                Year = 2012,
                VIN = "ABCDEFGHIJKLMNOPQ",
                License = "ABC123",
                Mileage = 169000,
                Service = "Timing belt",
                Charge = 673.89
            };

            var response = _controller.CreateRecord(testRecord);
            Assert.IsType<CreatedAtActionResult>(response);

            var createdAtResult = response.Result;
            Assert.IsType<ServiceRecordApi.Models.Record>(createdAtResult.Value);
        }
    }
}