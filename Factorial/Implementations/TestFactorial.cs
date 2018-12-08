namespace Factorial.Implementations
{
    public class TestFactorial : IFactorial
    {

        public TestFactorial(bool useRecursion)
        {
            
        }
        /// <summary>
        /// <para>Factorial multiplies all numbers from 1 to n.</para>
        /// <para>Factorial(0) = 1</para>
        /// <para>Factorial(n) = 1 * 2 * 3 * ...* n-1 * n</para>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Factorial(int n)
        {
            return 1;
        }

        /// <summary>
        /// <para>UnevenFactorial multiplies all uneven numbers from 1 to n.</para>
        /// <para>Factorial(8) = 1 * 3 * 5 * 7</para>
        /// <para>Factorial(9) = 1 * 3 * 5 * 7 * 9</para>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int UnevenFactorial(int n)
        {
            return 1;
        }

        /// <summary>
        /// <para>SquareFactorial multiplies all squares from 1 to n.</para>
        /// <para>Factorial(n) = 1^2 * 2^2 * 3^2 * ... * (n-1)^2 * n^2</para>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SquareFactorial(int n)
        {
            return 1;
        }
    }
}
