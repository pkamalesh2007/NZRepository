using Microsoft.EntityFrameworkCore;
using NZWEBAPI.Data;
using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZDBContext db;

        public WalkRepository(NZDBContext db)
        {
            this.db = db;
        }

        public async Task<Walk> AddWalkAsync(Walk walk)
        {
            walk.Id = new Guid();
            await db.Walks.AddAsync(walk);
            await db.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteWalkAsync(Guid Id)
        {
            var walk = await db.Walks.FindAsync(Id);
            db.Walks.Remove(walk);
            await db.SaveChangesAsync();
            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
           return await db.Walks.
                Include(x=>x.Region)
                .Include(x=>x.WalkDifficulty).
                ToListAsync();
        }

        public async Task<Walk> GetWalkByIdAsync(Guid Id)
        {
            var walks= await db.Walks.Include(x=>x.Region).Include(x=>x.WalkDifficulty).
                       FirstOrDefaultAsync(x=> x.Id == Id);

            return walks;
        }

        public async Task<Walk> UpdateWalkAsync(Guid Id, Walk walk)
        {
            var existingUpdate = await db.Walks.FindAsync(Id);
            if (existingUpdate == null)
            {
                return null;
            }

            existingUpdate.Name = walk.Name;
            existingUpdate.WalkDifficultyId = walk.WalkDifficultyId;
            existingUpdate.Length=walk.Length;
            existingUpdate.RegionId=walk.RegionId;

            await db.SaveChangesAsync();
            return existingUpdate;

        }
    }
}
