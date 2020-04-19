using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MarcadorCanastra.Models;
using MarcadorCanastra.Views;
using Xamarin.Forms;

namespace MarcadorCanastra.ViewModels
{
    public class GamesViewModel:BaseViewModel
    {
        public ObservableCollection<Game> Games { get; set; }
        public Command LoadGamesCommand { get; set; }

        public GamesViewModel()
        {
            Title = "Histórico de Jogos";
            Games = new ObservableCollection<Game>();
            LoadGamesCommand = new Command(async () => await ExecuteLoadGamesCommand());

            MessagingCenter.Subscribe<NewGamePage, Game>(this, "AddGame", async (obj, game) =>
            {
                var newGame = game as Game;
                Games.Add(newGame);
                
                await GameDataStore.AddGameAsync(newGame);
            });
            MessagingCenter.Subscribe<NewUserScorePage, Round>(this, "AddRound", async (obj, round) =>
            {
                var newRound = round as Round;
                await GameDataStore.AddRoundAsync(newRound);
                await ExecuteLoadGamesCommand();

            });

        }

        async Task ExecuteLoadGamesCommand()
        {
            IsBusy = true;

            try
            {
                Games.Clear();
                var games = await GameDataStore.GetGamesAsync(true);
                foreach (var game in games)
                {
                    Games.Add(game);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
