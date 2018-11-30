using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celestial
{
    public interface IAuthCalcualtor
    {
        int Add(string userName, string password, int first, int second);
        int Sub(string userName, string password, int first, int second);
        int Mul(string userName, string password, int first, int second);
        int Div(string userName, string password, int first, int second);
    }
}
