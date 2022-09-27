using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Repositories
{
    public interface IRegionRepository
    {
      public  Task<IEnumerable<Region>> GetAllAsync();

        public Task<Region> GetAsync(Guid Id);

        public Task<Region> AddAsync(Region region);

        public Task<Region> DeleteAsync(Guid Id);

        public Task<Region> UpdateAsync(Guid Id,Region region);
       
    }
}
