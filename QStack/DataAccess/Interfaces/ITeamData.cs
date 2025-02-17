namespace QStack.DataAccess
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