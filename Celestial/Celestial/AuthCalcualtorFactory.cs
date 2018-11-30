using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celestial
{
    public static class AuthCalcualtorFactory
    {

        public static IKernel Kernel { set; get; }


        public static IAuthCalcualtor Get()
        {
            return Kernel.Get<AuthCalculator>();
        }
    }
}
