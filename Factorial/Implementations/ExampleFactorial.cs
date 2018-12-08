using System.Linq;

namespace Factorial.Implementations
{
    public class ExampleFactorial : IFactorial
    {
        public bool UseRecursion { get; set; }

        public ExampleFactorial(bool useRecursion)
        {
            UseRecursion = useRecursion;
        }

        public int Factorial(int n)
        {
            if (n < 1)
            {
                return 1;
            }

            return UseRecursion ? FactorialWithRecursion(n) : FactorialWithoutRecursion(n);
        }

        private static int FactorialWithRecursion(int n)
        {
            if (n <= 0)
            {
                return 1;
            }
            else
            {
                return n * FactorialWithRecursion(n - 1);
            }
        }

        private static int FactorialWithoutRecursion(int n)
        {
            return Enumerable.Range(1, n).Aggregate((current, next) => current * next);
        }

        public int UnevenFactorial(int n)
        {
            if (n < 1)
            {
                return 1;
            }

            return UseRecursion ? UnevenFactorialWithRecursion(n) : UnevenFactorialWithoutRecursion(n);
        }

        private static int UnevenFactorialWithRecursion(int n)
        {
            if (n <= 0)
            {
                return 1;
            }
            else
            {
                if (n % 2 == 0)
                {
                    n -= 1;
                }
                return n * UnevenFactorialWithRecursion(n - 2);
            }
        }

        private static int UnevenFactorialWithoutRecursion(int n)
        {
            return Enumerable.Range(1, n).Where(c => (c % 2 != 0)).Aggregate((current, next) => current * next);
        }

        public int SquareFactorial(int n)
        {
            if (n < 1)
            {
                return 1;
            }

            return UseRecursion ? SquareFactorialWithRecursion(n) : SquareFactorialWithoutRecursion(n);
        }

        private static int SquareFactorialWithRecursion(int n)
        {
            if (n <= 0)
            {
                return 1;
            }
            else
            {
                return (n * n) * SquareFactorialWithRecursion(n - 1);
            }
        }

        private static int SquareFactorialWithoutRecursion(int n)
        {
            return Enumerable.Range(1, n).Aggregate((current, next) => current * (next * next));
        }
    }
}