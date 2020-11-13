using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace calculatorUICOOP.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Fields and Properties

        //backing field
        private string displayContent;

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
                //when we change the backing field update it and the actual display
                OnPropertyChanged(nameof(DisplayContent));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string text = null)
        { //? is not null, notify xamarin forms to update ui
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(text));
        }

        #endregion Fields and Properties

        #region Methods

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
            DisplayContent += "+";
        }

        #endregion Methods
    }
}