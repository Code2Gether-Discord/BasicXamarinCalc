using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace calculatorUICOOP.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Fields 
        private string displayContent;
        #endregion

        #region Properties
        public string DisplayContent
        {
            get => displayContent;
            set
            {
                if (displayContent == value)
                {
                    return;
                }
                displayContent = value;
                // Send a "push" notification to the UI letting it know the DisplayContent has changed.
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand NumberInputCommand { get; set; }
        public ICommand ClearInputCommand { get; set; }
        public ICommand DeleteInputCommand { get; set; }
        public ICommand DivideInputCommand { get; set; }
        public ICommand MultiplyInputCommand { get; set; }
        public ICommand clearInputCommand { get; set; }
        public ICommand PlusInputCommand { get; set; }
        public ICommand MinusInputCommand { get; set; }
        public ICommand RemainderInputCommand { get; set; }
        public ICommand DecimalInputCommand { get; set; }
        public ICommand EqualsInputCommands { get; set; }

        #endregion

        #region Delegates
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        #region Constructor
        public MainPageViewModel()
        {
            NumberInputCommand = new Command<string>(ShowNumberOnDisplay);
            ClearInputCommand = new Command(ClearScreen);
            DeleteInputCommand = new Command(DeleteLastInput);
            DivideInputCommand = new Command<string>(ShowDivideOnDisplay);
            MultiplyInputCommand = new Command<string>(ShowMultiplyOnDisplay);
            PlusInputCommand = new Command<string>(ShowPlusOnDisplay);
            MinusInputCommand = new Command<string>(ShowMinusOnDisplay);
            RemainderInputCommand = new Command<string>(ShowRemainderOnDisplay);
            DecimalInputCommand = new Command<string>(ShowDecimalOnDisplay);
            EqualsInputCommands = new Command(Equals);
        }
        #endregion

        #region Methods
        private void OnPropertyChanged([CallerMemberName] string text = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(text));
        }

        public void ShowNumberOnDisplay(string textToDisplay)
        {
            DisplayContent += textToDisplay;
            var removedLeadingZeros = decimal.Parse(DisplayContent);
            DisplayContent = removedLeadingZeros.ToString();
        }

        public void ClearScreen()
        {
            DisplayContent = "0";
        }

        public void ShowPlusOnDisplay(string plus)
        {

        }
        public void ShowMultiplyOnDisplay(string multiply)
        {

        }
        public void ShowMinusOnDisplay(string minus)
        {

        }
        public void ShowdivideOnDisplay(string divide)
        {


        }
        public void DeleteLastInput()
        {
            if (DisplayContent != "")
            {
                DisplayContent = DisplayContent.Remove(DisplayContent.Length - 1);
            }
           
        }

        public void ShowRemainderOnDisplay(string remainder)
        {

        }
        public void ShowDecimalOnDisplay(string decimalDot)
        {

        }
        public void Equals()
        {

        }
        public void ShowDivideOnDisplay(string divide)
        {

        }
        #endregion 
    }
}
