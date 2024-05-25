using Event_Reminder.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Event_Reminder.Services
{
    public class GMailService: IGMailService
    {
        private UserCredential _userCredential;
        private GmailService _gmailService;
        private readonly string[] _scopes = { GmailService.Scope.GmailSend, GmailService.Scope.GmailCompose, GmailService.Scope.MailGoogleCom };
        private readonly IConfigurationRoot _configurationRoot;

        public GMailService(IConfigurationRoot configurationRoot) 
        {
            _configurationRoot = configurationRoot;
            InitializeGMailService();
        }

        private void InitializeGMailService()
        {
            string credentialPath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "",
                "Credentials",
                "google_api_credentials.json"
                );

            string tokenPath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "",
                "Tokens/GmailToken");

            if (!Directory.Exists(tokenPath))
                Directory.CreateDirectory(tokenPath);

            using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
            {
                _userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    _scopes,
                    _configurationRoot.GetValue<string>("UserName"),
                    CancellationToken.None,
                    new FileDataStore(tokenPath, true)
                    ).Result;

                Console.WriteLine($"GMail token file saved to {tokenPath}");
            }

            _gmailService = new GmailService(new Google.Apis.Services.BaseClientService.Initializer
            {
                HttpClientInitializer = _userCredential,
                ApplicationName = _configurationRoot.GetValue<string>("ApplicationName")
            });
        }

        public void SendEmail(string to,  string subject, string body)
        {
            string rawMessage = "To: " + to + "\r\n" +
                               "Subject: " + subject + "\r\n" +
                               "Content-Type: text/html; charset=us-ascii\r\n\r\n" +
                               body;

            Message message = new Message();
            message.Raw = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(rawMessage));
            _gmailService.Users.Messages.Send(message, "me").Execute();
        }
    }
}
