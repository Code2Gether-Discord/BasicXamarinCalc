using calculatorUICOOP.ViewModels;
using System;
using System.ComponentModel;
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
            vm = new MainPageViewModel();
            BindingContext = vm;
        }

        #endregion Constructor
      
        
    }
}