using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        private List<User> Users = new List<User>()
        {
            //new User()
            //{
            //    UserName="pkamalesh2007",
            //    EmailAddress="pkamalesh2007@gmail.com",
            //    FirstName="Kamalesh",
            //    LastName="Pulavarty",
            //    Password="abc@1234",
            //    Id=Guid.NewGuid(),
            //    Roles= new List<string>(){"Read"}

            //},

            // new User()
            //{
            //    UserName="bhaskar2011",
            //    EmailAddress="bhaskar2011@gmail.com",
            //    FirstName="bhaskar",
            //    LastName="Pulavarty",
            //    Password="abc@1234",
            //    Id=Guid.NewGuid(),
            //    Roles= new List<string>(){"Read","Write"}

            //},
        };
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = Users.Find(x => x.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password.Equals(password));
            
            return user;
        
        }
    }
}
