using System;
using System.CodeDom;
using System.Linq;

namespace Algorithms.Sources
{
    /*
     * Given the English alphabet, 'a' through 'z' (lowercase), 
     * and an imaginary onscreen keyboard with the letters laid out in 6 rows and 5 columns:
     * 
    a b c d e
    f g h i j
    k l m n o
    p q r s t
    u v w x y
    z
     * 
     * Using a remote control - (up - 'u', down 'd', left 'l', right 'r' and enter '!'), 
     * write a function that given a word will produce the sequence of key presses required to type out the word on the onscreen keyboard. The function should return the sequence string. 
     */
    public static class RemoteControl
    {
        private const int LENGTH = 5;
        public static void ShowMoves(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return;
            }
            if (word.Any(x => x < 'a' || x > 'z'))
            {
                return;
            }

            char current = 'a';
            foreach (char letter in word)
            {
                Tuple<int, int> moves = GetMoves(current, letter);
                Console.WriteLine("Moving from {0} to {1}", current, letter);
                if (moves.Item1 == 0 && moves.Item2 == 0)
                {
                    Console.WriteLine("No moves needed");
                }
                else
                {
                    if (moves.Item1 != 0)
                    {
                        Console.WriteLine(
                            "Move {0} {1} positions",
                            moves.Item1 > 0 ? "down" : "up",
                            Math.Abs(moves.Item1));
                    }
                    if (moves.Item2 != 0)
                    {
                        Console.WriteLine(
                            "Move {0} {1} positions",
                            moves.Item2 > 0 ? "right" : "left",
                            Math.Abs(moves.Item2));
                    }
                }
                current = letter;
            }
        }

        private static Tuple<int, int> GetMoves(char first, char second)
        {
            int dif = second - first;
            if (dif == 0)
            {
                return new Tuple<int, int>(0, 0);
            }

            int posFirst = first - 'a';
            int xFirst = posFirst / LENGTH;
            int yFirst = posFirst % LENGTH;

            int posSecond = second - 'a';
            int xSecond = posSecond / LENGTH;
            int ySecond = posSecond % LENGTH;

            return new Tuple<int, int>(xSecond - xFirst, ySecond - yFirst);
        } 
    }
}