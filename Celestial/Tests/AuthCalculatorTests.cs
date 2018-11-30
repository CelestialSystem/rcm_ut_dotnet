using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Celestial.Tests
{
    [TestClass]
    public class AuthCalculatorTests
    {
        private IAuthCalcualtor testObject { get; set; }
        private TestingContext context;

        [TestInitialize]
        public void Setup()
        {
            context = new TestingContext();
            testObject = context.GetTestObject();
        }


        [TestMethod]
        public void Adding1And2ShouldReutnr3()
        {
            string userName = "U1";
            string password = "P1";
            int p1 = 1;
            int p2 = 2;

            //Arrange
            context.Authenticator.Setup(auth => auth.IsAuthenticated(userName, password)).Returns(true);
            context.Calculator.Setup(calc => calc.Add(p1, p2)).Returns(p1 + p2);
            context.Logger.Setup(logger => logger.Log(userName, p1, p2, p1 + p2));

            //Act
            var result = testObject.Add(userName, password, p1, p2);


            //Assert
            Assert.AreEqual(p1 + p2, result);
            context.Authenticator.VerifyAll();
            context.Calculator.VerifyAll();
            context.Logger.VerifyAll();
        }

        [TestMethod]
        public void PassingNULLUserNamePasswordReturnsIntMinValue()
        {
            int p1 = 1;
            int p2 = 2;

            //Arrange
            context.Authenticator.Setup(auth => auth.IsAuthenticated(null, null)).Throws(new Exception());

            //Act
            var result = testObject.Sub(null, null, p1, p2);

            //Assert
            Assert.AreEqual(int.MinValue, result);
            context.Authenticator.VerifyAll();
        }



        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroThrowsDividedByZeroException()
        {
             string userName = "U1";
             string password = "P1";
            testObject.Div(userName, password, 1, 0);

        }




        [TestCleanup]
        public void Cleanup()
        {
            context = null;
            testObject = null;
        }
    }
}
