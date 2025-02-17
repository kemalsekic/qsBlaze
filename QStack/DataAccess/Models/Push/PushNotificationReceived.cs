using CommunityToolkit.Mvvm.Messaging.Messages;

namespace QStack.DataAccess.Models.Push
{
    public class PushNotificationReceived : ValueChangedMessage<string>
    {
        public PushNotificationReceived(string message) : base(message) { }
    }
}
