using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public interface IVoteData
    {
        Task DeleteVote(VoteModel vote);
        Task EditVote(VoteModel vote);
        Task<List<VoteModel>> GetVotes();
        Task InsertVote(VoteModel vote);
    }
}