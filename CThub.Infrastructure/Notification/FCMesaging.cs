using CThub.Application.Notification;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace CThub.Infrastructure.Notification;

public class FCMesaging: IFCMMessaging
{
    private readonly FirebaseApp _firebaseApp;
    
    public FCMesaging()
    {
        string filePath = "./cthub-438d5-firebase-adminsdk-fbsvc-53a1cc1e18.json";

        using (var serviceAcct = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            _firebaseApp = FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromStream(serviceAcct)
            });

        }
    }


    public async Task SendDirectNotification(string token)
    {
        var message = new Message()
        {
            Data = new Dictionary<string, string>()
            {
                { "score", "850" },
                { "time", "2:45" },
            },
            Token = token,
        };

        await FirebaseMessaging.DefaultInstance.SendAsync(message);
    }
}