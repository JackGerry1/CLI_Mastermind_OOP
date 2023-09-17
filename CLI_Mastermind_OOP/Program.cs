using System;

namespace CLI_Mastermind_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            // This loop allows the player to play multiple games in succession
            while (playAgain)
            {
                int codeLength = UserInterface.GetCodeLength();
                int guessCount = UserInterface.GetGuessCount();

                MastermindGame game = new MastermindGame(codeLength, guessCount);

                while (!game.IsGameOver())
                {
                    // Prompt the user for a guess and validate it
                    int[] userGuess = UserInterface.GetUserGuess(codeLength);

                    // If the guess is valid, pass it to the game for evaluation
                    if (userGuess != null && game.TakeUserGuess(userGuess))
                    {
                        break; // Exit the loop if the user has guessed the code correctly
                    }
                }

                playAgain = UserInterface.PlayAgain();

                Console.Clear();
            }

            // Exit the program when the player chooses to quit
            Environment.Exit(0);
        }

    }
}
