using DataAccessLibrary.Models;

namespace DataAccessLibrary.Chat
{
    public interface IChatData
    {
        Task DeleteChat(ChatModel chat);
        Task EditChat(ChatModel chat);
        Task<List<ChatModel>> GetChats();
        Task InsertChat(ChatModel chat);
    }
}