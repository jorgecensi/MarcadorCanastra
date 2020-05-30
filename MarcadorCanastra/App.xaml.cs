using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MarcadorCanastra.Services;
using MarcadorCanastra.Views;
using MarcadorCanastra.Data;

namespace MarcadorCanastra
{
    public partial class App : Application
    {
        static MarcadorCanastraDatabase database;
        public static MarcadorCanastraDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MarcadorCanastraDatabase();
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            Device.SetFlags(new string[] { "RadioButton_Experimental", "SwipeView_Experimental" });
            DependencyService.Register<GameDataStore>();
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
