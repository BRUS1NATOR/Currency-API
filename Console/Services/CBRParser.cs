using CurrencyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CurrencyAPI.Services
{
    public class CBRParser : ICustomParser<DayModel>
    {
        public DayModel TryParseURI(string uri)
        {
            WebClient client = new WebClient();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            client.Encoding =  Encoding.GetEncoding("windows-1251");
            string cbrCurrencies = client.DownloadString(uri);

            return TryParseString(cbrCurrencies);
        }

        public DayModel TryParseString(string xml)
        {
            DayModel model = new DayModel();

            XDocument xDoc = XDocument.Parse(xml);

            model.Date = DateTime.Parse(xDoc.Element("ValCurs").Attribute("Date").Value);
            model.Currencies = Parse(xDoc.Element("ValCurs").Elements(), model);

            return model;
        }

        private ICollection<CurrencyModel> Parse(IEnumerable<XElement> currencyNodes, DayModel day)
        {
            List<CurrencyModel> models = new List<CurrencyModel>();

            foreach(var node in currencyNodes)
            {
                models.Add(new CurrencyModel
                {
                    ValuteID = node.Attribute("ID").Value,
                    NumCode = Convert.ToInt32(node.Element("NumCode").Value),
                    CharCode = node.Element("CharCode").Value,
                    Nominal = Convert.ToInt32(node.Element("Nominal").Value),
                    Name = node.Element("Name").Value,
                    Value = Convert.ToSingle(node.Element("Value").Value),
                    DayCurrencyID = day.Date,
                    Day = day
                });
            }

            return models;
        }
    }
}
