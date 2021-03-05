using CurrencyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI.Services
{
    public interface ICurrencyService
    {
        PagedList<DayModel> GetCurrenciesPagination(DateTime? time, int? pageId, int elementsOnPage);

        CurrencyModel GetCurrency(DateTime? time, string id);

        void Add(DayModel newModel);
    }
}
