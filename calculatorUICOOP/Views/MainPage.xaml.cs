using BasicXamarinCalc.Static;
using calculatorUICOOP.Models;
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
        bool onSecond = false;  // False = User is currently inputting the X/first value
                                // True  = User is currently inputting the Y/second value

        public MainPage()
        {
            InitializeComponent();
            _vm = ViewModelFactory.GetMainPageViewModel();
        }

        #region Event Handlers
        private void Percent_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException("No logic exists yet for this button");
        }

        private void Number_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            DisplayLabel.Text += button.Text;
            UpdateValue(decimal.Parse(DisplayLabel.Text));  // Get the decimal of label's text and update VM's variable with it
            DisplayCurrentValue();  // Set label's text to VM's variable value
        }

        private void Equals_Clicked(object sender, EventArgs e)
        {
            DisplayLabel.Text = _vm.Evaluate();
        }

        /// <summary>
        /// Determine operator being used,
        /// Reset label's text to 0,
        /// Move on to second variable input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Operator_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Operator? op = null;

            // Determine operator being used
            switch (button.Text[0])
            {
                case '+':
                    op = Operator.Add;
                    break;
                case '-':
                    op = Operator.Subtract;
                    break;
                case 'x':
                    op = Operator.Multiply;
                    break;
                case '/':
                    op = Operator.Divide;
                    break;
                default:
                    break;
            }

            ResetDisplay();
            _vm.exp.Operator = op;
            onSecond = true;
        }

        /// <summary>
        /// If no . exists, append it to label's text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Decimal_Clicked(object sender, EventArgs e)
        {
            if (!DisplayLabel.Text.Contains('.'))
                DisplayLabel.Text += '.';
        }

        /// <summary>
        /// Clears input,
        /// reset's last VM's variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void C_Clicked(object sender, EventArgs e)
        {
            ResetDisplay();
            UpdateValue(decimal.Parse(DisplayLabel.Text));
        }

        /// <summary>
        /// Clears input,
        /// resets entire expression to default values,
        /// user will be inputting first number again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CE_Clicked(object sender, EventArgs e)
        {
            ResetDisplay();
            _vm.Reset();
            onSecond = false;
        }
#endregion

        /// <summary>
        /// Updates VM's variables depending on if user is inputting first or second variable
        /// </summary>
        /// <param name="num"></param>
        private void UpdateValue(decimal num)
        {
            if (onSecond)
                _vm.exp.Y = num;
            else
                _vm.exp.X = num;
        }

        /// <summary>
        /// Reset label to 0
        /// </summary>
        private void ResetDisplay() =>
            DisplayLabel.Text = "0";

        /// <summary>
        /// Set's label's text to VM's variable value depending on if user is inputting first or second variable
        /// </summary>
        private void DisplayCurrentValue()
        {
            if (onSecond)
                DisplayLabel.Text = $"{_vm.exp.Y}";
            else
                DisplayLabel.Text = $"{_vm.exp.X}";
        }
    }
}
