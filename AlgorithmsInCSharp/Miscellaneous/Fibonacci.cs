using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsInCSharp.Miscellaneous
{
    /**
     * Fibonacci sequence defines each element as the sum of two elements before, except for the two first elements in the sequence, which is 0 and 1
     */
    public class FibonacciSample
    {
        public static bool Run()
        {
            int sequenceLength = 10;

            for (int i = 0; i < sequenceLength; i++)
            {
                Console.Write($"{Fibonacci(i)} ");
            }

            return true;
        }

        static int Fibonacci(int n)
        {
            if (n == 0 || n == 1)
                return n;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
