using System;
using MarcadorCanastra.Models;
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
            MessagingCenter.Send(this, "AddRound", ViewModel.Round);
            ViewModel.Salva();
            await Navigation.PopModalAsync();
        }

        void Switch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            ViewModel.SetBatida(e.Value);
        }

        void Switch_Toggled2(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            ViewModel.SetBatida2(e.Value);
        }


    }
}
