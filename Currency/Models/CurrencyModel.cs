using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyAPI.Models
{
    public class CurrencyModel
    {
        public DateTime DayCurrencyID { get; set; }

        public string ValuteID { get; set; }

        public int NumCode { get; set; }

        public string CharCode { get; set; }

        public int Nominal { get; set; }

        public string Name { get; set; }

        public float Value { get; set; }

        public virtual DayModel Day { get; set; }
    }
}
