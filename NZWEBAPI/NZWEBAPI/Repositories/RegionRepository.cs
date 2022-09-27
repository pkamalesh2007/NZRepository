using Microsoft.EntityFrameworkCore;
using NZWEBAPI.Data;
using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZDBContext db;

        public RegionRepository(NZDBContext db)
        {
            this.db = db;
        }

       

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            var regions = await db.Regions.ToListAsync();
            return regions;
        }
    }
}
