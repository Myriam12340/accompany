namespace Accompany_consulting.Models
{
    public class EmailMessage
    {
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string ToName { get; set; }
        public string ToEmail { get; set; }
        public string CcName { get; set; } // Nom pour le destinataire en copie
        public string CcEmail { get; set; } // Adresse e-mail pour le destinataire en copie
        public string Subject { get; set; }
        public string Body { get; set; }
        public string UserEmail { get; set; } // Champ pour l'adresse e-mail de l'utilisateur

    }

}
