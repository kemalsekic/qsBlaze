using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data
{
    public class SkillsData : ISkillsData
    {
        private readonly ISqlDataAccess _db;

        public SkillsData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<SkillsModel>> GetSkills()
        {
            string sql = "select * from dbo.Skills";

            return _db.LoadData<SkillsModel, dynamic>(sql, new { });
        }

        //public Task GetSkills(SkillsModel skill, int Id)
        //{
        //    string sql = "select * from dbo.Skills where Id = @Id";

        //    return _db.LoadSkill(sql, new { });
        //}

        public Task InsertSkill(SkillsModel skill)
        {
            string sql = @"insert into dbo.Skills (Title, Description, SkillLevel, UpVotes, DownVotes)
                            values (@Title, @Description, @SkillLevel, @UpVotes, @DownVotes);";

            return _db.SaveData(sql, skill);
        }

        public Task DeleteSkill(SkillsModel skill)
        {
            string sql = @"delete from dbo.Skills where Id = @SkillID";

            return _db.SaveData(sql, skill);
        }

        public Task EditSkill(SkillsModel skill)
        {
            string sql = @"UPDATE dbo.Skills 
                            SET Title = @Title,
                                Description = @Description,
                                SkillLevel = @SkillLevel,
                                UpVotes = @UpVotes,
                                DownVotes = @DownVotes
                            WHERE SkillID = @SkillID";

            return _db.SaveData(sql, skill);
        }
    }
}
