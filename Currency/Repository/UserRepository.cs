using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI.Repository
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        public CurrenciesDbContext UserContext
        {
            get
            {
                return Context as CurrenciesDbContext;
            }
        }

        public UserRepository(CurrenciesDbContext context) : base(context)
        {

        }

        public UserModel GetUser(string name, string password)
        {
            return UserContext.Users.FirstOrDefault(x => x.Name == name && x.Password == password);
        }

        public UserModel GetUser(string name)
        {
            return UserContext.Users.FirstOrDefault(x => x.Name == name);
        }
    }
}
