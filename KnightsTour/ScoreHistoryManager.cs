using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace KnightsTour
{
    public class ScoreHistoryManager
    {
        private const string DB_NAME = "database.db3";
        private readonly SQLiteAsyncConnection connection;

        public ScoreHistoryManager()
        {
            connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            //connection.CreateTableIfNotExistsAsync<ScoreTable>().Wait();
            try
            {
                CreateTableAsync();
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async Task CreateTableAsync()
        {
            await connection.CreateTableAsync<ScoreTable>();
        }

        public async Task SaveScore(int score, DateTime dateTime)
        {
            await connection.InsertAsync(new ScoreTable { Score = score, DateTime = dateTime });
        }

        internal async Task<List<ScoreTable>> LoadAllScores()
        {
            return await connection.Table<ScoreTable>().ToListAsync();
        }

        public async Task LoadScoresAsync()
        {
            try
            {
                List<ScoreTable> allScores = await LoadAllScores();
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., display an error message)
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
