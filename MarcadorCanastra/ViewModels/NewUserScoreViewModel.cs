using System;
using MarcadorCanastra.Models;

namespace MarcadorCanastra.ViewModels
{
    public class NewUserScoreViewModel:BaseViewModel
    {
        private UserScore _userScore;
        public UserScore UserScore {
            get => _userScore;
            set
            {
                _userScore = value;
                OnPropertyChanged(nameof(UserScore));
            } 
        }
        
        public int TotalCardsInHand {
            get => _userScore.TotalCardsInHand;
            set
            {
                _userScore.TotalCardsInHand = value;
                OnPropertyChanged(nameof(UserScore));
            }
        }



        public NewUserScoreViewModel()
        {
            _userScore = new UserScore(new User { Name = "Jorge"});
        }

        public void SetBatida(bool bateu)
        {
            _userScore.IsBatida = bateu;
            OnPropertyChanged(nameof(UserScore));
        }

        public void SetCanastraLimpa(int value)
        {
            _userScore.TotalCanastraLimpa = value;
            OnPropertyChanged(nameof(UserScore));
        }

        public void SetCanastraSuja(int value)
        {
            _userScore.TotalCanastraSuja = value;
            OnPropertyChanged(nameof(UserScore));
        }


        public void SetCartasNaMao(int value)
        {
            _userScore.TotalCardsInHand = value;
            OnPropertyChanged(nameof(UserScore));
        }

        
    }
}
