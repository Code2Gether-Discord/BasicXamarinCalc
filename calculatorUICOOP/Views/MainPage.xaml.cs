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
        public MainPageViewModel vm { get; set; }
        private MainPageMutator mutator { get; set; }
        #endregion

        #region Constructor
        public MainPage()
        {
            InitializeComponent();
            vm = new MainPageViewModel();
            mutator = new MainPageMutator(vm);
            mutator.Clear();
            BindingContext = vm;
        }
        #endregion

        #region Event Handlers
        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            // TODO
        }
        #endregion

        private void Number_Clicked(object sender, EventArgs e)
        {
            mutator.EnterNumber(((Button)sender).Text);
        }

        private void Equals_Clicked(object sender, EventArgs e)
        {
            mutator.Equals();
        }      

        private void Clear_Clicked(object sender, EventArgs e)
        {
            mutator.Clear();
        }
        private void Decimal_Clicked(object sender, EventArgs e)
        {
            mutator.TryAddDecimal();
        }

        private void Remainder_Clicked(object sender, EventArgs e)
        {
        }

        private void Minus_Clicked(object sender, EventArgs e)
        {
            mutator.Minus();
        }

        private void Plus_Clicked(object sender, EventArgs e)
        {
            mutator.Plus();
        }
        
        private void Divide_Clicked(object sender, EventArgs e)
        {
            mutator.Divide();
        }
        
        private void Multiply_Clicked(object sender, EventArgs e)
        {
            mutator.Multiply();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            mutator.Delete();
        }
    }
}
