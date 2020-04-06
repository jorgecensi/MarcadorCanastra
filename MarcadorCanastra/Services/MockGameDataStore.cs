using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarcadorCanastra.Models;

namespace MarcadorCanastra.Services
{
    public class MockGameDataStore: IGameDataStore<Game>
    {
        readonly List<Game> games;
        public MockGameDataStore()
        {
            var user1 = new User { Name = "Jorge" };
            var user2 = new User { Name = "Raquel" };

            var userscore1 = new UserScore(user1) {PlayerNumber = 1,  IsBatida = true, TotalCanastraLimpa = 1, TotalCanastraSuja = 1, TotalCardsInHand = 10 };
            var userscore2 = new UserScore(user2) {PlayerNumber= 2, IsBatida = false, TotalCanastraLimpa = 1, TotalCanastraSuja = 1, TotalCardsInHand = 10 };

            var round1 = new Round { RoundNumber =1, Scores = new List<UserScore> { userscore1, userscore2 } };
            var round2 = new Round { RoundNumber = 2, Scores = new List<UserScore> { userscore1, userscore2 } };
            var round3 = new Round { RoundNumber = 3, Scores = new List<UserScore> { userscore1, userscore2 } };

            games = new List<Game>()
            {
                new Game( new List<User>{user1,user2 })
                {
                    Id = Guid.NewGuid().ToString(),
                    Rounds = new List<Round>{ round1, round2, round3},                    
                    Date = new DateTime(2020,03,20)
                },
                new Game( new List<User>{user1,user2 })
                {
                    Id = Guid.NewGuid().ToString(),
                    Rounds = new List<Round>{ round1, round2, round3},
                    Date = new DateTime(2020,03,21)
                },
                new Game( new List<User>{user1,user2 })
                {
                    Id = Guid.NewGuid().ToString(),
                    Rounds = new List<Round>{ round1, round2, round3},
                    Date = new DateTime(2020,03,22)
                }
            };
        }

        public Task<bool> AddGameAsync(Game game)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGameAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetGameAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Game>> GetGamesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(games);
        }

        public Task<bool> UpdateGameAsync(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
