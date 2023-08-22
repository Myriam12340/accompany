using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accompany_consulting.Models
{
    public class Entretient
    {
        public int Id { get; set; }
        public string Avis { get; set; }
        public string Statut { get; set; }
        public Boolean valid { get; set; }


        [ForeignKey("RecruteurId")] // spécifier la clé étrangère correspondante
        public int Recruteur { get; set; }

        [ForeignKey("RecruteurSuivantId")] // spécifier la clé étrangère correspondante
        public int RecruteurSuivant { get; set; }

        public string Post { get; set; }
        public string DescriptionPoste { get; set; }


        [ForeignKey("candidatId")] // spécifier la clé étrangère correspondante

        public int Candidat { get; set; }

        public string traite { get; set; }
    }
}
