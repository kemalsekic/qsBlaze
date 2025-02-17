using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Chat
{
    public class ChatData : IChatData
    {
        private readonly ISqlDataAccess _db;

        public ChatData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<ChatModel>> GetChats()
        {
            string sql = "select * from dbo.ChatMessage";

            return _db.LoadData<ChatModel, dynamic>(sql, new { });
        }

        public Task InsertChat(ChatModel chat)
        {
            string sql = @"insert into dbo.ChatMessage (UserName, ChatText, TimeStamp, UserId )
                            values (@UserName, @ChatText, @TimeStamp, @UserId);";

            return _db.SaveData(sql, chat);
        }

        public Task DeleteChat(ChatModel chat)
        {
            string sql = @"delete from dbo.ChatMessage where Id = @Id";

            return _db.SaveData(sql, chat);
        }

        public Task EditChat(ChatModel chat)
        {
            string sql = @"UPDATE dbo.ChatMessage 
                            SET UserName = @UserName,
                                ChatText = @ChatText,
                                TimeStamp = @TimeStamp,
                                UserId = @UserId
                            WHERE Id = @Id";

            return _db.SaveData(sql, chat);
        }
    }
}
