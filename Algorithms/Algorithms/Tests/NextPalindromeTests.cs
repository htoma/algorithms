using System;
using Algorithms.Sources;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class NextPalindromeTests
    {
        [Test]
        public void Test()
        {
            for (int i = 0; i < 100000; i++)
            {
                var palindrome = NextPalindrome.GetNextPalindrome(i);
                if (!NextPalindrome.IsPalindrome(palindrome))
                {
                    Console.WriteLine("Not palindrome {0}", palindrome);
                    break;
                }

                //Console.WriteLine("Palindrome for {0} is {1}", i, palindrome);
            }
        }
    }
}