using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public interface ITicketData
    {
        Task DeleteTicket(VoteTicketModel ticket);
        Task EditTicket(VoteTicketModel ticket);
        Task<List<VoteTicketModel>> GetTickets();
        Task InsertTicket(VoteTicketModel ticket);
    }
}