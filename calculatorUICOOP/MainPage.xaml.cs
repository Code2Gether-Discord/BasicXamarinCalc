using calculatorUICOOP.Models;
using System;
using System.ComponentModel;
using System.Net.Http;
using Xamarin.Forms;

namespace calculatorUICOOP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Display button;
        string displayContent;
        public MainPage()
        {
            InitializeComponent();
            //TO DO: Default label value should be zero so need 2 remove zero when displaying value/calculating
            //you are currently not able to press 0
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //create the button pressed
            button = new Display((Button)sender);
            DisplayRefresh();
        }

        private void DisplayRefresh()
        {
            //add whatever is in the displaycontent and display it
            DisplayLabel.Text += button.GetDisplayContent;
        }
        private void Button_Clear_Display(object sender, EventArgs e)
        {
            //if the button has been created
            if (button != null)
            {
                button.ClearDisplay();
                DisplayLabel.Text = "";
            }
        }

    }
}