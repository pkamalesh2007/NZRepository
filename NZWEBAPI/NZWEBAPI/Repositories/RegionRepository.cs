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

        public async Task<Region> AddAsync(Region region)
        {
            
            await db.Regions.AddAsync(region);
            await db.SaveChangesAsync();
            return region;

           
        }

        public async Task<Region> DeleteAsync(Guid Id)
        {
            var region = await db.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if (region == null)
            {
                return null;
            }
             db.Regions.Remove(region);  
             await db.SaveChangesAsync();
            return region;

        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            var regions = await db.Regions.ToListAsync();
            return regions;
        }

        public async Task<Region> GetAsync(Guid Id)
        {
            var region= await db.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            return region;
        }

        public async Task<Region> UpdateAsync(Guid Id,Region region)
        {
           var existingUpdate= await db.Regions.FirstOrDefaultAsync(x => x.Id == Id);

            if(existingUpdate == null)
            {
                return null;
            }

            existingUpdate.Code=region.Code;
            existingUpdate.Area=region.Area;
            existingUpdate.Lat =region.Lat;
            existingUpdate.Long=region.Long;
            existingUpdate.Population=region.Population;
            existingUpdate.Name = region.Name;

            await db.SaveChangesAsync();
            return existingUpdate;


           
          
        }

        
    }
}
