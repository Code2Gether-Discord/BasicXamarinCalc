using calculatorUICOOP.Static;
using calculatorUICOOP.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calculatorUICOOP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _vm;

        public MainPage()
        {
            InitializeComponent();
            _vm = ViewModelFactory.GetMainPageViewModel();
        }

        private void Number_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
        }

        private void Equals_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
        }

        private void Operator_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
        }
        private void C_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            DisplayLabel.Text = "0";
        }

        private void CE_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            DisplayLabel.Text = "0";
        }
    }
}
