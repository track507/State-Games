using System;
using StateNamespace;
class HangmanState : State
{
    int wrong = 0; //Set atributes for the number of wrong guesses and the word to guess
    string answer = "nirvana";
    string word = "*******";
    
    public override void Play()
    {
        Console.WriteLine("You are playing Hangman. You Get 6 wrong guesses to guess the word.\n");

        while (wrong != 6 && word != answer) //Keep looping until the player wins or uses all of their guesses
        {
            Console.WriteLine("Word: " + word); //Display the word and how many guesses they have left
            Console.WriteLine("Guesses left: " + (6-wrong));
            Console.Write("Enter a letter: "); //Ask for a letter
            string guess = Console.ReadLine();

            while (guess.Length != 1) //Use this if they give something longer than a letter
            {
                Console.Write("Please enter a single letter: "); //Ask for input again until given one character
                guess = Console.ReadLine();
            }

            if (guess.ToLower() == "n") //The following if statements are if the guess is one of the letters in the word
            { //Changes the word attribute to show the letters that have been guessed correctly
                word = "n" + word.Substring(1, 4) + "n" + word.Substring(6,1);
            }

            else if(guess.ToLower() == "i")
            {
                word = word.Substring(0, 1) + "i" + word.Substring(2,5);
            }

            else if(guess.ToLower() == "r")
            {
                word = word.Substring(0, 2) + "r" + word.Substring(3, 4);
            }

            else if(guess.ToLower() == "v")
            {
                word = word.Substring(0, 3) + "v" + word.Substring(4, 3);
            }

            else if(guess.ToLower() == "a")
            {
                word = word.Substring(0, 4) + "a" + word.Substring(5, 1) + "a";
            }

            else //If the guess is not one of the letters in the word or is something other than a letter
            {
                wrong++; //Increase how many wrong guesses they have, and tell the player they chose incorrectly
                Console.WriteLine("\nIncorrect guess");
            }

            Console.WriteLine();
        }

        //Final output if the player lost
        if (wrong == 6) { Console.WriteLine("You have run out of guesses. The word was \"nirvana\""); }

        //Final output if the player won
        else
        {
            Console.WriteLine("nirvana \nYou guessed the word, you win");
        }
    }

    public override void NextGame()
    {
        //Console.WriteLine("\nTransitioning to the next game\n");
        currentContext.TransitionTo(new BlackJack());
    }
}
