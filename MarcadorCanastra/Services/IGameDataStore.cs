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
        Task<bool> DeleteGameAsync(int id);
        Task<T> GetGameAsync(int id);
        Task<IEnumerable<T>> GetGamesAsync(bool forceRefresh = false);
        
        Task<bool> AddRoundAsync(Round round);
    }
}
