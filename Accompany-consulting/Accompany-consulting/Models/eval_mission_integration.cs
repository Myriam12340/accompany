using System.ComponentModel.DataAnnotations.Schema;

namespace Accompany_consulting.Models
{
    public class eval_mission_integration
    {

        public int Id { get; set; }

        [ForeignKey("ConsultantId")]
        public int Consultant { get; set; }
        [ForeignKey("ManagerId")]
        public int Manager { get; set; }

        [ForeignKey("MissionId")]
        public int Mission { get; set; }

        public string RoleRH { get; set; }
        public string RoleC { get; set; }
        public string RelationClientRH { get; set; }
        public string RelationClientC { get; set; }
        public string ChargeRH { get; set; }
        public string ChargeC { get; set; }
        public string SatisficationRH { get; set; }
        public string SatisficationC { get; set; }
        public int? NoteManager { get; set; }
        public string? FeedbackManager { get; set; }


        [ForeignKey("Evaluationid")]
        public int evaluation { get; set; }


    }
}
