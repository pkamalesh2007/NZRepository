using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Repositories
{
    public interface IWalkRepository
    {
      public Task<IEnumerable<Walk>> GetAllAsync();

        public Task<Walk> GetWalkByIdAsync(Guid Id);

        public Task<Walk> AddWalkAsync(Walk walk);

        public Task<Walk> UpdateWalkAsync(Guid Id,Walk walk);
     
        public Task<Walk> DeleteWalkAsync(Guid Id);
    }
}
