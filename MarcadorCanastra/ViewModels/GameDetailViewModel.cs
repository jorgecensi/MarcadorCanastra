using MarcadorCanastra.Models;
using MvvmHelpers;

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
        
        public ObservableRangeCollection<Round> Rounds {
            get => new ObservableRangeCollection<Round>(_game.Rounds);
        } 
    
        public GameDetailViewModel(Game game = null)
        {
            Title = $"Jogo: {game?.Date.ToString()} " ;
            Game = game;
        }
    }
}
