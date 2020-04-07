using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarcadorCanastra.Models;

namespace MarcadorCanastra.Services
{
    public interface IGameDataStore<T>
    {
        Task<bool> AddGameAsync(T game);
        Task<bool> UpdateGameAsync(T game);
        Task<bool> DeleteGameAsync(string id);
        Task<T> GetGameAsync(string id);
        Task<IEnumerable<T>> GetGamesAsync(bool forceRefresh = false);
        Task<bool> AddGameScoreAsync(UserScore userScore);
        
    }
}
