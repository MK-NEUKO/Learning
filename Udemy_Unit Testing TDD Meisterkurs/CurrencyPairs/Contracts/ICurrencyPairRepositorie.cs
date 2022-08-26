using CurrencyPairs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyPairs.Contracts
{
    public interface ICurrencyPairRepositorie
    {
        CurrencyPair? GetCurrencyPair(string currencyCode1, string currencyCode2); 
    }
}
