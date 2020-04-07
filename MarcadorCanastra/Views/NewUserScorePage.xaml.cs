using System;
using MarcadorCanastra.Models;
using MarcadorCanastra.ViewModels;
using Xamarin.Forms;

namespace MarcadorCanastra.Views
{
    public partial class NewUserScorePage : ContentPage
    {
        public NewUserScoreViewModel ViewModel { get; set; }
        

        public NewUserScorePage(Game game, User user, int playerNumber)
        {
            InitializeComponent();
            
            BindingContext = ViewModel = new NewUserScoreViewModel(user, game, playerNumber);
            
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
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddGameScore", ViewModel.UserScore);
            await Navigation.PopModalAsync();
        }
    }
}
