using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactorialTests
{
    [TestClass]
    public class TestFactorial
    {
        [DataRow(1, 1, true)]
        [DataRow(1, 1, false)]
        [DataRow(1, 1, true)]
        [DataRow(-1, 1, false)]
        [DataRow(7, 5040, true)]
        [DataRow(7, 5040, false)]
        [DataRow(6, 720, true)]
        [DataTestMethod]
        public void Factorial(int n, int expected, bool useRecursion)
        {
            var factorial = new Factorial.Implementations.TestFactorial(useRecursion);
            var result = factorial.Factorial(n);
            Assert.AreEqual(expected, result);
        }

        [DataRow(1, 1, true)]
        [DataRow(1, 1, false)]
        [DataRow(1, 1, true)]
        [DataRow(-1, 1, false)]
        [DataRow(7, 105, true)]
        [DataRow(7, 105, false)]
        [DataRow(8, 105, true)]
        [DataRow(8, 105, false)]
        [DataTestMethod]
        public void UnevenFactorial(int n, int expected, bool useRecursion)
        {
            var factorial = new Factorial.Implementations.TestFactorial(useRecursion);
            var result = factorial.UnevenFactorial(n);
            Assert.AreEqual(expected, result);
        }

        [DataRow(1, 1, true)]
        [DataRow(1, 1, false)]
        [DataRow(1, 1, true)]
        [DataRow(-1, 1, false)]
        [DataRow(7, 25401600, true)]
        [DataRow(7, 25401600, false)]
        [DataTestMethod]
        public void SquareFactorial(int n, int expected, bool useRecursion)
        {
            var factorial = new Factorial.Implementations.TestFactorial(useRecursion);
            var result = factorial.SquareFactorial(n);
            Assert.AreEqual(expected, result);
        }

    }
}
