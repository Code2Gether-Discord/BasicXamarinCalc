using System;
using System.Collections.Generic;
using System.Text;

namespace calculatorUICOOP.ViewModels
{
    public class MainPageViewModel
    {
        public string DisplayContent { get; private set; } = "0";
        #region Fields and Properties
        // TODO
        #endregion

        #region Constructors
        public MainPageViewModel()
        {
            // TODO
        }
        #endregion

        #region Methods
        // TODO
        public void ShowNumberOnDisplay(string textToDisplay)
        {
            if (DisplayContent.StartsWith("0"))
            {
                DisplayContent = "";
            }            
            DisplayContent += textToDisplay;          
        }
        public void ClearScreen() { DisplayContent = "0"; }
        #endregion
    }
}
