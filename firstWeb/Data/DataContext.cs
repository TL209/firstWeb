using Microsoft.EntityFrameworkCore;

namespace firstWeb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<firstWeb> firstWebs { get; set; }

    }
}
