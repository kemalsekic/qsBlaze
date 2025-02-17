using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data
{
    public class VoteData : IVoteData
    {
        private readonly ISqlDataAccess _db;

        public VoteData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<VoteModel>> GetVotes()
        {
            string sql = "select * from dbo.Votes";

            return _db.LoadData<VoteModel, dynamic>(sql, new { });
        }

        //public Task GetVote(VoteModel vote, int Id)
        //{
        //    string sql = "select * from dbo.Votes where Id = @VoteId";

        //    return _db.LoadVote(sql, new { });
        //}

        public Task InsertVote(VoteModel vote)
        {
            string sql = @"insert into dbo.Votes (VoteNumber, VoteDate, VoteValue, SessionId, UserName)
                            values  (@VoteNumber, @VoteDate, @VoteValue, @SessionId, @UserName);";
            return _db.SaveData(sql, vote);
        }

        public Task DeleteVote(VoteModel vote)
        {
            string sql = @"delete from dbo.Votes where VoteId = @VoteId";

            return _db.SaveData(sql, vote);
        }

        public Task EditVote(VoteModel vote)
        {
            string sql = @"UPDATE dbo.Votes 
                            SET Title = @VoteNumber,
                                @PersonID,
                                @VoteDate,
                                @VoteValue
                            WHERE VoteId = @VoteId";

            return _db.SaveData(sql, vote);
        }
    }
}
