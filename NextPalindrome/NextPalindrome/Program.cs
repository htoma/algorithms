using System;
using System.Collections.Generic;

namespace NextPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10000000; i++)
            {
                var palindrome = GetNextPalindrome(i);
                if (!isPalindrome(palindrome))
                {
                    Console.WriteLine("Not palindrome {0}", palindrome);
                    break;
                }

                //Console.WriteLine("Palindrome for {0} is {1}", i, palindrome);
            }
        }

        public static int GetNextPalindrome(int n)
        {
            if (isPalindrome(n))
            {
                return n;
            }

            // walk the number
            // if the left side digit is always bigger or equal than the corresponding digit
            // then no need to updat the left side, only the right one
            List<int> digits = getDigits(n);
            
            // consider the half, too, in case the number of elements is even
            int half = digits.Count / 2 - (digits.Count % 2 == 0 ? 1 : 0);

            bool updateLeftPart = false;
            for (int i = 0; i <= half; i++)
            {
                if (digits[i] < digits[digits.Count - i - 1])
                {
                    updateLeftPart = true;
                    break;
                }
            }

            // note: could have avoided restoring everything
            // but keeping track of positions to be updated
            if (!updateLeftPart)
            {
                restoreSymmetry(digits, half);
                return buildNumberFromDigits(digits);
            }

            // hard part, will have to increment the middle
            // but if middle is 9, need to continue to increment at left
            // maybe even set a new digit at the beginning, 1 -> 1000...001
            for (int i = half; i >= 0; i--)
            {
                digits[i]++;
                
                if (digits[i] < 10)
                {
                    break;
                }

                digits[i] = 0;

            }

            // could build palindrome at this step
            // since number was updated
            restoreSymmetry(digits, half);
            return buildNumberFromDigits(digits);
        }

        private static int buildNumberFromDigits(IEnumerable<int> digits)
        {
            int n = 0;
            foreach (int digit in digits)
            {
                n *= 10;
                n += digit;
            }
            return n;
        }

        private static void restoreSymmetry(List<int> digits, int half)
        {
            for (int i = 0; i <= half; i++)
            {
                digits[digits.Count - i - 1] = digits[i];
            }
        }

        private static bool isPalindrome(int n)
        {
            if (n < 0)
            {
                return false;
            }

            if (n < 10)
            {
                return true;
            }

            List<int> digits = getDigits(n);
            int half = digits.Count / 2 - 1;

            for (int i = 0; i <= half; i++)
            {
                if (digits[i] != digits[digits.Count - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static List<int> getDigits(int n)
        {
            var digits = new List<int>();
            while (n > 0)
            {
                digits.Insert(0, n % 10);
                n /= 10;
            }
            return digits;
        } 
    }
}
