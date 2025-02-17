using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Interfaces.Games;
using DataAccessLibrary.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.Games
{
    public class PlayerData : IPlayerData
    {
        private readonly ISqlDataAccess _db;

        public PlayerData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<PlayersModel>> GetPlayers()
        {
            string sql = "select * from dbo.Players";

            return _db.LoadData<PlayersModel, dynamic>(sql, new { });
        }

        public Task InsertPlayer(PlayersModel player)
        {
            string sql = @"insert into dbo.Players (FirstName, LastName, UserName, EmailAddress, PhoneNumber)
                            values (@FirstName, @LastName, @UserName, @EmailAddress, @PhoneNumber);";

            return _db.SaveData(sql, player);
        }

        public Task AddPhoneNumber(PlayersModel player)
        {
            string sql = @"insert into dbo.Players (PhoneNumber)
                            values (@PhoneNumber);";

            return _db.SaveData(sql, player);
        }

        public Task DeletePlayer(PlayersModel player)
        {
            string sql = @"delete from dbo.Players where PlayerId = @PlayerId";

            return _db.SaveData(sql, player);
        }

        public Task EditPlayer(PlayersModel player)
        {
            string sql = @"UPDATE dbo.Players 
                            SET FirstName = @FirstName,
                                LastName = @LastName,
                                UserName = @UserName,
                                EmailAddress = @EmailAddress,
                                Color = @Color,
                                AssignedPoints = @AssignedPoints
                            WHERE PlayerId = @PlayerId";

            return _db.SaveData(sql, player);
        }

        public Task EditPlayerPhoneNumber(PlayersModel player)
        {
            string sql = @"UPDATE dbo.Players 
                            SET Color = @Color
                            WHERE PhoneNumber = @PhoneNumber";

            return _db.SaveData(sql, player);
        }
    }
}
