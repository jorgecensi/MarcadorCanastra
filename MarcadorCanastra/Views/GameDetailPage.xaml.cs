using System;
using System.Collections.Generic;
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

            var game = new Game(new List<User>());

            viewModel = new GameDetailViewModel(game);
            BindingContext = viewModel;
        }
        async void AddPoints_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewUserScorePage()));
        }
    }
}
