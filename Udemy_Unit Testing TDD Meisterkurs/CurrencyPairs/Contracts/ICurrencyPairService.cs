using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyPairs.Contracts
{
    public interface ICurrencyPairService
    {
        double GetRate(string currencyCode1, string currencyCode2);
    }
}
