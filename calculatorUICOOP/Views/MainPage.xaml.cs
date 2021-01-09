using calculatorUICOOP.ViewModels;
using System;
using System.ComponentModel;
using System.Globalization;
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
            //In case someone's country uses a "," instead of period for decimals
            CultureInfo.CurrentCulture = new CultureInfo("en-GB");
            vm = new MainPageViewModel();
            BindingContext = vm;
        }

        #endregion Constructor


    }
}