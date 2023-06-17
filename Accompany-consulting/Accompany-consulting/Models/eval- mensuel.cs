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

        public string Qualité { get; set; }
        public string Délai { get; set; }
        public string périmètre { get; set; }

        public string Budge { get; set; }

    }
}
