using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyPairs.Exeptions
{
    [Serializable]
    public class CurrencyPairNotFoundException : Exception
    {
        public CurrencyPairNotFoundException() { }
        public CurrencyPairNotFoundException(string message) : base(message) { }
        public CurrencyPairNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected CurrencyPairNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
