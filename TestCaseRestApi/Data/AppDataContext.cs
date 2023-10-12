using Microsoft.EntityFrameworkCore;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<DrillBlock> DrillBlocks { get; set; }
        public DbSet<DrillBlockPoint> DrillBlockPoints { get; set;}
        public DbSet<Hole> Holes { get; set; }
        public DbSet<HolePoint> HolePoints { get; set; }

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
            Database.EnsureCreated();  
        }

    }
}
