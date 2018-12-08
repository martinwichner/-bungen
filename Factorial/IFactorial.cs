namespace Factorial
{
    public interface IFactorial
    {
        /// <summary>
        /// <para>Factorial multiplies all numbers from 1 to n.</para>
        ///  <para>Factorial(0) = 1</para>
        ///  <para>Factorial(n) = 1 * 2 * 3 * ...* n-1 * n</para>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        int Factorial(int n);
        /// <summary>
        /// <para>UnevenFactorial multiplies all uneven numbers from 1 to n.</para>
        ///  <para>Factorial(8) = 1 * 3 * 5 * 7</para>
        ///  <para>Factorial(9) = 1 * 3 * 5 * 7 * 9</para>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        int UnevenFactorial(int n);
        /// <summary>
        /// <para>SquareFactorial multiplies all squares from 1 to n.</para>
        ///  <para>Factorial(n) = 1^2 * 2^2 * 3^2 * ... * (n-1)^2 * n^2</para>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        int SquareFactorial(int n);
    }
}
