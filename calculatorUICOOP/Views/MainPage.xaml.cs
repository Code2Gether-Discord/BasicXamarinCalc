using BasicXamarinCalc.Static;
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
        bool onSecond = false;

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
            UpdateValue(decimal.Parse(DisplayLabel.Text));
            DisplayCurrentValue();
        }

        private void Equals_Clicked(object sender, EventArgs e)
        {
            DisplayLabel.Text = _vm.Evaluate();
        }

        private void Operator_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Operator? op = null;

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
            _vm.Op = op;
            onSecond = true;
        }

        private void Decimal_Clicked(object sender, EventArgs e)
        {
            if (!DisplayLabel.Text.Contains('.'))
                DisplayLabel.Text += '.';
        }

        private void C_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            ResetDisplay();
            UpdateValue(decimal.Parse(DisplayLabel.Text));
        }

        private void CE_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            ResetDisplay();
            _vm.Reset();
            onSecond = false;
        }
#endregion

        private void UpdateValue(decimal num)
        {
            if (onSecond)
                _vm.Y = num;
            else
                _vm.X = num;
        }

        private void ResetDisplay() =>
            DisplayLabel.Text = "0";

        private void DisplayCurrentValue()
        {
            if (onSecond)
                DisplayLabel.Text = $"{_vm.Y}";
            else
                DisplayLabel.Text = $"{_vm.X}";
        }
    }
}
