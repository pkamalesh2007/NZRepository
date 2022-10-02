using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
