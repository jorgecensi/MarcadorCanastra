using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarcadorCanastra.Models;

namespace MarcadorCanastra.Services
{
    public class MockGameDataStore: IGameDataStore<Game>
    {
        readonly List<Game> games = new List<Game>();
        public MockGameDataStore()
        {
            var user1 = new User { Name = "Jorge" };
            var user2 = new User { Name = "Raquel" };

            

            var game1 = new Game(user1, user2)
            {
                Id = Guid.NewGuid().ToString(),                
                Date = new DateTime(2020, 03, 20)
            };

            var game2 = new Game(user1, user2)
            {
                Id = Guid.NewGuid().ToString(),
                Date = new DateTime(2020, 03, 21)
            };

            var game3 = new Game(user1, user2)
            {
                Id = Guid.NewGuid().ToString(),
                Date = new DateTime(2020, 03, 22)
            };

            var userscore1 = new UserScore(user1,game1) { PlayerNumber = 1, IsBatida = true, TotalCanastraLimpa = 1, TotalCanastraSuja = 1, TotalCardsInHand = 10 };
            var userscore2 = new UserScore(user2, game1) { PlayerNumber = 2, IsBatida = false, TotalCanastraLimpa = 1, TotalCanastraSuja = 1, TotalCardsInHand = 10 };

            var userscore3 = new UserScore(user1, game2) { PlayerNumber = 1, IsBatida = true, TotalCanastraLimpa = 1, TotalCanastraSuja = 1, TotalCardsInHand = 10 };
            var userscore4 = new UserScore(user2, game2) { PlayerNumber = 2, IsBatida = false, TotalCanastraLimpa = 1, TotalCanastraSuja = 1, TotalCardsInHand = 10 };

            var userscore5 = new UserScore(user1, game3) { PlayerNumber = 1, IsBatida = true, TotalCanastraLimpa = 1, TotalCanastraSuja = 1, TotalCardsInHand = 10 };
            var userscore6 = new UserScore(user2, game3) { PlayerNumber = 2, IsBatida = false, TotalCanastraLimpa = 1, TotalCanastraSuja = 1, TotalCardsInHand = 10 };

            var round1 = new Round { RoundNumber = 1, Player1Score = userscore1, Player2Score = userscore2 };
            var round2 = new Round { RoundNumber = 2, Player1Score = userscore1, Player2Score = userscore2 };
            var round3 = new Round { RoundNumber = 3, Player1Score = userscore1, Player2Score = userscore2 };

            var round4 = new Round { RoundNumber = 1, Player1Score = userscore3, Player2Score = userscore4 };

            var round5 = new Round { RoundNumber = 1, Player1Score = userscore5, Player2Score = userscore6 };

            game1.Rounds = new List<Round> { round1, round2, round3 };
            game2.Rounds = new List<Round> { round4};
            game3.Rounds = new List<Round> { round5};

            games.Add(game1);
            games.Add(game2);
            games.Add(game3);
        }

        public async Task<bool> AddGameAsync(Game game)
        {
            games.Add(game);

            return await Task.FromResult(true);
        }

        public async Task<bool> AddRoundAsync(Round round)
        {
            var game = round.Game;

            var gameToUpdate = games.Where(x => x.Id == game.Id).FirstOrDefault();
            round.RoundNumber = game.Rounds.Count() + 1;
            gameToUpdate.AddRound(round);

            return await Task.FromResult(true);

        }

        public async Task<bool> DeleteGameAsync(string id)
        {
            var oldGame = games.Where((Game arg) => arg.Id == id).FirstOrDefault();
            games.Remove(oldGame);

            return await Task.FromResult(true);
        }

        public async Task<Game> GetGameAsync(string id)
        {
            return await Task.FromResult(games.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Game>> GetGamesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(games);
        }

        public async Task<bool> UpdateGameAsync(Game game)
        {
            games.Add(game);

            return await Task.FromResult(true);
        }
    }
}
