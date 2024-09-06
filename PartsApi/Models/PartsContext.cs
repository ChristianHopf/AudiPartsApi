using Microsoft.EntityFrameworkCore;

namespace PartsApi.Models
{
    public class PartsContext : DbContext
    {
        public PartsContext(DbContextOptions<PartsContext> options) : base(options) { }

        public DbSet<Part> Parts { get; set; } = null!;
    }
}
