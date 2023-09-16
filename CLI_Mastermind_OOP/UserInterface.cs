using System;

namespace CLI_Mastermind_OOP
{
    public static class UserInterface
    {
        internal static Program UserInterfaceImport
        {
            get => default;
            set
            {
            }
        }

        internal static Program UserInterfaceImports
        {
            get => default;
            set
            {
            }
        }

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
                    Console.ForegroundColor = ConsoleColor.Red;
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ResetColor();
                }
            }

            return guessCount;
        }

        public static int[]? GetUserGuess(int codeLength)
        {
            Console.WriteLine($"Enter your guess for the secret code on one line separated by spaces (length should be {codeLength}):");
            string[] input = Console.ReadLine().Split(' ');

            if (input.Length != codeLength)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Invalid input. Please enter a guess with a length of {codeLength}.");
                Console.ResetColor();
                return null;
            }

            int[] userGuess = new int[codeLength];
            bool validInput = true;

            for (int i = 0; i < codeLength; i++)
            {
                if (!int.TryParse(input[i], out userGuess[i]) || userGuess[i] < 1 || userGuess[i] > 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid input at position {i + 1}. Please enter a number between 1 and 8.");
                    Console.ResetColor();
                    validInput = false;
                    break;
                }
            }

            return validInput ? userGuess : null;
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                    Console.ResetColor();
                }
            }

            return false;
        }

    }
}
