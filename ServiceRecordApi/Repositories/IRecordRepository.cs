using Microsoft.AspNetCore.Mvc;
using ServiceRecordApi.Models;

namespace ServiceRecordApi.Repositories
{
    public interface IRecordRepository
    {
        Task<List<Record>> GetRecords();
        Task<Record> GetRecord(Guid id);
        Task<Record> CreateRecordAsync(Record record);
        Task<Record> UpdateRecord(Guid id, UpdateRecordDTO updateRecordDTO);
        Task<Record> DeleteRecord(Guid id);
    }
}
