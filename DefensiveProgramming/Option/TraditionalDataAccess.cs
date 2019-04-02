using DefensiveProgramming.Option;
using System;

namespace Examples.Option
{
    class TraditionalDataAccess : IDataAccessSample
    {
        private SampleData _data = new SampleData();

        /// <summary>
        /// Performs data access without an explicit promise that there will be a string to return
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private string AccessData(int i)
        {
            if (_data.TryGetValue(i.ToString(), out var result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// Executes an action only if data is available
        /// </summary>
        /// <param name="key"></param>
        public void WriteOnlyValidToConsole(int key)
        {
            var data = AccessData(key);
            if (data != null)
            {
                Console.WriteLine($"Got a correct string back {data}");
            }
        }

        /// <summary>
        /// Executes different actions depending on wether data is available or not
        /// (if - else if - else)
        /// </summary>
        /// <param name="key"></param>
        public void WriteAlwaysToConsole(int key)
        {
            var data = AccessData(key);
            if (data != null)
            {
                Console.WriteLine($"Got a correct string back: {data}");
            }
            else if (AccessData(Math.Abs(key)) != null)
            {
                Console.WriteLine($"Got a fallback string: {data}");
            }
            else
            {
                Console.WriteLine($"No valid mapping found!");
            }
        }

        /// <summary>
        /// Queries data and provides a fallback if there is no correct mapping 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string RetrieveData(int key) => AccessData(key) ?? AccessData(Math.Abs(key)) ?? $"No valid mapping found!";
    }
}
