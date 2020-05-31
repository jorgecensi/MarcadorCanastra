using System;
using MarcadorCanastra.ViewModels;
using Xamarin.Forms;

namespace MarcadorCanastra.Views
{
    public partial class NewUserScorePage : ContentPage
    {
        public NewUserScoreViewModel ViewModel { get; set; }
        

        public NewUserScorePage(GameDetailViewModel viewModel)
        {
            InitializeComponent();
            
            BindingContext = ViewModel = new NewUserScoreViewModel(viewModel);
            
        }

        void OnCanastraLimpaStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            var value = Convert.ToInt32(e.NewValue);
            ViewModel.SetCanastraLimpa(value);
        }
        void OnCanastraLimpa2StepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            var value = Convert.ToInt32(e.NewValue);
            ViewModel.SetCanastraLimpa2(value);
        }

        void OnCanastraSujaStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            var value = Convert.ToInt32(e.NewValue);
            ViewModel.SetCanastraSuja(value);
        }
        void OnCanastraSuja2StepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            var value = Convert.ToInt32(e.NewValue);
            ViewModel.SetCanastraSuja2(value);
        }

        
        async void Save_Clicked(object sender, EventArgs e)
        {
            if (!ViewModel.Round.Player1Score.IsBatida && !ViewModel.Round.Player2Score.IsBatida)
            {
                await DisplayAlert("Ops", "Quem bateu essa rodada?", "OK");
            }
            else
            {

                MessagingCenter.Send(this, "AddRound", ViewModel.Round);
                ViewModel.Salva();
                await Navigation.PopModalAsync();
            }
            
        }

       


    }
}
