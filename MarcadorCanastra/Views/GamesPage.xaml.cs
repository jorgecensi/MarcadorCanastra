﻿using System;
using MarcadorCanastra.Models;
using MarcadorCanastra.ViewModels;
using Xamarin.Forms;

namespace MarcadorCanastra.Views
{
    public partial class GamesPage : ContentPage
    {
        GamesViewModel viewModel;

        public GamesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new GamesViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Game)layout.BindingContext;
            await Navigation.PushAsync(new GameDetailPage(new GameDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            var lastGame = viewModel.LastGame();
            await Navigation.PushModalAsync(new NavigationPage(new NewGamePage(lastGame)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Games.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}
