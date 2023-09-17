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

            // Continue looping until a valid input is received
            while (!success)
            {
                Console.WriteLine("Enter the desired code length:");

                // Attempt to parse the user's input into an integer
                success = int.TryParse(Console.ReadLine(), out codeLength);

                // If the parsing fails or the input is not a positive integer,
                // prompt the user again with an error message.
                if (!success || codeLength < 1)
                {
                    success = false;

                    // Set the console text color to red for error messages
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            // Reset console text color to default before returning
            Console.ResetColor();

            // Return the valid code length
            return codeLength;
        }

        // This method prompts the user to enter the desired number of guesses they want for the game.
        // It validates the input, ensuring it's a positive integer.
        public static int GetGuessCount()
        {
            int guessCount = 0;
            bool success = false;

            // Continue looping until a valid input is received
            while (!success)
            {
                Console.WriteLine("Enter the number of guesses you would like to have:");

                // Attempt to parse the user's input into an integer
                success = int.TryParse(Console.ReadLine(), out guessCount);

                // If the parsing fails or the input is not a positive integer,
                // prompt the user again with an error message.
                if (!success || guessCount < 1)
                {
                    success = false;

                    // Set the console text color to red for error messages
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ResetColor();
                }
            }

            // Reset console text color to default before returning
            Console.ResetColor();

            // Return the valid guess count
            return guessCount;
        }


        // This method prompts the user to enter their guess for the secret code.
        // It validates the input, ensuring it contains the correct number of elements (codeLength)
        // and that each element is a valid integer between 1 and 8.
        public static int[]? GetUserGuess(int codeLength)
        {
            // Prompt the user for their guess
            Console.WriteLine($"Enter your guess for the secret code on one line separated by spaces (length should be {codeLength}):");

            // Read the user's input and split it into an array of strings
            string[] input = Console.ReadLine().Split(' ');

            // Check if the number of elements in the input matches the expected code length
            if (input.Length != codeLength)
            {
                // If not, display an error message and return null
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Invalid input. Please enter a guess with a length of {codeLength}.");
                Console.ResetColor();
                return null;
            }

            // Create an array to hold the user's guess
            int[] userGuess = new int[codeLength];

            // Flag to track if the input is valid
            bool validInput = true;

            // Iterate over each element of the input
            for (int i = 0; i < codeLength; i++)
            {
                // Try to parse the input element into an integer, and check if it's within the valid range
                if (!int.TryParse(input[i], out userGuess[i]) || userGuess[i] < 1 || userGuess[i] > 8)
                {
                    // If parsing fails or the integer is out of range, display an error message
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid input at position {i + 1}. Please enter a number between 1 and 8.");
                    Console.ResetColor();
                    validInput = false; // Set validInput flag to false
                    break; // Exit the loop
                }
            }

            // Return the user's guess if it's valid, otherwise return null
            return validInput ? userGuess : null;
        }



        // This method prompts the user if they want to play again and handles their response.
        // It continues to prompt the user until a valid response of 'Y' (yes) or 'N' (no) is received.
        public static bool PlayAgain()
        {
            bool validResponse = false;

            // Continue looping until a valid response is received (y, yes, n, no)
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

            // This line is technically unreachable, but included for completeness
            return false;
        }
    }
}
