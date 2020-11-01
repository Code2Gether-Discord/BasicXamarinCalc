using calculatorUICOOP.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace calculatorUICOOP.Static
{
    public static class ViewModelFactory
    {
        public static MainPageViewModel GetMainPageViewModel() =>
            new MainPageViewModel();
    }
}
