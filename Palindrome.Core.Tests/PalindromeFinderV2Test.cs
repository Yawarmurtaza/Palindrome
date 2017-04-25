using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome.Core.Model;

namespace Palindrome.Core.Tests
{
    [TestClass]
    public class PalindromeFinderV2Test
    {

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(3)]
        public void GetLongestPalindromes_Should_Return_Given_Number_Of_Longest_Palindrome(int numberOfPalindromes)
        {
            //
            // Arrange.
            //
            
            const string inputText = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";

            IPalindromeFinder finder = new PalindromeFinderV2();

            //
            // Act.
            //

            IEnumerable<string>  result = finder.GetLongestPalindromes(inputText, numberOfPalindromes);

            //
            // Assert.
            //

            Assert.AreEqual(result.Count(), numberOfPalindromes);
        }

        [DataTestMethod]
        [DataRow("asd;jhsdlkfjalkdjyyyaawaayyyasdjflkasjdflasjdfl;", "yyyaawaayyy")]
        [DataRow("asd;jhsdlkfjalkdjyyyaawaaalllmmmlllaaa;", "aaalllmmmlllaaa")]
        [DataRow("asiiiimmmmmaaaammmmmiiiid;jhsdlkfjalksdjflkasjdflasjdfl;", "iiIImmMMMaaAAmmmmmiiii")]
        public void GetLongestPalindromes_Should_Find_Palindromes_From_Given_Text(string text, string matchingPalindrome)
        {
            //
            // Arrange.
            //

            IPalindromeFinder finder = new PalindromeFinderV2();

            //
            // Act.
            //

            IEnumerable<string> result = finder.GetLongestPalindromes(text);

            //
            // Assert.
            //

            Assert.AreEqual(result.FirstOrDefault().ToLower(), matchingPalindrome.ToLower());
        }
    }
}