using Microsoft.EntityFrameworkCore;

namespace ServiceRecordApi.Models
{
    public class RecordContext : DbContext
    {
        public RecordContext(DbContextOptions<RecordContext> options) : base(options) { }

        public DbSet<Record> Records { get; set; }
    }
}
