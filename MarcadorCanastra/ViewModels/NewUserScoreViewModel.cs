﻿using System;
using MarcadorCanastra.Models;

namespace MarcadorCanastra.ViewModels
{
    public class NewUserScoreViewModel:BaseViewModel
    {
        private Game _game;
        private GameDetailViewModel _gameDetailViewModel;
        private Round _round;
        public Round Round
        {
            get => _round;
            set
            {
                _round = value;
                OnPropertyChanged(nameof(Round));
                OnPropertyChanged(nameof(_gameDetailViewModel.Game));
            }
        }

        
        
        public int TotalCardsInHand
        {

            get => _round.Player1Score.TotalCardsInHand;
            set
            {
                _round.Player1Score.TotalCardsInHand = value;
                OnPropertyChanged(nameof(Round));
            }
        }

        public int TotalCardsInHand2
        {

            get => _round.Player2Score.TotalCardsInHand;
            set
            {
                _round.Player2Score.TotalCardsInHand = value;
                OnPropertyChanged(nameof(Round));
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
        private string _canastraLimpaLabel2;
        public string CanastraLimpaLabel2
        {
            get => _canastraLimpaLabel2;
            set
            {
                _canastraLimpaLabel2 = value;
                OnPropertyChanged(nameof(CanastraLimpaLabel2));
            }
        }

        private string _canastraSujaLabel2;
        public string CanastraSujaLabel2
        {
            get => _canastraSujaLabel2;
            set
            {
                _canastraSujaLabel2 = value;
                OnPropertyChanged(nameof(CanastraSujaLabel2));
            }
        }

        const string CANASTRALIMPA = "Canastra Limpa";
        const string CANASTRASUJA = "Canastra Suja";

        public NewUserScoreViewModel(GameDetailViewModel viewModel)
        {
            _game = viewModel.Game;
            _gameDetailViewModel = viewModel;
            _round = new Round()
            {
                Game = viewModel.Game,
                Player1Score = new UserScore(viewModel.Game.Player1, viewModel.Game) { PlayerNumber = 1 },
                Player2Score = new UserScore(viewModel.Game.Player2, viewModel.Game) { PlayerNumber = 2 }
            };
            
            
            _canastraLimpaLabel = CANASTRALIMPA;
            _canastraSujaLabel = CANASTRASUJA;
            _canastraLimpaLabel2 = CANASTRALIMPA;
            _canastraSujaLabel2 = CANASTRASUJA;
        }
        public void Salva()
        {
            _gameDetailViewModel.Game = _game;
        }

        public void SetBatida(bool bateu)
        {
            _round.Player1Score.IsBatida = bateu;
            OnPropertyChanged(nameof(Round));
        }
        public void SetBatida2(bool bateu)
        {
            _round.Player2Score.IsBatida = bateu;
            OnPropertyChanged(nameof(Round));
        }

        public void SetCanastraLimpa(int value)
        {
            _round.Player1Score.TotalCanastraLimpa = value;
            _canastraLimpaLabel = CANASTRALIMPA + " (" + value.ToString() + ")";
            OnPropertyChanged(nameof(Round));
            OnPropertyChanged(nameof(CanastraLimpaLabel));
        }
        public void SetCanastraLimpa2(int value)
        {
            _round.Player2Score.TotalCanastraLimpa = value;
            _canastraLimpaLabel2 = CANASTRALIMPA + " (" + value.ToString() + ")";
            OnPropertyChanged(nameof(Round));
            OnPropertyChanged(nameof(CanastraLimpaLabel2));
        }

        public void SetCanastraSuja(int value)
        {
            _round.Player1Score.TotalCanastraSuja = value;
            _canastraSujaLabel = CANASTRASUJA + " (" + value.ToString() + ")";
            OnPropertyChanged(nameof(Round));
            OnPropertyChanged(nameof(CanastraSujaLabel));
        }

        public void SetCanastraSuja2(int value)
        {
            _round.Player2Score.TotalCanastraSuja = value;
            _canastraSujaLabel2 = CANASTRASUJA + " (" + value.ToString() + ")";
            OnPropertyChanged(nameof(Round));
            OnPropertyChanged(nameof(CanastraSujaLabel2));
        }


        public void SetCartasNaMao(int value)
        {
            _round.Player1Score.TotalCardsInHand = value;
            OnPropertyChanged(nameof(Round));
        }

        public void SetCartasNaMao2(int value)
        {
            _round.Player2Score.TotalCardsInHand = value;
            OnPropertyChanged(nameof(Round));
        }


    }
}
