using DataAccessLibrary.Models.Sports;

namespace DataAccessLibrary.Interfaces.Games
{
    public interface ISportData
    {
        Task DeleteSport(SportsModel sport);
        Task EditSport(SportsModel sport);
        Task<List<SportsModel>> GetPeople();
        Task InsertSport(SportsModel sport);
    }
}