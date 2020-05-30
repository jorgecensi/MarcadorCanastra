using System;
using System.Collections.Generic;
using MarcadorCanastra.ViewModels;
using Xamarin.Forms;

namespace MarcadorCanastra.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsViewModel ViewModel { get; set; }
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new SettingsViewModel();
        }
    }
}
