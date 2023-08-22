using System.ComponentModel.DataAnnotations.Schema;

namespace Accompany_consulting.Models
{
    public class eval__mensuel
    {
        public int Id { get; set; }

        [ForeignKey("ConsultantId")]
        public int Consultant { get; set; }
        [ForeignKey("ManagerId")]
        public int Manager { get; set; }

        [ForeignKey("MissionId")]
        public int Mission { get; set; }

        public string Qualite { get; set; }
        public string Delai { get; set; }
        public string perimetre { get; set; }

        public string Budge { get; set; }

        public int nbeval { get; set; } 

    }
}
