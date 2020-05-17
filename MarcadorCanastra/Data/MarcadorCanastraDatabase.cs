using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarcadorCanastra.Models;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensionsAsync.Extensions;

namespace MarcadorCanastra.Data
{
    public class MarcadorCanastraDatabase
    {
        public MarcadorCanastraDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(User).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(User)).ConfigureAwait(false);
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(UserScore)).ConfigureAwait(false);
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Round)).ConfigureAwait(false);
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Game)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public async Task<List<Game>> GetGamesAsync()
        {
            var games = await Database.GetAllWithChildrenAsync<Game>(recursive: true);
            return games;
        }

        

        public Task<Game> GetGameAsync(int id)
        {
            return Database.Table<Game>().Where(i => i.Id  == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveGameAsync(Game game)
        {
            if (game.Id != 0)
            {
                var round = game.Rounds.Where(x => x.Id == 0).Single();
                
                await Database.InsertWithChildrenAsync(round);
                await Database.UpdateWithChildrenAsync(game);
                return await Task.FromResult(true);
            }
            else
            {

                await Database.InsertWithChildrenAsync(game);
                return await Task.FromResult(true);
            }
        }

        public Task<int> DeleteGameAsync(Game game)
        {
            return Database.DeleteAsync(game);
        }
    }
}
