using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MarcadorCanastra.Services;
using MarcadorCanastra.Views;

namespace MarcadorCanastra
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<MockGameDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
