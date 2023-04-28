using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accompany_consulting.Models
{
 public class User : IdentityUser<int>
    {
       
        public  string Role { get; set; }
        [NotMapped]
        public override string PhoneNumber { get; set; }
        [NotMapped]

        public override Boolean PhoneNumberConfirmed { get; set; }


        [NotMapped]
        public override string NormalizedUserName { get; set; }
        [NotMapped]
        public string NormalizedEmail { get; set; }
    }

}
