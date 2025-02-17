using DataAccessLibrary.Models.Teams;

namespace DataAccessLibrary.Interfaces.Games
{
    public interface IPlayerData
    {
        Task AddPhoneNumber(PlayersModel player);
        Task DeletePlayer(PlayersModel player);
        Task EditPlayer(PlayersModel player);
        Task EditPlayerPhoneNumber(PlayersModel player);
        Task<List<PlayersModel>> GetPlayers();
        Task InsertPlayer(PlayersModel player);
    }
}