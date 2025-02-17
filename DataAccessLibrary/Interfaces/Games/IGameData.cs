using DataAccessLibrary.Models.Games;

namespace DataAccessLibrary.Interfaces.Games
{
    public interface IGameData
    {
        Task DeleteGame(GamesModel game);
        Task EditGame(GamesModel game);
        Task<List<GamesModel>> GetGames();
        Task InsertGame(GamesModel game);
    }
}