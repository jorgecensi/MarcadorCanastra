using System;
using System.Collections.Generic;
using System.Linq;
using MarcadorCanastra.Models;
using MarcadorCanastra.ViewModels;
using Xamarin.Forms;

namespace MarcadorCanastra.Views
{
    public partial class GameDetailPage : ContentPage
    {
        GameDetailViewModel viewModel;

        public GameDetailPage(GameDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public GameDetailPage()
        {
            InitializeComponent();

            var game = new Game();

            viewModel = new GameDetailViewModel(game);
            BindingContext = viewModel;
        }
        

        async void AddPlayer1Points_Clicked(object sender, EventArgs e)
        {
            var user = viewModel.Game.Player1;
            await Navigation.PushModalAsync(new NavigationPage(new NewUserScorePage(viewModel.Game, user, 1)));
        }
        async void AddPlayer2Points_Clicked(object sender, EventArgs e)
        {
            var user = viewModel.Game.Player2;
            await Navigation.PushModalAsync(new NavigationPage(new NewUserScorePage(viewModel.Game, user, 2)));
        }
       
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as GameDetailViewModel).RefreshRoundList();
        }


    }
}
