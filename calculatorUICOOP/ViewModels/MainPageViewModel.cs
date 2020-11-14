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
        public ICommand numberInputCommand { get; set; }
        // todo: create a command for operators. Do we need a command parameter?
        // todo: create a command for "clear". Again... do we need a command parameter?
        #endregion

        #region Delegates
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

       
        #region Constructor
        public MainPageViewModel()
        {
            numberInputCommand = new Command<string>(ShowNumberOnDisplay);
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

        public void ShowPlusOnDisplay()
        {
            
        }
        #endregion Methods
    }
}
