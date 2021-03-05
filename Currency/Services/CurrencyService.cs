using CurrencyAPI.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork unitOfWork;

        public CurrencyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public CurrencyModel GetCurrency(DateTime? time, string id)
        {
            if (!time.HasValue)
            {
                time = DateTime.UtcNow;
            }

            return unitOfWork.Days.GetCurrency(id, time.Value);
        }

        public PagedList<DayModel> GetCurrenciesPagination(DateTime? time, int? pageId, int elementsOnPage)
        {
            if (!time.HasValue)
            {
                time = DateTime.UtcNow;
            }

            if (!pageId.HasValue)
            {
                pageId = 0;
            }

            var result = unitOfWork.Days.GetCurrencies(time.Value, pageId.Value, elementsOnPage);

            return result;
        }

        public void Add(DayModel newModel)
        {
            unitOfWork.Days.Add(newModel);
            unitOfWork.SaveChanges();
        }
    }
}
