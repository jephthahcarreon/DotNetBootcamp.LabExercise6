// submitted by: Jephthah Carreon

using System;
using System.Collections.Generic;

namespace CSharp.LabExercise6
{
    static class UserInputValidator
    {
        public static string ValidateUserInput()
        {
            
            string userInput;
            while (true)
            {
                Start:
                Console.Write("Please enter a word: ");
                userInput = Console.ReadLine();
                try
                {
                    // checks if user input is blank or contains white spaces
                    if (userInput == "")
                    {
                        Console.WriteLine("The word cannot be blank. Please enter a valid word.\n");
                        continue;
                    }
                    if (userInput.Contains(" "))
                    {
                        Console.WriteLine("The word cannot contain white spaces. Please enter a valid word.\n");
                        continue;
                    }

                    // checks if user input contains numerical values and special characters
                    foreach (char c in userInput)
                    {
                        if (char.IsDigit(c) == true)
                        {
                            Console.WriteLine("The word cannot contain numbers. Please enter a valid word.\n");
                            goto Start;
                        }
                        if (char.IsLetter(c) == false)
                        {
                            Console.WriteLine("The word cannot contain special characters. Please enter a valid word.\n");
                            goto Start;
                        }
                    }
                    break;
                }
                catch (Exception)
                {
                    throw new ArgumentException("Invalid input.");
                }
            }
            return userInput;
        }

        public static void ValidateContinueApplication()
        {
            while (true)
            {
                Console.Write("Continue? (y/n): ");
                string userChoiceInput = Console.ReadLine();
                Console.WriteLine("");

                try
                {
                    char userChoiceInputChar = char.ToLower(Convert.ToChar(userChoiceInput));

                    switch (userChoiceInputChar)
                    {
                        case 'y':
                            break;
                        case 'n':
                            Console.Clear();
                            Console.Write("Press any key to exit application . . . ");
                            Console.ReadKey();
                            Console.Clear();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid input.");
                            continue;
                    }
                    Console.Clear();
                    break;
                }

                catch (Exception)
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }
            }
        }
    }

    static class ScoreRenderer
    {
        public static void RenderScoreResults(string scrabbleWord, int scrabbleScore)
        {
            if (scrabbleScore == 1)
            {
                Console.WriteLine($"The word '{scrabbleWord}' is worth {scrabbleScore} point.\n");
            } else
            {
                Console.WriteLine($"The word '{scrabbleWord}' is worth {scrabbleScore} points.\n");
            }
        }
    }

    class LettersValue
    {
        public Dictionary<char, int> letters = new Dictionary<char, int>()
        {
            { 'A', 1 }, { 'E', 1 }, { 'I', 1 }, { 'O', 1 }, { 'U', 1 }, { 'L', 1 }, { 'N', 1 }, { 'R', 1 }, { 'S', 1 }, { 'T', 1 },
            { 'D', 2 }, { 'G', 2 },
            { 'B', 3 }, { 'C', 3 }, { 'M', 3 }, { 'P', 3 },
            { 'F', 4 }, { 'H', 4 }, { 'V', 4 }, { 'W', 4 }, { 'Y', 4 },
            { 'K', 5 },
            { 'J', 8 }, { 'X', 8 },
            { 'Q', 10 }, { 'Z', 10 },
        };
    }

    class ScrabbleScorer
    {
        LettersValue lettersValue;
        public int score;
        public int totalScore { get; set; }

        public ScrabbleScorer(LettersValue lettersDictionary)
        {
            this.lettersValue = lettersDictionary;
        }
        public int ComputeScrabbleScore(string word)
        {
            foreach (char letter in word.ToUpper())
            {
                lettersValue.letters.TryGetValue(letter, out score);
                totalScore += score;
            }
            return totalScore;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // get and validate user input
                string userWordInput = UserInputValidator.ValidateUserInput();

                // compute scrabble word score
                LettersValue lettersValue = new LettersValue();
                ScrabbleScorer scrabbleScorer = new ScrabbleScorer(lettersValue);
                int scrabbleScore = scrabbleScorer.ComputeScrabbleScore(userWordInput);

                // render results
                ScoreRenderer.RenderScoreResults(userWordInput, scrabbleScore);

                // prompts user to continue or exit application
                UserInputValidator.ValidateContinueApplication();
            }
        }
    }
}
