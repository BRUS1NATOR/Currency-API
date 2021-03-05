using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyAPI.Services
{
    public interface ICustomParser<T>
    {
        public T TryParseURI(string uri);
        public T TryParseString(string s);
    }
}
