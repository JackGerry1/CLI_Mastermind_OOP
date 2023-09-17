using System;
using System.Linq;

namespace CLI_Mastermind_OOP
{
    public class MastermindGame
    {
        private int[] secretCode;
        private int[] userGuess;
        private int guessCount;

        public MastermindGame(int codeLength, int guesses)
        {
            // When a new MastermindGame is created, it generates a secret code and initializes guessCount.
            secretCode = GenerateSecretCode(codeLength);
            guessCount = guesses;
            
            
            //RevealSecret(); Uncomment if you want to see the secret code before the game ends, basically cheating for testing purposes. 
        }

        // Generates a random secret code of specified length.
        // Each element of the code array is a random number between 1 (inclusive) and 9 (exclusive).
        // Returns the generated secret code array.
        private static int[] GenerateSecretCode(int codeLength)
        {
            // Create a new Random object for generating random numbers.
            Random random = new Random();

            int[] code = new int[codeLength];

            for (int i = 0; i < codeLength; i++)
            {
                // Generate a random number between 1 (inclusive) and 9 (exclusive)
                code[i] = random.Next(1, 9);
            }

            // Return the generated secret code array.
            return code;
        }

        // This method takes the user's guess as input and evaluates its correctness against the secret code.
        public bool TakeUserGuess(int[] guess)
        {
            userGuess = new int[guess.Length]; // Initialize userGuess array with the same length as the guess.
            bool[] redVisited = new bool[secretCode.Length]; // Initialize an array to track visited positions for red pegs.
            bool[] whiteVisited = new bool[secretCode.Length]; // Initialize an array to track visited positions for white pegs.
            bool isCorrect = false; // Flag to track if the guess is correct.
            bool validCode = true; // Flag to track if the user's guess is valid.

            // Loop through each element of the guess array.
            for (int i = 0; i < guess.Length; i++)
            {
                // Check if the guess is a valid integer between 1 and 8.
                if (!int.TryParse(guess[i].ToString(), out userGuess[i]) || userGuess[i] < 1 || userGuess[i] > 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 8.");
                    Console.ResetColor();
                    validCode = false; // Set validCode flag to false.
                    break; // Exit the loop if an invalid input is detected.
                }
            }

            if (validCode)
            {
                int redPegs = 0, whitePegs = 0;

                // Count red pegs by comparing userGuess with secretCode.
                for (int i = 0; i < secretCode.Length; i++)
                {
                    if (userGuess[i] == secretCode[i])
                    {
                        redPegs++;
                        redVisited[i] = true; // Mark the position as visited for red peg.
                    }
                }

                // Count white pegs.
                for (int i = 0; i < secretCode.Length; i++)
                {
                    if (redVisited[i]) continue; // Skip if already marked for red peg.

                    for (int j = 0; j < secretCode.Length; j++)
                    {
                        if (j == i) continue; // Skip self-comparison.

                        if (!redVisited[j] && !whiteVisited[j] && secretCode[j] == userGuess[i])
                        {
                            whitePegs++;
                            whiteVisited[j] = true; // Mark the position as visited for white peg.
                            break;
                        }
                    }
                }

                // Check if the guess is correct (all pegs are red).
                if (redPegs == secretCode.Length)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCongratulations! You guessed the secret code correctly.\n");
                    Console.ResetColor();
                    RevealSecret();
                    return true;
                }
                else
                {
                    guessCount--;

                    // Display feedback on the guess.
                    Console.WriteLine($"You got {redPegs} red peg(s) and {whitePegs} white peg(s)\n");
                    Console.WriteLine($"You have {guessCount} guess(es) remaining\n");

                    // Check if the user is out of guesses and the guess is not correct.
                    if (guessCount == 0 && !isCorrect)
                    {
                        Console.WriteLine("You lose! Better luck next time!");
                        RevealSecret();
                    }

                    return false; // Return false since the guess is not completely correct.
                }
            }

            return false; // Return false for invalid guesses.
        }


        // Add methods for getting feedback, revealing the secret code, etc.
        private void RevealSecret()
        {
            Console.Write("The secret code was: ");
            foreach (int i in secretCode)
            {
                Console.Write($"{i} ");
            }
            // print newline to clean up output
            Console.Write("\n");
        }

        // used in the program to make sure we can exit the while loop.
        public bool IsGameOver()
        {
            return guessCount == 0;
        }
    }
}
