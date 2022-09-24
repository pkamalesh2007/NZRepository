using Microsoft.EntityFrameworkCore;
using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Data
{
    public class NZDBContext : DbContext
    {
        public NZDBContext(DbContextOptions<NZDBContext> options) : base(options)
        { 
            
       }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<WalkDifficulty> WalkDifficulties  { get; set; }
    }
    
}
