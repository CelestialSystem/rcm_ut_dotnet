using Moq;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celestial.Tests
{
    public class TestingContext
    {
        private IKernel Kernel;
        public Mock<ICalculator> Calculator
        {
            get
            {
                return calculatorMock;
            }
        }

        public Mock<IAuthenticator> Authenticator
        {
            get
            {
                return authenticatorMock;
            }
        }

        public Mock<ILogger> Logger
        {
            get
            {
                return loggerMock;
            }
        }

        public IAuthCalcualtor GetTestObject()
        {
            return AuthCalcualtorFactory.Get();
        }

        public TestingContext()
        {
            calculatorMock = new Mock<ICalculator>();
            authenticatorMock = new Mock<IAuthenticator>();
            loggerMock = new Mock<ILogger>();

            Kernel = new StandardKernel();
            Kernel.Bind<ICalculator>().ToConstant(calculatorMock.Object);
            Kernel.Bind<IAuthenticator>().ToConstant(authenticatorMock.Object);
            Kernel.Bind<ILogger>().ToConstant(loggerMock.Object);
            AuthCalcualtorFactory.Kernel = Kernel;
        }


        private Mock<ICalculator> calculatorMock;
        private Mock<IAuthenticator> authenticatorMock;
        private Mock<ILogger> loggerMock;
    }
}
