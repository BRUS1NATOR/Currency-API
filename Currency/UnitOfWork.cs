using CurrencyAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyAPI
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CurrenciesDbContext _context;
        public ICurrencyRepository Days { get; private set; }

        public IUserRepository Users { get; private set; }

        public UnitOfWork(CurrenciesDbContext context)
        {
            _context = context;
            Days = new CurrencyRepository(_context);
            Users = new UserRepository(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
