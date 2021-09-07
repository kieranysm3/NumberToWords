using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing.UnitTests
{
    [TestClass]
    public class CurrencyToWordLibraryTests
    {
        [TestMethod]
        public void CurrencyConversion_ValueOverLimit_ReturnsFalse()
        {
            //Arrange
            decimal testobject = new decimal(1000);
            //Act
            //string result = CurrencyToWordLibrary.CurrencyConverter.CurrencyConversion(testobject);
            //Assert
            Assert.AreEqual(result, "sorry your number is too big")
        }
    }
}
