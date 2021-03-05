using CurrencyAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyAPI.Repository
{
    public interface ICurrencyRepository : IRepository<DayModel>
    {
        DayModel GetCurrencies(DateTime time);

        PagedList<DayModel> GetCurrencies(DateTime time, int pageID, int elementOnPage);

        CurrencyModel GetCurrency(string id, DateTime time);
    }
}
