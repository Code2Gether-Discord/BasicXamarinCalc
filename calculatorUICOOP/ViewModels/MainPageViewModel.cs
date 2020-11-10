namespace calculatorUICOOP.ViewModels
{
    public class MainPageViewModel
    {
        #region Fields and Properties

        public string DisplayContent { get; private set; }

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

        #endregion Methods
    }
}