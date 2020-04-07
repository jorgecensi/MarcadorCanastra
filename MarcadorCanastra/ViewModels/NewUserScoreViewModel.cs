using System;
using MarcadorCanastra.Models;

namespace MarcadorCanastra.ViewModels
{
    public class NewUserScoreViewModel:BaseViewModel
    {
        private Game _game;
        public Game Game { get => _game; }
        private UserScore _userScore;
        public UserScore UserScore
        {
            get => _userScore;
            set
            {
                _userScore = value;
                OnPropertyChanged(nameof(UserScore));
            } 
        }
        
        public int TotalCardsInHand
        {
            get => _userScore.TotalCardsInHand;
            set
            {
                _userScore.TotalCardsInHand = value;
                OnPropertyChanged(nameof(UserScore));
            }
        }

        private string _canastraLimpaLabel;
        public string CanastraLimpaLabel
        {
            get => _canastraLimpaLabel;
            set
            {
                _canastraLimpaLabel = value;
                OnPropertyChanged(nameof(CanastraLimpaLabel));
            }
        }

        private string _canastraSujaLabel;
        public string CanastraSujaLabel
        {
            get => _canastraSujaLabel;
            set
            {
                _canastraSujaLabel = value;
                OnPropertyChanged(nameof(CanastraSujaLabel));
            }
        }

        const string CANASTRALIMPA = "Canastra Limpa";
        const string CANASTRASUJA = "Canastra Suja";

        public NewUserScoreViewModel(User user, Game game, int playerNumber)
        {
            _game = game;
            _userScore = new UserScore(user, game);
            _userScore.PlayerNumber = playerNumber;
            _canastraLimpaLabel = CANASTRALIMPA;
            _canastraSujaLabel = CANASTRASUJA;
        }

        public void SetBatida(bool bateu)
        {
            _userScore.IsBatida = bateu;
            OnPropertyChanged(nameof(UserScore));
        }

        public void SetCanastraLimpa(int value)
        {
            _userScore.TotalCanastraLimpa = value;
            _canastraLimpaLabel = CANASTRALIMPA + " (" + value.ToString() + ")";
            OnPropertyChanged(nameof(UserScore));
            OnPropertyChanged(nameof(CanastraLimpaLabel));
        }

        public void SetCanastraSuja(int value)
        {
            _userScore.TotalCanastraSuja = value;
            _canastraSujaLabel = CANASTRASUJA + " (" + value.ToString() + ")";
            OnPropertyChanged(nameof(UserScore));
            OnPropertyChanged(nameof(CanastraSujaLabel));
        }


        public void SetCartasNaMao(int value)
        {
            _userScore.TotalCardsInHand = value;
            OnPropertyChanged(nameof(UserScore));
        }

        
    }
}
