using System;
using System.Collections.Generic;
using MarcadorCanastra.Models;
using MarcadorCanastra.ViewModels;
using Xamarin.Forms;

namespace MarcadorCanastra.Views
{
    public partial class NewGamePage : ContentPage
    {
        public NewGameViewModel viewModel { get; set; }

        public NewGamePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new NewGameViewModel();            
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            var player1 = new User { Name = viewModel.Player1Name };
            var player2 = new User { Name = viewModel.Player2Name };
            
            var game = new Game(player1, player2);
            MessagingCenter.Send(this, "AddGame", game);
           
            await Navigation.PushAsync(new GameDetailPage(new GameDetailViewModel(game)));

            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);


        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
