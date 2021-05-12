using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsInCSharp.Miscellaneous
{
    /*
    * Palindrome is a word or expression which can be read the same backward as forward. Examples: Anna, Civic, Madam, Racecar.
    */
    public class PalindromeSample
    {
        public static bool Run()
        {
            string word = "Racecar";

            Console.WriteLine($"Check if '{word}' is a palindrome:");
            Console.Write($"Result: {(IsPalindrome(word) ? "Yes" : "No")}");

            return true;
        }

        static bool IsPalindrome(string word)
        {
            int length = word.Length;
            string wordAux = word.ToUpper();

            for (int i = 0; i < length / 2; i++)
            {
                if (wordAux[i] != wordAux[length - i - 1])
                    return false;
            }

            return true;
        }

        static bool IsPalindrome2(string word)
        {
            string wordAux = word.ToUpper();
            string firstHalf = wordAux.Substring(0, wordAux.Length / 2);
            string secondHalf = wordAux.Substring(wordAux.Length / 2 + 1);

            char[] secondHalfArr = secondHalf.ToCharArray();

            Array.Reverse(secondHalfArr);

            return string.Compare(firstHalf, new String(secondHalfArr), true) == 0;
        }

        //use System.Linq to be able to use "SequenceEqual()" extension method
        static bool IsPalindrome3(string word)
        {
            string wordAux = word.ToUpper();
            return wordAux.SequenceEqual(wordAux.Reverse());
        }


    }
}
