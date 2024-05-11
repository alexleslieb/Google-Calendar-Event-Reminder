using Event_Reminder.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Event_Reminder.Services
{
    public class GoogleCalendarService: IGoogleCalendarService
    {
        private UserCredential _userCredential;
        private CalendarService _calendarService;
        private readonly string[] _scopes = { CalendarService.Scope.CalendarReadonly, CalendarService.Scope.CalendarEventsReadonly };
        private readonly IConfigurationRoot _configurationRoot;

        public GoogleCalendarService(IConfigurationRoot configurationRoot) 
        {
            _configurationRoot = configurationRoot;
            InitializeCalendarService();
        }

        private void InitializeCalendarService()
        {
            string credentialPath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "",
                "Credentials",
                "google_api_credentials.json"
                );

            string tokenPath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "", 
                "Tokens");

            if (!Directory.Exists(tokenPath))
                Directory.CreateDirectory(tokenPath);

            string tokenFilePath = Path.Combine(tokenPath, "google_calendar_token.json");


            using(var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
            {
                _userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    _scopes,
                    _configurationRoot.GetValue<string>("UserName"),
                    CancellationToken.None,
                    new FileDataStore(tokenFilePath, true)
                    ).Result;

                Console.WriteLine($"Google Calendar token file saved to {tokenFilePath}");
            }

            _calendarService = new CalendarService(new Google.Apis.Services.BaseClientService.Initializer
            {
                HttpClientInitializer = _userCredential,
                ApplicationName = _configurationRoot.GetValue<string>("ApplicationName")
            });
        }

        public void GetEvents()
        {

        }
    }
}
