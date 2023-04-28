using System.ComponentModel.DataAnnotations.Schema;

namespace Accompany_consulting.Models
{
    public class Entretient
    {
        public int Id { get; set; }
        public string Avis { get; set; }
        public string Statut { get; set; }

     
        public Candidat Candidat { get; set; }

      
        public User Recruteur { get; set; }

      
        public User RecruteurSuivant { get; set; }

        public string Post { get; set; }
        public string DescriptionPoste { get; set; }
    }
}
