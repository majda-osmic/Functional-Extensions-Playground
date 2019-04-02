using DefensiveProgramming.Option;
using FunctionalExtensions.Option;
using FunctionalExtensions.Option.Interfaces;
using System;

namespace Examples.Option
{
    class OptionDataAccess : IDataAccessSample
    {
        private SampleData _data = new SampleData();

        /// <summary>
        /// Performs data access without exlicitly promising that there will be a string to return
        /// </summary>
        /// <param name="key">Key of the mapping to be found</param>
        /// <returns>An option of string</returns>
        private IOption<string> AccessData(int key)
        {
            if (_data.TryGetValue(key.ToString(), out var result))
            {
                return Some<string>.Create(result);
            }

            return None<string>.Create();
        }

        /// <summary>
        /// Executes an action only if data is available
        /// </summary>
        /// <param name="key">Key of the mapping to be found</param>
        public void WriteOnlyValidToConsole(int key) =>
            AccessData(key)
                .IgnoreNone()
                .OnValidResult(data => Console.WriteLine($"Got a correct string back {data}"));

        /// <summary>
        /// Executes different actions depending on wether data is available or not
        /// </summary>
        /// <param name="key"></param>
        public void WriteAlwaysToConsole(int key) =>
            AccessData(key).WhenNone(() =>
            {
                AccessData(Math.Abs(key))
                    .WhenNone(() => Console.WriteLine($"No valid mapping found!"))
                    .OnValidResult(data => Console.WriteLine($"Got a fallback string: {data}"));
            }).OnValidResult(data => Console.WriteLine($"Got a correct string back: {data}"));

        /// <summary>
        /// Queries data and provides a fallback if there is no correct mapping 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string RetrieveData(int key) => AccessData(key).WhenNone($"No valid mapping found!").GetValue();
    }
}
