using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceRecordApi.Models;

namespace ServiceRecordApi.Repositories
{
    public class RecordRepositoryImpl : IRecordRepository
    {
        private readonly RecordContext _context;
        public RecordRepositoryImpl(RecordContext context)
        {
            _context = context;
        }

        public async Task<List<Record>> GetRecords()
        {
            return await _context.Records.ToListAsync();
        }

        public async Task<Record?> GetRecord(Guid id)
        {
            return await _context.Records.FindAsync(id);
        }

        public async Task<Record> CreateRecordAsync(Record record)
        {
            _context.Records.Add(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<Record?> UpdateRecord(Guid id, UpdateRecordDTO updateRecordDTO)
        {
            var foundRecord = await _context.Records.FindAsync(id);
            if (foundRecord == null)
            {
                return null;
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

            return foundRecord;
        }
        public async Task<Record?> DeleteRecord(Guid id)
        {
            var foundRecord = await _context.Records.FindAsync(id);
            if (foundRecord == null)
            {
                return null;
            }
            _context.Records.Remove(foundRecord);
            await _context.SaveChangesAsync();
            return foundRecord;
        }
    }
}
