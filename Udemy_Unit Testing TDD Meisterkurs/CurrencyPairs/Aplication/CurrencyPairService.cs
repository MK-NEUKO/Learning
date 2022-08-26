using CurrencyPairs.Contracts;
using CurrencyPairs.Exeptions;

namespace CurrencyPairs.Aplication
{
    public class CurrencyPairService : ICurrencyPairService
    {
        public ICurrencyPairRepositorie CurrencyPairRepositorie { get; }

        public CurrencyPairService(ICurrencyPairRepositorie currencyPairRepositorie)
        {
            CurrencyPairRepositorie = currencyPairRepositorie;
        }

        public double GetRate(string currencyCode1, string currencyCode2)
        {
            var currencyPair = CurrencyPairRepositorie.GetCurrencyPair(currencyCode1, currencyCode2);

            if (currencyPair == null)
            {
                throw new CurrencyPairNotFoundException();
            }

            return currencyPair.Rate;
        }
    }
}
