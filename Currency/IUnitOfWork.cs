using CurrencyAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyAPI
{
    public interface IUnitOfWork : IDisposable
    {
        ICurrencyRepository Days { get; }

        IUserRepository Users { get; }

        int SaveChanges();
    }
}
