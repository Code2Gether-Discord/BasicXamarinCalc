using System;
using System.Collections.Generic;
using System.Text;

namespace calculatorUICOOP.Models
{
    public interface IRepository
    {
        IEnumerable<decimal> GetAllValues();
        decimal GetLastValue();
    }
}
