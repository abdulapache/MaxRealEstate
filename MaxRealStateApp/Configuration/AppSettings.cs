namespace MaxRealStateApp.Configuration
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _configuration;

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public Configuration GetConfiguration()
        {
            Configuration configuration = new Configuration();

            configuration.maxOwnlink = _configuration["AppSettings:maxOwnlink"];
            configuration.Email = _configuration["AppSettings:Email"];
            configuration.EmailPassword = _configuration["AppSettings:EmailPassword"];
            configuration.MaxApiUrl = _configuration["AppSettings:MaxApiUrl"];
            configuration.UploadPathUrl = _configuration["AppSettings:UploadsPath"];
            configuration.TwilioAccountSid = _configuration["AppSettings:TwilioAccountSid"];
            configuration.TwilioAuthToken = _configuration["AppSettings:TwilioAuthToken"];
            return configuration;
        }
    }
}
