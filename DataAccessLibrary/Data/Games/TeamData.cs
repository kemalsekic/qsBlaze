using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Interfaces.Games;
using DataAccessLibrary.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.Teams
{
    public class TeamData : ITeamData
    {
        private readonly ISqlDataAccess _db;

        public TeamData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<TeamsModel>> GetTeams()
        {
            string sql = "select * from dbo.Teams";

            return _db.LoadData<TeamsModel, dynamic>(sql, new { });
        }

        public Task InsertTeam(TeamsModel team)
        {
            string sql = @"insert into dbo.Teams (TeamName, TeamOwner)
                            values (@TeamName, @TeamOwner);";

            return _db.SaveData(sql, team);
        }

        public Task DeleteTeam(TeamsModel team)
        {
            string sql = @"delete from dbo.Teams where TeamId = @TeamId";

            return _db.SaveData(sql, team);
        }

        public Task EditTeam(TeamsModel team)
        {
            string sql = @"UPDATE dbo.Teams 
                            SET TeamName = @TeamName,
                                TeamOwner = @TeamOwner
                            WHERE TeamId = @TeamId";

            return _db.SaveData(sql, team);
        }

        public Task AddPlayer(PlayersModel team)
        {
            string sql = @"UPDATE dbo.TeamPlayers 
                            SET TeamName = @TeamName,
                                TeamOwner = @TeamOwner
                            WHERE TeamId = @TeamId";

            return _db.SaveData(sql, team);
        }
    }
}
