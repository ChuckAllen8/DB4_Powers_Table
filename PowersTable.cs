/* 
 * 
 * Made by Chuck Allen as a lab submission for week 2.
 * This asks the user for a number, and verifies the input.
 * It will then display the squares, and cubes of the number.
 * 
 */

using System;

namespace DB4_Powers_Table
{
    class PowersTable
    {
        //required variables
        private const int WIDTH = 15;
        private string[] columns;
        private string divider;
        
        public PowersTable()
        {
            //initialize the strings on object instantiation
            columns = new string[] { "Number", "Squared", "Cubed" };
            divider = new string('=', WIDTH);
        }

        public void Start()
        {
            bool loop = true;
            while(loop)
            {
                DisplayPowers(GetNumber()); //Get a valid number and display powers
                loop = RunAgain(); //determine if going again
                Console.WriteLine("\n"); //separate new runs
            }
        }

        private int GetNumber()
        {
            int entry;
            string input;
            
            Console.Write("Please enter an integer: ");
            input = Console.ReadLine();

            //parse the int, if it fails try again, if the number is not within the bounds try again
            while(!int.TryParse(input, out entry) || (entry <= 0 || entry > 1290))
            {
                Console.WriteLine("\nInvalid entry, it must be greater than 0 and less than 1290.");
                Console.Write("Try again: ");
                input = Console.ReadLine();
            }
            Console.WriteLine("");
            return entry;
        }

        private bool RunAgain()
        {
            //keep going if the user hits y, otherwise exit.
            Console.Write("Continue? (y, anything else quits): ");
            if(Console.ReadKey().Key == ConsoleKey.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DisplayPowers(int limit)
        {
            int square, cube;

            //display the setup lines, this is the headers and divider line.
            Console.WriteLine($"{columns[0],WIDTH}|{columns[1],WIDTH}|{columns[2],WIDTH}|");
            Console.WriteLine($"{divider,WIDTH}|{divider,WIDTH}|{divider,WIDTH}|");

            for (int number = 1; number <= limit; number++)
            {
                //right each number, right justified within the column, using commas to separate the thousands
                //store the square and cube for easier read code.
                cube = number * (square = number * number);
                Console.WriteLine($"{number,WIDTH:#,#.##}|{square,WIDTH:#,#.##}|{cube,WIDTH:#,#.##}|");
            }

            //display a divider at the bottom and a new line.
            Console.WriteLine($"{divider,WIDTH}|{divider,WIDTH}|{divider,WIDTH}|");
            Console.WriteLine($"");
        }
    }
}
