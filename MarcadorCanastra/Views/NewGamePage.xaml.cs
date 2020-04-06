using System;
using System.Collections.Generic;
using MarcadorCanastra.Models;
using Xamarin.Forms;

namespace MarcadorCanastra.Views
{
    public partial class NewGamePage : ContentPage
    {
        public Game Game { get; set; }

        public NewGamePage()
        {
            InitializeComponent();

            Game = new Game(new List<User>());

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddGame", Game);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
