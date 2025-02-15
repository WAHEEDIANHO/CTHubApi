namespace CThub.Application.Notification;

public interface IFCMMessaging
{
    public Task SendDirectNotification(string token);
}