﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Accompany_consulting.Models
{
    public class Mission
    {
        public int Id { get; set; }
       
        [ForeignKey("ConsultantId")]
        public int Consultant { get; set; }
        [ForeignKey("ManagerId")]
        public int Manager { get; set; }
        public string titre { get; set; }
  
    }

}
