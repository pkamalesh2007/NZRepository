using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Repositories
{
    public interface IRegionRepository
    {
      public  Task<IEnumerable<Region>> GetAllAsync();
    }
}
