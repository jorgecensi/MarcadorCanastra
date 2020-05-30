using System;
using System.Collections.Generic;
using MarcadorCanastra.Themes;
using MvvmHelpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MarcadorCanastra.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {

        public bool IsDarkmode {
            get => Preferences.Get("IsDarkMode", false);

            set {
                Preferences.Set("IsDarkMode", value);
                ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
                if (mergedDictionaries != null)
                {
                    mergedDictionaries.Clear();

                    switch (value)
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

                OnPropertyChanged(nameof(IsDarkmode));

            }
        }

        public SettingsViewModel()
        {           
            
        }
    }
}
