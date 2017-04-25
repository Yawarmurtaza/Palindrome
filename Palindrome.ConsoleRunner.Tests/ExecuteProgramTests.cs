using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Palindrome.Core;
using Palindrome.Core.Model;

namespace Palindrome.ConsoleRunner.Tests
{
    [TestClass]
    public class ExecuteProgramTests
    {

        private Mock<IPalindromeFinder> mockPalindrome;


        [TestInitialize]
        public void Setup()
        {
            this.mockPalindrome = new Mock<IPalindromeFinder>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.mockPalindrome = null; 
        }

        [TestMethod]
        public void PrintPalindromes_Should_Print_Palindromes()
        {
            //
            // Arrange.
            //

            const string InputString = "ABABBXXZAFFAZXXCXOXdXOX";
            const int NumberOfPalindromes = 4;
            
            this.mockPalindrome = new Mock<IPalindromeFinder>();

            IEnumerable<string> palindromesToReturn = new List<string>() { "ABA", "XXZAFFAZXX", "XOX", "XdX" };

            this.mockPalindrome.Setup(pal => pal.GetLongestPalindromes(InputString, NumberOfPalindromes)).Returns(palindromesToReturn);

            ExecuteProgram runner = new ExecuteProgram(this.mockPalindrome.Object);

            //
            // Act.
            //

            IEnumerable<PalindromeModel> result = runner.FindPalindromes(InputString, NumberOfPalindromes);

            //
            // Assert.
            //

            Assert.AreEqual(result.Count(), NumberOfPalindromes);

            foreach (string palindrome in palindromesToReturn)
            {
                Assert.IsTrue(result.Any(p => p.Text == palindrome));
            }
        }

        [TestMethod]
        public void PrintPalindromes_Should_Return_No_Palindrome_When_None_Exists()
        {
            //
            // Arrange.
            //

            const string InputString = "ABABBXXZAFFAZXXCXOXdXOX";
            const int NumberOfPalindromes = 4;

            this.mockPalindrome = new Mock<IPalindromeFinder>();
            
            this.mockPalindrome.Setup(pal => pal.GetLongestPalindromes(InputString, NumberOfPalindromes)).Returns(new List<string>());

            ExecuteProgram runner = new ExecuteProgram(this.mockPalindrome.Object);

            //
            // Act.
            //
            IEnumerable<PalindromeModel> result = runner.FindPalindromes(InputString, NumberOfPalindromes);

            //
            // Assert.
            //

            Assert.AreEqual(result.Count(), 0);
        }


    }
}