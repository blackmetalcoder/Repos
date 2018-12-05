using System;

using App3.ViewModels;

using Windows.UI.Xaml.Controls;

namespace App3.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
