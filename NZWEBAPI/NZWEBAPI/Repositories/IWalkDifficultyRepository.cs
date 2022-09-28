using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Repositories
{
    public interface IWalkDifficultyRepository
    {
        public Task<IEnumerable<WalkDifficulty>> GetAllWalkDiffultiesAsync();

        public Task<WalkDifficulty> GetWalkDifficultyByIdAsync(Guid Id);

        public Task<WalkDifficulty> CreateWalkDifficultyAsync(WalkDifficulty walkDifficulty);

        public Task<WalkDifficulty> UpdateWalkDifficultyAsync(Guid Id,WalkDifficulty walkDifficulty);


        public Task<WalkDifficulty>DeleteWalkDifficultyAsync(Guid Id);
    }
}
