using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MarcadorCanastra.Models;
using MarcadorCanastra.Views;
using Xamarin.Forms;

namespace MarcadorCanastra.ViewModels
{
    public class GameDetailViewModel : BaseViewModel
    {
        public Game Game { get; set; }
        public ObservableCollection<Round> Rounds { get { return Game.Rounds.ToObservableCollection() ; }  }        

        public GameDetailViewModel(Game game = null)
        {
            Title = game?.Date.ToString();
            Game = game;            
            MessagingCenter.Subscribe<NewUserScorePage, UserScore>(this, "AddGameScore", async (obj, userScore) =>
            {
                var newUserScore = userScore as UserScore;
                await GameDataStore.AddGameScoreAsync(newUserScore);
                OnPropertyChanged(nameof(Rounds));
            });
        }        
    }

    public static class ObservableExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this List<T> items)
        {
            ObservableCollection<T> collection = new ObservableCollection<T>();

            foreach (var item in items)
            {
                collection.Add(item);
            }

            return collection;
        }
    }
    
}
