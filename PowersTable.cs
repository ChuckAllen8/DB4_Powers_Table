using System;
using System.Collections.Generic;
using System.Text;

namespace DB4_Powers_Table
{
    class PowersTable
    {
        private const int WIDTH = 15;
        private string[] columns;
        private string divider;
        
        public PowersTable()
        {
            columns = new string[] { "Number", "Squared", "Cubed" };
            divider = new string('=', WIDTH);
        }

        public void Start()
        {
            bool loop = true;
            while(loop)
            {
                DisplayPowers(GetNumber());
                loop = RunAgain();
                Console.WriteLine("\n");
            }
        }

        private int GetNumber()
        {
            int entry;
            string input;
            
            Console.Write("Please enter an integer: ");
            input = Console.ReadLine();

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
            Console.WriteLine($"{columns[0],WIDTH}|{columns[1],WIDTH}|{columns[2],WIDTH}|");
            Console.WriteLine($"{divider,WIDTH}|{divider,WIDTH}|{divider,WIDTH}|");
            for (int number = 1; number <= limit; number++)
            {
                Console.WriteLine($"{number,WIDTH:#,#.##}|{number*number,WIDTH:#,#.##}|{number*number*number,WIDTH:#,#.##}|");
            }
            Console.WriteLine($"{divider,WIDTH}|{divider,WIDTH}|{divider,WIDTH}|");
            Console.WriteLine($"");
        }
    }
}
