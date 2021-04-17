using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MarcadorCanastra.Models;
using MarcadorCanastra.Services;
using MarcadorCanastra.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace MarcadorCanastra.ViewModels
{
    public class GamesViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Game> Games { get; set; }
        public AsyncCommand LoadGamesCommand { get; set; }
        public AsyncCommand<Game> RemoveGameCommand { get; set; }

        public IGameDataStore<Game> GameDataStore => DependencyService.Get<IGameDataStore<Game>>();

        public GamesViewModel()
        {
            Title = "Histórico de Jogos";
            Games = new ObservableRangeCollection<Game>();
            LoadGamesCommand = new AsyncCommand(ExecuteLoadGamesCommand);
            RemoveGameCommand = new AsyncCommand<Game>(RemoveGame);

            MessagingCenter.Subscribe<NewGamePage, Game>(this, "AddGame", async (obj, game) =>
            {
                var newGame = game as Game;

                await GameDataStore.AddGameAsync(newGame);
                await UpdateGameList();
            });
            MessagingCenter.Subscribe<NewUserScorePage, Round>(this, "AddRound", async (obj, round) =>
            {
                var newRound = round as Round;
                await GameDataStore.AddRoundAsync(newRound);
                await UpdateGameList();
            });
        }
        public Game LastGame()
        {
            var game = Games.OrderByDescending(x => x.Date).FirstOrDefault();
            return game;
        }

        async Task RemoveGame(Game game)
        {
            IsBusy = true;

            try
            {

                await GameDataStore.DeleteGameAsync(game.Id);
                await UpdateGameList();
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

        private async Task UpdateGameList()
        {
            Games.Clear();
            var games = await GameDataStore.GetGamesAsync(true);
            Games.AddRange(games.OrderByDescending(x => x.Date));
        }

        async Task ExecuteLoadGamesCommand()
        {
            IsBusy = true;

            try
            {
                await UpdateGameList();
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
