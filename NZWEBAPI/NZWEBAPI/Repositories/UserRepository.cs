using Microsoft.EntityFrameworkCore;
using NZWEBAPI.Data;
using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NZDBContext db;

        public UserRepository(NZDBContext db)
        {
            this.db = db;
        }
        public async Task<User> AuthenticateAsync(string username, string password)
        {
          var user= await db.Users.FirstOrDefaultAsync(x => x.UserName==username.ToLower().Trim() && x.Password== password);
          if(user==null)
           {
                return null;
           }

            var userRoles = await db.Users_Roles.Where(x => x.UserId == user.Id).ToListAsync();

            if(userRoles.Any())
            {
                user.Roles = new List<string>();
                
                foreach(var userRole in userRoles)
                {
                   var role= await db.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
                    if (role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }

                
            }
            user.Password = null;
            return user;
        
        }
    }
}
