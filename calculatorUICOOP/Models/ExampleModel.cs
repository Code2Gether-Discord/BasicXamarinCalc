using System;
using System.Collections.Generic;
using System.Text;

namespace calculatorUICOOP.Models
{
    public class ExampleModel
    {
        public string SomeValue { get; set; } = "Moshi ";

        public ExampleModel()
        {
            SomeValue += SomeValue;
        }
    }
}
