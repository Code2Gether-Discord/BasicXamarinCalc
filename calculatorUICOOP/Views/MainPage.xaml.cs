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
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        #region Fields and Properties
        MainPageViewModel vm { get; set; }
        #endregion

        #region Constructor
        public MainPage()
        {
            InitializeComponent();
            vm = new MainPageViewModel();
        }
        #endregion

        

        private void Number_Clicked(object sender, EventArgs e)
        {

        }
        private void Equals_Clicked(object sender, EventArgs e)
        {

        }      
        private void Clear_Clicked(object sender, EventArgs e)
        {

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
