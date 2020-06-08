using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MarcadorCanastra.Services;
using MarcadorCanastra.Views;
using MarcadorCanastra.Data;
using Xamarin.Essentials;
using System.Collections.Generic;
using MarcadorCanastra.Themes;

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

            var isDarkMode = Preferences.Get("IsDarkMode", false);
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                switch (isDarkMode)
                {
                    case true:
                        mergedDictionaries.Add(new DarkTheme());
                        break;
                    case false:
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }
            DeviceDisplay.KeepScreenOn = Preferences.Get("KeepScreenOn", false);

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
