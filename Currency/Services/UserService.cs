using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService (IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public UserModel GetUser(string name)
        {
            return unitOfWork.Users.GetUser(name);
        }

        public UserModel LoginUser(string name, string password)
        {
            return unitOfWork.Users.GetUser(name, password);
        }
    }
}
