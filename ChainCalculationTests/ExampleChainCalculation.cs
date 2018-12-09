using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChainCalculationTests
{
    [TestClass]
    public class ExampleChainCalculation
    {
        [DataRow("3 * 3 * 3 * 3", 81)]
        [DataRow("3  ",int.MinValue)]
        [DataRow("1 + 2 * 3 - 4 / 2", 2)]
        [DataTestMethod]
        public void ChainCalculation(string input, int expected)
        {
            var chainCalcuator = new ChainCalculation.Implementations.ExampleChainCalculation();
            var result = chainCalcuator.Calculate(input);
            Assert.AreEqual(expected, result);
        }
    }
}
