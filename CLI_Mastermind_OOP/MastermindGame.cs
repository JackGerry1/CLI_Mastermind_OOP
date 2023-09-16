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
            secretCode = GenerateSecretCode(codeLength);
            guessCount = guesses;
            RevealSecret();
        }

        internal Program MastermindGameImport
        {
            get => default;
            set
            {
            }
        }

        internal Program MastermindGameImports
        {
            get => default;
            set
            {
            }
        }

        private static int[] GenerateSecretCode(int codeLength)
        {
            Random random = new Random();
            int[] code = new int[codeLength];
            for (int i = 0; i < codeLength; i++)
            {
                code[i] = random.Next(1, 9);
            }
            return code;
        }

        public bool TakeUserGuess(int[] guess)
        {
            if (guess.Length != secretCode.Length)
            {
                Console.WriteLine($"Invalid input. Please enter a guess with a length of {secretCode.Length}.");
                return false;
            }

            userGuess = guess;
            bool[] redVisited = new bool[secretCode.Length];
            bool[] whiteVisited = new bool[secretCode.Length];
            bool validCode = true;
            bool isCorrect = false;

            for (int i = 0; i < guess.Length; i++)
            {
                if (!int.TryParse(guess[i].ToString(), out userGuess[i]) || userGuess[i] < 1 || userGuess[i] > 8)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 8.");
                    validCode = false;
                    break;
                }
            }

            if (validCode)
            {
                int redPegs = 0, whitePegs = 0;

                // Count red pegs
                for (int i = 0; i < secretCode.Length; i++)
                {
                    if (userGuess[i] == secretCode[i])
                    {
                        redPegs++;
                        redVisited[i] = true;
                    }
                }

                // Count white pegs
                for (int i = 0; i < secretCode.Length; i++)
                {
                    if (redVisited[i]) continue;

                    for (int j = 0; j < secretCode.Length; j++)
                    {
                        if (j == i) continue;

                        if (!redVisited[j] && !whiteVisited[j] && secretCode[j] == userGuess[i])
                        {
                            whitePegs++;
                            whiteVisited[j] = true;
                            break;
                        }
                    }
                }

                if (redPegs == secretCode.Length)
                {
                    Console.WriteLine("\nCongratulations! You guessed the secret code correctly.\n");
                    RevealSecret();
                    return true;
                }
                else
                {
                    guessCount--;
                    Console.WriteLine($"You got {redPegs} red peg(s) and {whitePegs} white peg(s)\n");
                    Console.WriteLine($"You have {guessCount} guess(es) remaining\n");

                    if (guessCount == 0 && !isCorrect)
                    {
                        Console.WriteLine("You lose! Better luck next time!");
                        RevealSecret();
                    }

                    return false;
                }
            }

            return false;
        }

        // Add methods for getting feedback, revealing the secret code, etc.
        void RevealSecret()
        {
            Console.Write("The secret code was: ");
            foreach (int i in secretCode)
            {
                Console.Write($"{i} ");
            }
            Console.Write("\n");
        }

        public bool IsGameOver()
        {
            return guessCount == 0;
        }
    }
}
