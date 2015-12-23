// ReSharper disable InconsistentNaming
namespace Mattermost.Client
{
    public class EmailSettings
    {
        public bool EnableSignUpWithEmail { get; set; }
        public bool SendEmailNotifications { get; set; }
        public bool RequireEmailVerification { get; set; }
        public string FeedbackName { get; set; }
        public string FeedbackEmail { get; set; }
        public string SMTPUsername { get; set; }
        public string SMTPPassword { get; set; }
        public string SMTPServer { get; set; }
        public string SMTPPort { get; set; }
        public string ConnectionSecurity { get; set; }
        public string InviteSalt { get; set; }
        public string PasswordResetSalt { get; set; }
        public bool SendPushNotifications { get; set; }
        public string PushNotificationServer { get; set; }
    }
}