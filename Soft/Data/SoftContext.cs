using Microsoft.EntityFrameworkCore;

namespace Soft.Data {
    public class SoftContext : DbContext {
        public SoftContext(DbContextOptions<SoftContext> options)
            : base(options) {
        }

        public DbSet<Soft.Data.TestData> TestData { get; set; }
    }
}
