using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Celestial
{
    public class AuthCalculator: IAuthCalcualtor
    {

        public const int MultiplicationOffset = 10;

        public const string invalidLoginMessage = "Invalid Login Attempt";
        private ICalculator Calculator { get; set; }
        private ILogger Logger { get; set; }

        public IAuthenticator Authenticator { get; set; }


        public AuthCalculator(ICalculator calculator, IAuthenticator authenticator, ILogger logger)
        {
            this.Calculator = calculator;
            this.Logger = logger;
            this.Authenticator = authenticator;
        }

        public int Add(string userName, string password, int first, int second)
        {
            var isAuthenticated = Authenticator.IsAuthenticated(userName, password);
            int result = 0;

            if (!isAuthenticated)
            {
                Logger.Log(userName, invalidLoginMessage);
            }

            result = Calculator.Add(first, second);
            Logger.Log(userName, first, second, result);

            return result;
        }

        public int Sub(string userName, string password, int first, int second)
        {
            int result = 0;
            try
            {
                var isAuthenticated = Authenticator.IsAuthenticated(userName, password);
                if (!isAuthenticated)
                {
                    Logger.Log(userName, invalidLoginMessage);
                }

                result = Calculator.Sub(first, second);
                Logger.Log(userName, first, second, result);
                return result;
            }
            catch
            {
                return int.MinValue;
            }
        }

        public int Mul(string userName, string password, int first, int second)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("userName");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password");

            var isAuthenticated = Authenticator.IsAuthenticated(userName, password);
            int result = 0;

            if (!isAuthenticated)
            {
                Logger.Log(userName, invalidLoginMessage);
            }

            result = Calculator.Mul(first + MultiplicationOffset, second);
            Logger.Log(userName, first, second, result);

            return result;
        }

        public int Div(string userName, string password, int first, int second)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("userName");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password");

            if (second == 0)
                throw new DivideByZeroException("second number(denominator) can't be zero");

           // var isAuthenticated = authenticator.IsAuthenticated(userName, password);
            int result = 0;

            result = Calculator.Div(first, second);
            Logger.Log(userName, first, second, result);

            return result;
        }
    }
}
