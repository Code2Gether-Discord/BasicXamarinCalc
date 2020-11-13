using System.ComponentModel;

namespace calculatorUICOOP.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Fields and Properties
        //backing field
         string displayContent;

        public string DisplayContent
        {
            get => displayContent; set
            {
                if (displayContent == value)
                {
                    return;
                }
                displayContent = value;
                //when we change the backing field update it and the actual display
                OnPropertyChanged(nameof(displayContent));
                OnPropertyChanged(nameof(Display));
            } }
        public string Display => $"{DisplayContent}";
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string text)
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

        public void ShowPlusOnDisplay(string textToDisplay)
        {
            DisplayContent += textToDisplay;
        }
        
        #endregion Methods
    }
}