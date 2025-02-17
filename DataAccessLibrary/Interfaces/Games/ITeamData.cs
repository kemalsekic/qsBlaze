using DataAccessLibrary.Models.Teams;

namespace DataAccessLibrary.Interfaces.Games
{
    public interface ITeamData
    {
        Task DeleteTeam(TeamsModel team);
        Task EditTeam(TeamsModel team);
        Task<List<TeamsModel>> GetTeams();
        Task InsertTeam(TeamsModel team);
        Task AddPlayer(PlayersModel player);
    }
}