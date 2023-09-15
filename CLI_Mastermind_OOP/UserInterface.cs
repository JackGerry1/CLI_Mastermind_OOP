using System;

namespace CLI_Mastermind_OOP
{
    public static class UserInterface
    {
        public static int GetCodeLength()
        {
            int codeLength = 0;
            bool success = false;

            while (!success)
            {
                Console.WriteLine("Enter the desired code length:");
                success = int.TryParse(Console.ReadLine(), out codeLength);
                if (!success || codeLength < 1)
                {
                    success = false;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            return codeLength;
        }

        public static int GetGuessCount()
        {
            int guessCount = 0;
            bool success = false;

            while (!success)
            {
                Console.WriteLine("Enter the number of guesses you would like to have:");
                success = int.TryParse(Console.ReadLine(), out guessCount);
                if (!success || guessCount < 1)
                {
                    success = false;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            return guessCount;
        }

        public static int[] GetUserGuess(int codeLength)
        {
            Console.WriteLine($"Enter your guess for the secret code on one line separated by spaces (length should be {codeLength}):");
            string[] input = Console.ReadLine().Split(' ');

            int[] userGuess = Array.ConvertAll(input, int.Parse);

            return userGuess.Length == codeLength ? userGuess : null;
        }

        public static bool PlayAgain()
        {
            bool validResponse = false;

            while (!validResponse)
            {
                Console.Write("\nDo you want to play again? (Y/N): ");
                string playAgain = Console.ReadLine().ToLower();
                if (playAgain == "y" || playAgain == "yes")
                {
                    return true;
                }
                else if (playAgain == "n" || playAgain == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                }
            }

            return false;
        }

    }
}
