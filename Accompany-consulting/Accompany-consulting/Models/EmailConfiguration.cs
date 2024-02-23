namespace Accompany_consulting.Models
{
    public class EmailConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailCc { get; set; }
        public string NameCc { get; set; }
    }

}
