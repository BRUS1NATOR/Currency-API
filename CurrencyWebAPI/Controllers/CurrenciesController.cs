using CurrencyAPI;
using CurrencyAPI.Models;
using CurrencyAPI.Repository;
using CurrencyAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CurrencyWebAPI
{
    /// <summary>
    /// Веб-контроллер
    /// </summary>
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyService currencyService;
        private readonly ILogger<CurrenciesController> logger;

        public CurrenciesController(ILogger<CurrenciesController> logger, ICurrencyService currency)
        {
            this.logger = logger;
            currencyService = currency;
        }

        [Authorize]
        [HttpGet("currencies")]
        public PagedList<DayModel> GetCurrencies(DateTime? date, int? pageId)
        {
            return currencyService.GetCurrenciesPagination(date, pageId, 10);
        }

        // [Authorize(Roles = "admin")]
        [Authorize]
        [HttpGet("currency/{id}")]
        public CurrencyModel GetCurrency(string id, DateTime? date)
        {
            return currencyService.GetCurrency(date, id);
        }
    }
}
