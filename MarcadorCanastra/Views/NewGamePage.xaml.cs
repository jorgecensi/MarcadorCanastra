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

        public NewGamePage(Game lastGame)
        {
            InitializeComponent();

            BindingContext = viewModel = new NewGameViewModel(lastGame);
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            var player1 = new User { Name = string.IsNullOrEmpty(viewModel.Player1Name) ? "Jogador 1" : viewModel.Player1Name };
            var player2 = new User { Name = string.IsNullOrEmpty(viewModel.Player2Name) ? "Jogador 2" : viewModel.Player2Name };

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
