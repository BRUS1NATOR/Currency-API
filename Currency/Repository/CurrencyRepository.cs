using CurrencyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurrencyAPI.Repository
{
    public class CurrencyRepository : Repository<DayModel>, ICurrencyRepository
    {
        public CurrenciesDbContext DayContext
        {
            get
            {
                return Context as CurrenciesDbContext;
            }
        }

        public CurrencyRepository(CurrenciesDbContext context) : base(context)
        {
            
        }

        public override void Add(DayModel entity)
        {
            if (!DayContext.Days.Any(record => record.Date.Date == entity.Date.Date))
            {
                base.Add(entity);
            }
            else
            {
                Console.WriteLine("Record with {0} date already exists", entity.Date.Date);
            }
        }

        public override void AddRange(IEnumerable<DayModel> entities)
        {
            foreach (var d in entities)
            {
                Add(d);
            }
        }

        public override IEnumerable<DayModel> GetAll()
        {
            return DayContext.Days.Include(x => x.Currencies).ToList();
        }

        public DayModel GetCurrencies(DateTime time)
        {
            var result = DayContext.Days.Include(x => x.Currencies).FirstOrDefault(x => x.Date.Day == time.Day);

            if (result == null)
            {
                return DayContext.Days.Include(x => x.Currencies).OrderBy(x => x.Date.Day).Last();
            }

            return result;
        }

        public CurrencyModel GetCurrency(string id, DateTime time)
        {
            var currencies = DayContext.Currencies.Include(x=>x.Day).Where(x=>x.ValuteID == id);

            return currencies.Where(x => x.Day.Date == time.Date).FirstOrDefault();
        }

        public PagedList<DayModel> GetCurrencies(DateTime time, int pageID, int elementsOnPage)
        {
            var result = DayContext.Days.Include(x => x.Currencies).FirstOrDefault(x => x.Date.Day == time.Day);

            if (result == null)
            {
                return null;
            }

            int total = result.Currencies.Count;
            result.Currencies = result.Currencies.Skip(pageID * elementsOnPage).Take(elementsOnPage).ToList();

            return new PagedList<DayModel>()
            {
                value = result,
                elementsOnPage = elementsOnPage,
                pageId = pageID,
                totalCount = total
            };
        }
    }
}
