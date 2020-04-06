using System;
using MarcadorCanastra.Models;
using MarcadorCanastra.ViewModels;
using Xamarin.Forms;

namespace MarcadorCanastra.Views
{
    public partial class NewUserScorePage : ContentPage
    {
        public NewUserScoreViewModel ViewModel { get; set; }
        

        public NewUserScorePage(User user)
        {
            InitializeComponent();
            
            BindingContext = ViewModel = new NewUserScoreViewModel(user);
        }

        void OnCanastraLimpaStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            var value = Convert.ToInt32(e.NewValue);
            ViewModel.SetCanastraLimpa(value);
        }

        void OnCanastraSujaStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            var value = Convert.ToInt32(e.NewValue);
            ViewModel.SetCanastraSuja(value);
        }

        void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            ViewModel.SetBatida(e.Value);
        }
    }
}
