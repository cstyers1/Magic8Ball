using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Magic8Ball
{
    class Program
    {
        static void Main(string[] args)
        {
            // Preserve current console text color
            ConsoleColor oldColor = Console.ForegroundColor;

            // Calls this function
            ProgramIntroduction();

            // Create a randomized object
            Random randomObject = new Random();

            // Infinite Loop
            while (true)
            {
                // Calls the return variable from the GetQuestionFromUser function
                string questionString = GetQuestionFromUser();

                // This gives the illusion that the computer has to think about the answer
                int numberOfSecondsToSleep = randomObject.Next(3) + 1;
                Console.WriteLine("Let me think...");
                Thread.Sleep(numberOfSecondsToSleep * 1000);

                // This ensures the user has to ask a question to get a response
                if (questionString.Length == 0 || String.IsNullOrWhiteSpace(questionString))
                {
                    Console.WriteLine("You need to type a question!");
                    continue;
                }                

                // See if the user typed 'quit' as the question
                if (questionString.ToLower() == "quit")
                {
                    break;
                }

                // If the user insults with 'you suck', insult them back and close app
                if (questionString.ToLower() == "you suck")
                {
                    Console.WriteLine("You suck even more! Bye!");
                    break;
                }

                // Get a random number
                int randomNumber = randomObject.Next(4);

                Console.ForegroundColor = (ConsoleColor)randomObject.Next(15);

                // Use random number to determine response
                switch(randomNumber)
                {
                    case 0: Console.WriteLine("YES!");
                        break;
                    case 1: Console.WriteLine("NO!");
                        break;
                    case 2: Console.WriteLine("Perhaps..");
                        break;
                    case 3: Console.WriteLine("Maybe someday.");
                        break; 
                }
            } // End of the while loop


            // Cleaning up
            Console.ForegroundColor = oldColor;
        }

        // This will print the name of the program
        // and who created it to the console
        static void ProgramIntroduction()
        {
            // Changing console text color
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Magic 8 Ball (Created by: Clayton Styers");
        }

        static string GetQuestionFromUser()
        {
            // This block of code will ask the user for a question, 
            // change the console text color, and store the
            // question text in the questionString variable
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ask a question?: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string questionString = Console.ReadLine();

            // Returns the user input
            return questionString;
        }

    }
}
