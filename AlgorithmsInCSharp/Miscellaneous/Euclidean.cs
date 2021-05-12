using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsInCSharp.Miscellaneous
{
    /*
     * The Euclidean algorithm is a method to compute the GCD (Greatest Common Divisor) of two numbers, which is the largest number that divides both numbers without a remainder.  
     */
    public class Euclidean
    {
        public static bool Run()
        {
            int number1 = 30;
            int number2 = 75;

            Console.WriteLine($"GCD of ({number1}, {number2}) is : {GCD(number1, number2)}");
            Console.WriteLine($"GCD(not recursive) of ({number1}, {number2}) is : {GCDNotRecursive(number1, number2)}");

            return true;
        }

        static int GCD(int n1, int n2)
        {
            if (n1 == 0)
                return n2;

            return GCD(n2 % n1, n1);
        }

        static int GCDNotRecursive(int n1, int n2)
        {
            int result = n1;
            int temp;
            while(n2 % n1 != 0)
            {
                result = n2 % n1;

                temp = n1;
                n1 = n2 % n1;
                n2 = temp;
            }

            return result;
        }
    }
}
