using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accompany_consulting.Models
{
    public class eval_competance
    {
        public int Id { get; set; }

        [ForeignKey("hr_id")]
        public int Hr { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_evaluation { get; set; }
        public int notefinal { get; set; }

        public int notemissions { get; set; }    
        
        public string decision { get; set; }
        public string contrat { get; set; }

        [ForeignKey("consultant_id")]
        public int consultant { get; set; }

    }
}
