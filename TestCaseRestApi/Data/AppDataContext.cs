using Microsoft.EntityFrameworkCore;
using TestCaseRestApi.Models;

namespace TestCaseRestApi.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<DrillBlock> DrillBlocks { get; set; }
        public DbSet<DrillBlockPoints> DrillBlocksPoints { get; set;}
        public DbSet<Hole> Holes { get; set; }
        public DbSet<HolePoints> HolePoints { get; set; }

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
            Database.EnsureCreated();  
        }

    }
}
