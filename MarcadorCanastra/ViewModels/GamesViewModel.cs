using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MarcadorCanastra.Models;
using MarcadorCanastra.Services;
using MarcadorCanastra.Views;
using MvvmHelpers;
using Xamarin.Forms;

namespace MarcadorCanastra.ViewModels
{
    public class GamesViewModel:BaseViewModel
    {
        public ObservableRangeCollection<Game> Games { get; set; }
        public Command LoadGamesCommand { get; set; }

        public IGameDataStore<Game> GameDataStore => DependencyService.Get<IGameDataStore<Game>>();

        public GamesViewModel()
        {
            Title = "Histórico de Jogos";
            Games = new ObservableRangeCollection<Game>();
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
                Games.Clear();
                var games = await GameDataStore.GetGamesAsync(true);
                Games.AddRange(games);
            });
        }
        public Game LastGame()
        {
            var game = Games.OrderByDescending(x => x.Date).FirstOrDefault();
            return game;
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
