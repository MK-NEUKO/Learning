using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyPairs.Contracts
{
    public interface ILogerWrapper
    {
        void LogCurrencyPairRequested(string currencyCode1, string currencyCode2);
    }
}
