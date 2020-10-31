using calculatorUICOOP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace calculatorUICOOP.Static
{
    public static class ModelFactory
    {
        public static IRepository GetRepository() =>
            new Repository();
    }
}
