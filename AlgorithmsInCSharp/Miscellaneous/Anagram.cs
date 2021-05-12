using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsInCSharp.Miscellaneous
{
    /*
     * Anagram is a word or expression that uses exactly the same letters from another word or expression.
     */
    public class AnagramSample
    {
        public static bool Run()
        {
            string word1 = "listen";
            string word2 = "silent";

            Console.WriteLine($"Check if '{word1}' and '{word2}' are anagrams:");
            Console.WriteLine($"Result: {(IsAnagram(word1, word2) ? "Yes" : "No")}");

            return true;
        }

        static bool IsAnagram(string word1, string word2)
        {
            int[] lettersArray = new int[26];

            int index = 0;
            for (int i = 0; i < word1.Length; i++)
            {
                index = (int)word1[i] % 32;

                lettersArray[index]++;
            }

            for (int i = 0; i < word2.Length; i++)
            {
                index = (int)word2[i] % 32;

                if (lettersArray[index] == 0)
                    return false;

                lettersArray[index]--;
            }

            return Array.TrueForAll(lettersArray, (l) => l == 0);
        }

        //Another option that involves sorting the letters and comparing it.
        static bool IsAnagram2(string word1, string word2)
        {
            char[] w1 = word1.ToUpper().ToCharArray();
            char[] w2 = word2.ToUpper().ToCharArray();
            
            Array.Sort(w1);
            Array.Sort(w2);

            return new String(w1) == new String(w2);
        }
    }
}
