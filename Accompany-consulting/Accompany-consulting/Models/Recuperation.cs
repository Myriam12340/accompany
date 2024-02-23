using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Accompany_consulting.Models
{
    public class Recuperation
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


        public string commentaire { get; set; } 

        public int numeroDemande { get; set; }


        public string manager { get; set; }


    }
}
