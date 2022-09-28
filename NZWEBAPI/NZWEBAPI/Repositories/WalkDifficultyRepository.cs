using Microsoft.EntityFrameworkCore;
using NZWEBAPI.Data;
using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZDBContext db;

        public WalkDifficultyRepository(NZDBContext db)
        {
            this.db = db;
        }
        public async Task<WalkDifficulty> CreateWalkDifficultyAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = new Guid();
            await db.WalkDifficulties.AddAsync(walkDifficulty);
            await db.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteWalkDifficultyAsync(Guid Id)
        {
            var obj = await db.WalkDifficulties.FindAsync(Id);
            db.WalkDifficulties.Remove(obj);
            await db.SaveChangesAsync();
            return obj;


        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllWalkDiffultiesAsync()
        {
            return await db.WalkDifficulties.ToListAsync();
        }

        public async Task<WalkDifficulty> GetWalkDifficultyByIdAsync(Guid Id)
        {
            return await db.WalkDifficulties.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public  async Task<WalkDifficulty> UpdateWalkDifficultyAsync(Guid Id, WalkDifficulty walkDifficulty)
        {
            var existingUpdate = await db.WalkDifficulties.FindAsync(Id);

            if (existingUpdate == null)
            {
                return null;
            }

            existingUpdate.Code = walkDifficulty.Code;
            

            await db.SaveChangesAsync();
            return existingUpdate;
        }
    }
}
