namespace ChainCalculation
{
    public interface IChainCalculation
    {
        /// <summary>
        /// Calculate input. Example input: "3 * 4 + 6 - 1"
        /// Start and end with a number.
        /// Between 2 numbers is one operator (+, -, *, /)
        /// Between one number and one operator is exactly one whitespace
        /// Calculation is from left to right
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        int Calculate(string input);
    }
}
