using calculatorUICOOP.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace calculatorUICOOP
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        #region Fields and Properties

        private MainPageViewModel vm { get; set; }

        #endregion Fields and Properties

        #region Constructor

        public MainPage()
        {
            InitializeComponent();
            vm = new MainPageViewModel();
            BindingContext = vm;
        }

        #endregion Constructor
        // Get rid of me, please.
        private void Equals_Clicked(object sender, EventArgs e)
        {

        }

        // Get rid of me, please.
        private void Clear_Clicked(object sender, EventArgs e)
        {
            vm.ClearScreen();
        }

        // Get rid of me, please.
        private void Decimal_Clicked(object sender, EventArgs e)
        {
        }

        // Get rid of me, please.
        private void Remainder_Clicked(object sender, EventArgs e)
        {
        }

        // Get rid of me (and my brothers, please).
        // Maybe when creating a command for this, use one for all operators.
        private void Minus_Clicked(object sender, EventArgs e)
        {
        }

        
        private void Plus_Clicked(object sender, EventArgs e)
        {
            vm.ShowPlusOnDisplay();
        }

        private void Divide_Clicked(object sender, EventArgs e)
        {
        }

        private void Multiply_Clicked(object sender, EventArgs e)
        {
        }

        // Get rid of me, please.
        private void Delete_Clicked(object sender, EventArgs e)
        {
        }
    }
}