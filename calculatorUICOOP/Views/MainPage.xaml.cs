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

      private void Number_Clicked(object sender, EventArgs e)
        {
           var button = (Button)sender;

          vm.ShowNumberOnDisplay(button.Text);

        }

        private void Equals_Clicked(object sender, EventArgs e)
        {
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            vm.ClearScreen();
        }

        private void Decimal_Clicked(object sender, EventArgs e)
        {
        }

        private void Remainder_Clicked(object sender, EventArgs e)
        {
        }

        private void Minus_Clicked(object sender, EventArgs e)
        {
        }

        private void Plus_Clicked(object sender, EventArgs e)
        {
           var button = (Button)sender;

         vm.ShowPlusOnDisplay(button.Text);
     
        }

        private void Divide_Clicked(object sender, EventArgs e)
        {
        }

        private void Multiply_Clicked(object sender, EventArgs e)
        {
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
        }
     
    }
}