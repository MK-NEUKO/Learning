using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaptionHandling;
using ExcaptionHandling;

namespace ExcaptionHandling
{
    public class ExceptionThrower : IExceptionThrower
    {
        public void IThrowAnException()
        {
            throw new Exception("This is the Test - Exception");
        }
    }
}
