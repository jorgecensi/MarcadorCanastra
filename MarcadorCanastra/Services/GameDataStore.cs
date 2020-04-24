using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarcadorCanastra.Models;

namespace MarcadorCanastra.Services
{
    public class GameDataStore: IGameDataStore<Game>
    {
        //readonly List<Game> games = new List<Game>();
        public GameDataStore()
        {
            
        }

        public async Task<bool> AddGameAsync(Game game)
        {
            await App.Database.SaveGameAsync(game);
            

            return await Task.FromResult(true);
        }

        public async Task<bool> AddRoundAsync(Round round)
        {
            var games = await App.Database.GetGamesAsync();

            var game = round.Game;

            var gameToUpdate = games.Where(x => x.Id == game.Id).FirstOrDefault();
            round.RoundNumber = game.Rounds.Count() + 1;
            gameToUpdate.AddRound(round);
            await App.Database.SaveGameAsync(gameToUpdate);
            return await Task.FromResult(true);

        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            //var oldGame = games.Where((Game arg) => arg.Id == id).FirstOrDefault();
            //games.Remove(oldGame);

            return await Task.FromResult(true);
        }

        public async Task<Game> GetGameAsync(int id)
        {
            var game = await App.Database.GetGameAsync(id);
            return game;
        }

        public async Task<IEnumerable<Game>> GetGamesAsync(bool forceRefresh = false)
        {
            return await App.Database.GetGamesAsync();
        }

        public async Task<bool> UpdateGameAsync(Game game)
        {
            //games.Add(game);

            return await Task.FromResult(true);
        }
    }
}
