using CurrencyPairs.Contracts;
using CurrencyPairs.Exeptions;

namespace CurrencyPairs.Aplication
{
    public class CurrencyPairService : ICurrencyPairService
    {
        public ICurrencyPairRepositorie CurrencyPairRepositorie { get; }
        public ILogerWrapper LogerWrapper { get; }

        public CurrencyPairService(ICurrencyPairRepositorie currencyPairRepositorie, ILogerWrapper logerWrapper)
        {
            CurrencyPairRepositorie = currencyPairRepositorie;
            LogerWrapper = logerWrapper;
        }

        public double GetRate(string currencyCode1, string currencyCode2)
        {
            LogerWrapper.LogCurrencyPairRequested(currencyCode1, currencyCode2);
            var currencyPair = CurrencyPairRepositorie.GetCurrencyPair(currencyCode1, currencyCode2);

            if (currencyPair == null)
            {
                throw new CurrencyPairNotFoundException();
            }

            return currencyPair.Rate;
        }
    }
}
