using CurrencyAPI.Models;
using CurrencyAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleController
{
    /// <summary>
    /// Консольный контроллер
    /// </summary>
    public class ParseController
    {
        private readonly ICustomParser<DayModel> parser;
        private readonly ICurrencyService currencyService;

        public ParseController(ICustomParser<DayModel> parser, ICurrencyService currencyService)
        {
            this.parser = parser;
            this.currencyService = currencyService;
        }

        public DayModel ParseURI(string uri)
        {
            Console.WriteLine($"Connecting to {uri} ");

            DayModel newModel = parser.TryParseURI(uri);
            return newModel;
        }

        public DayModel ParseString(string data)
        {
            Console.WriteLine("Trying to parse data");

            DayModel newModel = parser.TryParseString(data);
            return newModel;
        }

        public bool Save(DayModel newModel)
        {
            if (newModel != null)
            {
                Console.WriteLine("Date - " + newModel.Date);
                currencyService.Add(newModel);
                Console.WriteLine("Saved!");
                return true;
            }
            return false;
        }
    }
}
