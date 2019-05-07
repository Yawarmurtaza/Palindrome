using System.Collections.Generic;

namespace Palindrome.Core
{
    // Provides the operations that find palindromes from given input text.
    public interface IPalindromeFinder
    {
		// Responsible to return then longest Palindromes from input text.
        IEnumerable<string> GetLongestPalindromes(string inputText, int numberOfPalindromes = 1);
    }
}
