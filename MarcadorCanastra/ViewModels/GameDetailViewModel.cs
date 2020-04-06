using System;
using MarcadorCanastra.Models;

namespace MarcadorCanastra.ViewModels
{
    public class GameDetailViewModel : BaseViewModel
    {
        public Game Game { get; set; }
        public GameDetailViewModel(Game game = null)
        {
            Title = game?.Date.ToString();
            Game = game;
        }
    }
}
