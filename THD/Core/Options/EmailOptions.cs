namespace THD.Web.Core.Options
{
    public class EmailOptions
    {
        public const string Name = "Email";

        public string FromEmail { get; set; }

        public string FromEmailPassword { get; set; }

        public SmtpClientOptions SmtpClient { get; set; }
    }

    public class SmtpClientOptions
    {
        public const string Name = "SmtpClient";

        public string Host { get; set; }

        public int Port { get; set; }

        public bool EnableSsl { get; set; }
    }
}
