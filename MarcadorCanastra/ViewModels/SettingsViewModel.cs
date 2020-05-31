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

        public bool NoLimit {
            get => Preferences.Get("MaxPoints", 0)==0;
            set {
                if (value)
                {
                    Preferences.Set("MaxPoints", 0);
                }
                
            }
        }
        public bool Max3000 {
            get => Preferences.Get("MaxPoints", 0) == 3000;
            set
            {
                if (value)
                {
                    Preferences.Set("MaxPoints", 3000);
                }
            }
                
        }
        public bool Max4000 {
            get => Preferences.Get("MaxPoints", 0) == 4000;
            set {
                if (value)
                {
                    Preferences.Set("MaxPoints", 4000);
                }
            } 
        }
        public bool Max5000 {
            get => Preferences.Get("MaxPoints", 0) == 5000;
            set
            {
                if (value)
                {
                    Preferences.Set("MaxPoints", 5000);
                }
            }
            }
        public bool Max8000 {
            get => Preferences.Get("MaxPoints", 0) == 8000;
            set {
                if (value)
                {
                    Preferences.Set("MaxPoints", 8000);
                }
            } 
        }
    }
}
