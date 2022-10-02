using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Repositories
{
    public interface ITokenHandler
    {
      public  Task<string> CreateTokenAsync(User user);
    }
}
