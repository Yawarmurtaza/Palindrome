using System.Collections.Generic;

namespace Palindrome.Core
{
	// This interface is responsible for finding the palindromes.
    public interface IPalindromeFinder
    {
		// Responsible to return then longest Palindromes from input text.
        IEnumerable<string> GetLongestPalindromes(string inputText, int numberOfPalindromes = 1);
    }
}