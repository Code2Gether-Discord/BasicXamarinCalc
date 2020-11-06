using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace calculatorUICOOP.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _currentValue;
        public event PropertyChangedEventHandler PropertyChanged;

        public string CurrentValue
        {
            get => _currentValue;
            set { _currentValue = value; OnPropertyChanged(); }
        }

        // Commands don't need property notifications since they don't change
        public ICommand Number1 { get; set; }
        public ICommand Number2 { get; set; }
        public ICommand Number3 { get; set; }
        public ICommand Number4 { get; set; }
        public ICommand Number5 { get; set; }
        public ICommand Number6 { get; set; }
        public ICommand Number7 { get; set; }
        public ICommand Number8 { get; set; }
        public ICommand Number9 { get; set; }
        public ICommand Number0 { get; set; }
        public ICommand Decimal { get; set; }

        public ICommand Plus { get; set; }
        public ICommand Minus { get; set; }
        public ICommand Multiply { get; set; }
        public ICommand Divide { get; set; }
        public ICommand Percent { get; set; }
        public ICommand Equal { get; set; }
        public ICommand Clear { get; set; }
        public ICommand Delete { get; set; }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
