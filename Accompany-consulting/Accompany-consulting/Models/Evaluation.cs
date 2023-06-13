using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accompany_consulting.Models
{
    public class Evaluation
    {
        public int Id { get; set; }

        [ForeignKey("hr_id")]
        public int Hr { get; set; }
        [ForeignKey("consultant_id")]
        public int consultant { get; set; }

        public int? ProcessusR { get; set; }
        public int? CommunicationInterne { get; set; }
        public int? Relation { get; set; }
        public int? Rapport { get; set; }
        public int? Outils { get; set; }
        public int? Pt24 { get; set; }
        public int? Formation { get; set; }
        public int? ProcessRH { get; set; }

        public string? AdmC { get; set; }
        public string? AdmRH { get; set; }
        public string? CommunicationC { get; set; }
        public string? CommunicationRH { get; set; }
        public string? EspritEquipeC { get; set; }
        public string? EspritEquipeRH { get; set; }

        public string? ProjetInterneC { get; set; }
        public string? DevCommercialC { get; set; }
        public string? VieCabinetC { get; set; }
        public string? ProjetInterneRH { get; set; }
        public string? DevCommercialRH { get; set; }
        public string? VieCabinetRH { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date_evaluation { get; set; }

        public string type_eval { get; set; }

        // Nouveaux champs
        public string? ProcessRH_com { get; set; }
        public string? Formation_com { get; set; }
        public string? Pt24_com { get; set; }
        public string? Outils_com { get; set; }
        public string? Rapport_com { get; set; }
        public string? Relation_com { get; set; }
        public string? Communication_interne_com { get; set; }
        public string? ProcessusR_com { get; set; }
        public string? suggestion { get; set; }
    }
}
