using System;
using System.Collections.Generic;

using Palindrome.Core;
using Palindrome.Core.Model;

namespace Palindrome.ConsoleRunner
{
    /*
     *  Write an application that finds the 3 longest unique palindromes in any supplied string. For the 3 longest 
        palindromes, report the palindrome, start index and length, in descending order of length. 

        Example Output 
        Given the input string: sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop , the output should be: 
        Text: hijkllkjih, Index: 23, Length: 10 
        Text: defggfed, Index: 13, Length: 8 
        Text: abccba, Index: 5 Length: 6 

     */
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = "sqrrqsqrrqabccbatudefggfedvwhijkllkjihxymnnmzpopabccbatudefggfedvwhijklsqrrqabccbatudefggfedvwhijkllkjihxymnnmzpoplkjihxymnnmzsqrrqabccbatudefggfedvwhijkllkjihxymnnmzpoppopsqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            //string inputText  = "iTopiNonAvevanoNipoti";
            //string inputText = "AABCBAAB";
            //string inputText = "AABCBAA";
            int numberOfPalindromes = 3;

            ExecuteProgram runner = new ExecuteProgram(new PalindromeFinderV2()); // IoC can be used to resolve the dependency.
            IEnumerable<PalindromeModel> palindromes = runner.PrintPalindromes(inputText, numberOfPalindromes);

            foreach (PalindromeModel palindrome in palindromes)
            {
                Console.WriteLine($"Text: {palindrome.Text}, Index: {palindrome.StartingIndex}, Length: {palindrome.Length}");
            }

            Console.WriteLine("Press <Enter> to exit.");
            Console.ReadLine();

        }
    }
}
