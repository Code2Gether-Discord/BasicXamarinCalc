using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calculatorUICOOP.Models
{

    public class Repository : IRepository
    {
        private List<decimal> _memory { get; set; } = new List<decimal>();

        public decimal GetLastValue()
        {
            return _memory[_memory.Count()];
        }

        public IEnumerable<decimal> GetAllValues()
        {
            return _memory;
        }
    }
}
