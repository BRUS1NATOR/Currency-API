using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI.Repository
{
    public interface IUserRepository : IRepository<UserModel>
    {
        public UserModel GetUser(string name);
        public UserModel GetUser(string name, string password);
    }
}
