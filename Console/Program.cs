using ConsoleController;
using CurrencyAPI;
using CurrencyAPI.Models;
using CurrencyAPI.Repository;
using CurrencyAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleConroller
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CurrenciesDbContext())
            {
                ParseController parser = new ParseController(new CBRParser(), new CurrencyService(new UnitOfWork(db)));
                DayModel data = parser.ParseURI("http://www.cbr.ru/scripts/XML_daily.asp");
                parser.Save(data);
            }
        }
    }
}
