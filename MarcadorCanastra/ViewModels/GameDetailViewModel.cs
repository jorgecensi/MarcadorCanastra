using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MarcadorCanastra.Models;
using MarcadorCanastra.Views;
using Xamarin.Forms;

namespace MarcadorCanastra.ViewModels
{
    public class GameDetailViewModel : BaseViewModel
    {
        private Game _game { get; set; }
        public Game Game {
            get => _game;
            set
            {
                _game = value;
                OnPropertyChanged(nameof(Game));
                OnPropertyChanged(nameof(Rounds));
            }
        }

        
        public ObservableCollection<Round> Rounds {
            get => new ObservableCollection<Round>(_game.Rounds);
            
        } 
    
        public GameDetailViewModel(Game game = null)
        {
            Title = $"Jogo: {game?.Date.ToString()} " ;
            Game = game;
            

        }

        

    }

    
}
