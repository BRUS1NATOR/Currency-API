using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyAPI.Models
{
    public class DayModel
    {
        public DayModel()
        {
            Currencies = new HashSet<CurrencyModel>();
        }

        public DateTime Date { get; set; }

        public virtual ICollection<CurrencyModel> Currencies { get; set; }

    }
}
