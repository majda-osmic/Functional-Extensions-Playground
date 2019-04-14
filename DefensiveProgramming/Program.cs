using DefensiveProgramming.Option;
using Examples.Option;
using System;

namespace DefensiveProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var traditional = new TraditionalDataAccess();
            var withOption = new OptionDataAccess();

            while (true)
            {
                Console.Write("Input, please: ");
                var data = Console.ReadLine();
                if (String.IsNullOrEmpty(data))
                    continue; 

                Console.WriteLine(); 
                Console.WriteLine("TRADTIONAL:");
                HandleInput(data, traditional);
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("WITH OPTION:");

                HandleInput(data, withOption);
            }
        }

        private static void HandleInput(string input, IDataAccessSample da)
        {
            int key = Convert.ToInt32(input);

            Console.WriteLine("Write always to console:");
            da.WriteAlwaysToConsole(key);

            Console.WriteLine("Write to console only if valid:");
            da.WriteOnlyValidToConsole(key);

            Console.WriteLine("Done!");
        }

    }
}
