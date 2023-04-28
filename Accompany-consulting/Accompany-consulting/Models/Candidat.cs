namespace Accompany_consulting.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Candidat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nom { get; set; }

        [Required]
        [MaxLength(50)]
        public string Prenom { get; set; }

        [MaxLength(15)]
        public string Tel1 { get; set; }

        [MaxLength(15)]
        public string Tel2 { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
     
        public string Email { get; set; }

        [MaxLength(200)]
        public string Competance { get; set; }

        public byte[] CvPdf { get; set; }



    }
}
