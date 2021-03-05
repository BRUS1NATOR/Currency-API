using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI.Services
{
    public interface IUserService
    {
        UserModel GetUser(string name);

        UserModel LoginUser(string name, string password);
    }
}
