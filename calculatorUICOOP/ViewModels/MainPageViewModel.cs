using calculatorUICOOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calculatorUICOOP.ViewModels
{
    public class MainPageViewModel
    {
        IRepository _repo;

        public MainPageViewModel(IRepository repo)
        {
            _repo = repo;
        }

        public string GetLastValue()
        {

        }

        public string[] GetAllValues()
        {

        }

        public string AddToValue()
        {

        }

        public string SubtractToValue()
        {

        }

        public string MultiplyToValue()
        {

        }

        public string DivideToValue()
        {

        }
    }
}
