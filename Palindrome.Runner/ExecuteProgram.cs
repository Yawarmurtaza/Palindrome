using System;
using System.Collections.Generic;

using Palindrome.Core;
using Palindrome.Core.Model;

namespace Palindrome.ConsoleRunner
{
    public class ExecuteProgram
    {
        private readonly IPalindromeFinder palindromeFinder;
        public ExecuteProgram(IPalindromeFinder palinFinder)
        {
            this.palindromeFinder = palinFinder;
        }


        public IEnumerable<PalindromeModel> FindPalindromes(string inputText, int numberOfPalindromes)
        {
            IEnumerable<string> palindromsText = this.palindromeFinder.GetLongestPalindromes(inputText, numberOfPalindromes);

            IList<PalindromeModel> palindroms = new List<PalindromeModel>(numberOfPalindromes);

            foreach (string nextPalindrome in palindromsText)
            {
                PalindromeModel model = new PalindromeModel
                {
                    StartingIndex = inputText.GetStartingIndex(nextPalindrome),
                    Text = nextPalindrome,
                    Length = nextPalindrome.Length
                };
                palindroms.Add(model);
            }

            return palindroms;
        }
    }
}