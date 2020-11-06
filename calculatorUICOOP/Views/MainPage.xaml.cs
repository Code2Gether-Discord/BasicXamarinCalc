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
        #endregion

    }
}
