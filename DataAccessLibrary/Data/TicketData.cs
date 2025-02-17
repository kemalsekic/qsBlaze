using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data
{
    public class TicketData : ITicketData
    {
        private readonly ISqlDataAccess _db;

        public TicketData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<VoteTicketModel>> GetTickets()
        {
            string sql = "select * from dbo.Tickets";

            return _db.LoadData<VoteTicketModel, dynamic>(sql, new { });
        }

        //public Task GetTicket(VoteTicketModel ticket, int Id)
        //{
        //    string sql = "select * from dbo.Tickets where Id = @TicketId";

        //    return _db.LoadTicket(sql, new { });
        //}

        public Task InsertTicket(VoteTicketModel ticket)
        {
            string sql = @"insert into dbo.Tickets (TicketTitle, TicketDescription, CreatedBy, CreatedOn, TicketNumber)
                            values  (@Title, @Description, @CreatedBy, @CreatedOn, @TicketNumber);";
            return _db.SaveData(sql, ticket);
        }

        public Task DeleteTicket(VoteTicketModel ticket)
        {
            string sql = @"delete from dbo.Tickets where Id = @TicketId";

            return _db.SaveData(sql, ticket);
        }

        public Task EditTicket(VoteTicketModel ticket)
        {
            string sql = @"UPDATE dbo.Tickets 
                            SET Title = @TicketTitle,
                                Description = @TicketDescription,
                                CreatedBy = @CreatedBy,
                                CreatedOn = @CreatedOn,
                                TicketNumber = @TicketNumber
                            WHERE Id = @TicketId";

            return _db.SaveData(sql, ticket);
        }
    }
}
