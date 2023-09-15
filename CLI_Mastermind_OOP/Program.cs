using System;

namespace CLI_Mastermind_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                int codeLength = UserInterface.GetCodeLength();
                int guessCount = UserInterface.GetGuessCount();

                MastermindGame game = new MastermindGame(codeLength, guessCount);

                while (!game.IsGameOver())
                {
                    int[] userGuess = UserInterface.GetUserGuess(codeLength);

                    if (userGuess != null && game.TakeUserGuess(userGuess))
                    {
                        break; // Exit the loop
                    }
                }

                // Prompt to play again or quit
                playAgain = UserInterface.PlayAgain();

                Console.Clear(); // Clear the console before starting a new game
            }

            Environment.Exit(0);
        }
    }
}
