using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Interfaces.Games;
using DataAccessLibrary.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.Games
{
    public class GameData : IGameData
    {
        private readonly ISqlDataAccess _db;

        public GameData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<GamesModel>> GetGames()
        {
            string sql = "select * from dbo.Games";

            return _db.LoadData<GamesModel, dynamic>(sql, new { });
        }

        public Task InsertGame(GamesModel game)
        {
            string sql = @"insert into dbo.Games (GameName, GameDate, GameHost)
                            values (@GameName, @GameDate, @GameHost);";

            return _db.SaveData(sql, game);
        }

        public Task DeleteGame(GamesModel game)
        {
            string sql = @"delete from dbo.Games where GameId = @GameId";

            return _db.SaveData(sql, game);
        }

        public Task EditGame(GamesModel game)
        {
            string sql = @"UPDATE dbo.Games 
                            SET GameName = @GameName,
                                GameDate = @GameDate,
                                GameHost = @GameHost
                            WHERE GameId = @GameId";

            return _db.SaveData(sql, game);
        }
    }
}
