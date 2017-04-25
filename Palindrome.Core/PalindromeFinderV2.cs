using System.Collections.Generic;
using System.Linq;

namespace Palindrome.Core
{
    public class PalindromeFinderV2 : IPalindromeFinder
    {
        public IEnumerable<string> GetLongestPalindromes(string inputText, int numberOfPalindroms = 1)
        {
            // validate the parameteres ....

            List<string> evenPalindroms = this.GetEvenPalindromes(inputText, numberOfPalindroms);
            List<string> oddPalindroms = this.GetOddPalindromes(inputText, numberOfPalindroms);
            oddPalindroms.AddRange(evenPalindroms);
            return oddPalindroms.Distinct().OrderByDescending(item => item.Length).Take(numberOfPalindroms);
        }

        private List<string> GetOddPalindromes(string inputText, int numberOfPalindrom)
        {
            List<string> palindroms = new List<string>();
            for (int count = 0; count < numberOfPalindrom; count++)
            {
                string result = this.GetOddLongestPalindrome(inputText);
                if (string.IsNullOrEmpty(result))
                {
                    break;
                }

                palindroms.Add(result);
                inputText = inputText.Replace(result, string.Empty);
            }

            return palindroms;
        }

        private List<string> GetEvenPalindromes(string inputText, int numberOfPalindrom)
        {
            List<string> palindroms = new List<string>();

            for (int count = 0; count < numberOfPalindrom; count++)
            {
                string result = this.GetEvenLongestPalindrome(inputText);
                if (string.IsNullOrEmpty(result))
                {
                    break;
                }

                palindroms.Add(result);
                inputText = inputText.Replace(result, string.Empty);
            }

            return palindroms;
        }


        private string GetEvenLongestPalindrome(string inputText)
        {
            int rightIndex;
            int leftIndex;
            string palindrome = string.Empty;
            for (int i = 1; i < inputText.Length - 1; i++)
            {
                leftIndex = i - 1;
                rightIndex = i;
                while (leftIndex >= 0 && rightIndex < inputText.Length)
                {
                    char leftChar = inputText[leftIndex];
                    char rightChar = inputText[rightIndex];
                    
                    if (leftChar != rightChar)
                    {
                        break;
                    }

                    string matchFound = inputText.Substring(leftIndex, rightIndex - leftIndex + 1);

                    if (matchFound.Length > palindrome.Length)
                    {
                        palindrome = matchFound;
                    }

                    // Start expanding...
                    leftIndex--;
                    rightIndex++;
                }
            }

            return palindrome;

        }

        private string GetOddLongestPalindrome(string input)
        {
            int rightIndex, leftIndex;
            var palindrome = string.Empty;

            for (int i = 1; i < input.Length - 1; i++)
            {
                leftIndex = i - 1;
                rightIndex = i + 1;

                while (leftIndex >= 0 && rightIndex < input.Length)
                {
                    char leftChar = input[leftIndex];
                    char rightChar = input[rightIndex];

                    if (leftChar != rightChar)
                    {
                        break;
                    }

                    string matchFound = input.Substring(leftIndex, rightIndex - leftIndex + 1); // found the bare minumum pali word i.e. 3 chars long pali word.

                    // check if this is the longest so far....
                    if (matchFound.Length > palindrome.Length)
                    {
                        palindrome = matchFound;
                    }

                    // we have found a palindrom now expand the left and right index to
                    // find if this is any longer than just 3 characters...
                    leftIndex--;
                    rightIndex++;
                }
            }
            return palindrome;
        }
    }
}