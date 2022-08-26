using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyPairs.Model
{
    public class CurrencyPair
    {
        public int Id { get; set; }
        public string CurrencyCode1 { get; set; }
        public string CurrencyCode2 { get; set; }
        public double Rate { get; set; }
    }
}
