using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Interfaces.Games;
using DataAccessLibrary.Models.Sports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.Games
{
    public class SportData : ISportData
    {
        private readonly ISqlDataAccess _db;

        public SportData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<SportsModel>> GetPeople()
        {
            string sql = "select * from dbo.SportsList";

            return _db.LoadData<SportsModel, dynamic>(sql, new { });
        }

        public Task InsertSport(SportsModel sport)
        {
            string sql = @"insert into dbo.SportsList (SportName)
                            values (@SportName);";

            return _db.SaveData(sql, sport);
        }

        public Task DeleteSport(SportsModel sport)
        {
            string sql = @"delete from dbo.SportsList where SportId = @SportId";

            return _db.SaveData(sql, sport);
        }

        public Task EditSport(SportsModel sport)
        {
            string sql = @"UPDATE dbo.SportsList 
                            SET SportName = @SportName
                            WHERE SportId = @SportId";

            return _db.SaveData(sql, sport);
        }
    }
}
