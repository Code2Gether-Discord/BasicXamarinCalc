﻿using calculatorUICOOP.ViewModels;
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
        MainPageViewModel vm { get; set; }
        #endregion

        #region Constructor
        public MainPage()
        {
            InitializeComponent();
            vm = new MainPageViewModel();
        }
        #endregion

        #region Event Handlers
        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            // TODO
        }
        #endregion

        private void Number_Clicked(object sender, EventArgs e)
        {

        }
        private void Percent_Clicked(object sender, EventArgs e)
        {

        }
        private void Equals_Clicked(object sender, EventArgs e)
        {

        }
        private void Operator_Clicked(object sender, EventArgs e)
        {

        }
        private void Clear_Clicked(object sender, EventArgs e)
        {

        }
        private void Decimal_Clicked(object sender, EventArgs e)
        {

        }
    }
}
