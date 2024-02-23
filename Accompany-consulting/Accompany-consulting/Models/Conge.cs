using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accompany_consulting.Models
{
    public class Conge
    {
        public int Id { get; set; }
        [ForeignKey("demandeur_id")]
        public int Demandeur { get; set; }
        [ForeignKey("validateur_id")]
        public int Validateur { get; set; }
      
        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateFin { get; set; }
        public string Type { get; set; }
        [DataType(DataType.Date)]

        public DateTime DateDemande { get; set; }

        public string etat { get; set; } 

        public double duree { get; set; }


        public string certif { get; set; } // Champ pour stocker l'URL du fichier PDF

        public Boolean imprime { get; set; }
    }

}
