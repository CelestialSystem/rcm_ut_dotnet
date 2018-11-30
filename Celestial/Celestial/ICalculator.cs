using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celestial
{
    public interface ICalculator
    {
        int Add(int first, int second);
        int Sub(int first, int second);
        int Mul(int first, int second);
        int Div(int first, int second);
    }
}
