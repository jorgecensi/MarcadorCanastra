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
            }
        }

        private ObservableCollection<Round> _rounds { get; set; } = new ObservableCollection<Round>();
        public ObservableCollection<Round> Rounds {
            get => _rounds;
            set {
                _rounds = value;
                OnPropertyChanged(nameof(Rounds));
                 }
        } 
    
        public GameDetailViewModel(Game game = null)
        {
            Title = game?.Date.ToString();
            Game = game;
            

        }

        public  async Task RefreshRoundList()
        {
            
            foreach (var round in Game.Rounds)
            {
                Rounds.Add(round);
            }
        }

    }

    
}
