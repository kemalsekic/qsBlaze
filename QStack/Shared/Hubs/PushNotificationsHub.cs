//using Microsoft.AspNetCore.SignalR;
//using QStack.DataAccess.Models;
//using QStack.DataAccess.Models.Push;

//namespace QStack.Shared.Hubs
//{
//    public class PushNotificationsHub : Hub
//    {
//        public async Task SendMessage(string user, string invite)
//        {
//            await Clients.Others.SendAsync("ReceiveMessage", new PushModel { UserName = user, Invitation = invite });
//            //return Clients.All.SendAsync("ReceiveMessage", user, message);
//        }

//        public void Send(string userId, string message)
//        {
//            Clients.User(userId).SendAsync(message);
//        }

//        public async Task JoinRoom(string user, string groupName)
//        {
//            Console.WriteLine("Players Joined:");
//            Console.WriteLine("----");
//            Console.WriteLine("Context.ConnectionId: ", Context.ConnectionId);
//            Console.WriteLine("----");
//            await Groups.AddToGroupAsync(Context.ConnectionId, "Kemal");
//            await Clients.All.SendAsync("NewUserInSession", new PersonModel { UserName = user, GroupName = groupName });
//            //return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
//        }

//        public Task LeaveRoom(string roomName)
//        {
//            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
//        }

//        public Task SendToGroup(string roomName, string user, string message)
//        {
//            return Clients.Group(roomName).SendAsync(user, message);
//        }
//    }
//}
