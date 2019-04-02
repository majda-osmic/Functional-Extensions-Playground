using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Examples.Option
{
    class SampleData : ReadOnlyDictionary<string, string>
    {
        public SampleData()
            : base(
                new Dictionary<string, string>()
                {
                    { "1", "one" },
                    { "2", "two" },
                    { "3", "three" }
                })
        {

        }
    }

}
