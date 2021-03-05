using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI.Models
{
    public class PagedList
    {
        public const int maxItems = 10;
    }

    public class PagedList<T> : PagedList
    {
        public T value;

        public int totalCount;
        public int elementsOnPage=10;
        public int pageId;

        public bool prevPage
        {
            get
            {
                if (pageId > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool nextPage
        {
            get
            {
                if ((pageId+1) * elementsOnPage < totalCount)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
