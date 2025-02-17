using DataAccessLibrary.Models;
using Microsoft.AspNetCore.SignalR;
using NuGet.Protocol.Plugins;
using System.Xml.Linq;

namespace qsBlaze.Shared.Hubs
{
    public class VoteHub : Hub
    {
        public async Task SendMessage(string user, string vote)
        {
            await Clients.Others.SendAsync("ReceiveMessage", new VoteModel { UserName = user, VoteValueString = vote });
            //return Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public void Send(string userId, string message)
        {
            Clients.User(userId).SendAsync(message);
        }

        public async Task JoinRoom(string user, string groupName)
        {
            Console.WriteLine("JoinRoom:");
            Console.WriteLine("----");
            Console.WriteLine("Context.ConnectionId: ",Context.ConnectionId);
            Console.WriteLine("----");
            await Groups.AddToGroupAsync(Context.ConnectionId, "Kemal");
            await Clients.All.SendAsync("NewUserInSession", new PersonModel { UserName = user, GroupName = groupName });
            //return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        public Task LeaveRoom(string roomName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        public Task SendToGroup(string roomName, string user, string message)
        {
            return Clients.Group(roomName).SendAsync(user, message);
        }

        //public Task VoteMessage(string vote)
        //{
        //    Console.WriteLine("VoteMessage");
        //    Console.WriteLine($"vote, {vote}");
        //    Console.WriteLine("-----------------");
        //    Console.WriteLine("");
        //    return Clients.All.SendAsync("ReceiveVoteMessage", vote);
        //}

        //public async Task JoinSession(string username)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, Context.GetHttpContext().Request.Query["sessionId"]);
        //    await Clients.GroupExcept(Context.GetHttpContext().Request.Query["sessionId"], Context.ConnectionId).SendAsync("ReceiveMessage", $"{username} has joined the session.");
        //    await Clients.Group("sessionId").SendAsync("Send", $"{Context.ConnectionId} has joined the group.");

        //    string seshID = Context.GetHttpContext().Request.Query["sessionId"].ToString();
        //    Console.WriteLine("JoinSession");
        //    Console.WriteLine($"username, {username}");
        //    Console.WriteLine($"sessionId, {seshID}");
        //    Console.WriteLine("-----------------");
        //    Console.WriteLine("");
        //}

        //public async Task SubmitVote(int value, string username)
        //{
        //    //await Clients.Group(sessionId).SendAsync("ReceiveVote", new Vote { Username = username, Value = value });
        //    //await Clients.Group(Context.GetHttpContext().Request.Query[sessionId]).SendAsync("ReceiveVote", new Vote { Username = username, Value = value });
        //    await Clients.Group(Context.GetHttpContext().Request.Query["sessionId"]).SendAsync("ReceiveVote", new VoteModel { UserName = Context.User.Identity.Name, VoteValue = value });

        //    string seshID = Context.GetHttpContext().Request.Query["sessionId"].ToString();
        //    Console.WriteLine("SubmitVote");
        //    Console.WriteLine($"username, {username}");
        //    Console.WriteLine($"sessionId, {seshID}");
        //    Console.WriteLine("-----------------");
        //    Console.WriteLine("");
        //}

    }
}
