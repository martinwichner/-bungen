using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChainCalculationTests
{
    [TestClass]
    public class ExampleChainCalculation
    {
        [DataRow("3 * 3 * 3 * 3", 81)]
        [DataRow("3  ",int.MinValue)]
        [DataTestMethod]
        public void ChainCalculation(string input, int expected)
        {
            var chainCalcuator = new ChainCalculation.Implementations.ExampleChainCalculation();
            var result = chainCalcuator.Calculate(input);
            Assert.AreEqual(expected, result);
        }
    }
}
