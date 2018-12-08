using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChainCalculation.Implementations
{
    public class ExampleChainCalculation : IChainCalculation
    {
        public int Calculate(string input)
        {
            if (IsValid(input))
            {
                var splittedInput = input.Split(' ');
                var result = int.Parse(splittedInput[0]);
                for (int i = 1; i < splittedInput.Length; i += 2)
                {
                    switch (splittedInput[i])
                    {
                        case "+":
                            result += int.Parse(splittedInput[i + 1]);
                            break;
                        case "-":
                            result -= int.Parse(splittedInput[i + 1]);
                            break;
                        case "*":
                            result *= int.Parse(splittedInput[i + 1]);
                            break;
                        case "/":
                            result /= int.Parse(splittedInput[i + 1]);
                            break;
                    }
                }
                return result;
            }
            else
            {
                return int.MinValue;
            }
        }

        private static bool IsValid(string input)
        {
            return Regex.IsMatch(input, @"^\d+( [+\-*/] \d+)*$");
        }
    }
}
