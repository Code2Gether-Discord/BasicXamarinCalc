using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace calculatorUICOOP.Models
{
    class Display
    {
         string displayContent = "0";
       
        public Display(Button button)
        {
            ButtonToLabel(button.Text);          
        }
        #region Methods
        private void ButtonToLabel(string button)
        {
            //ignore leading zero
            if (displayContent[0] == '0')
            {
                displayContent = "";
            }
            //adding to whats displayed
            displayContent = String.Concat(displayContent, button);           
        }
           
        //returns what should be on the display as long as the value does not start with 0
        public string GetDisplayContent => displayContent[0] == '0'? "" : displayContent;
        
        public void ClearDisplay()
        {
            displayContent = "0";
        }

        #endregion
    }
}

