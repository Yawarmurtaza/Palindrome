using System.Collections.Generic;

namespace Palindrome.Core
{
    public interface IPalindromeFinder
    {
        IEnumerable<string> GetLongestPalindromes(string inputText, int numberOfPalindromes = 1);
    }
}