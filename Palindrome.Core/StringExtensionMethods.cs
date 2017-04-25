using System;

namespace Palindrome.Core
{
    public static class StringExtensionMethods
    {
        public static int GetStartingIndex(this string inputText, string palindrome)
        {
            int startingIndex = inputText.IndexOf(palindrome, StringComparison.CurrentCultureIgnoreCase);
            return startingIndex;
        }
    }
}