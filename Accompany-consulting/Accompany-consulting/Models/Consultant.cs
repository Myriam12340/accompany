using System;
using System.ComponentModel.DataAnnotations;
namespace Accompany_consulting.Models

{
    public class Consultant
    {

        public int Id { get; set; }


        public string Nom { get; set; }


        public string Prenom { get; set; }

        public string adress { get; set; }

        public string Grade { get; set; }

        public string Status { get; set; }
       


        public string Fonction { get; set; }

        public string Contrat { get; set; }

        public string Societe { get; set; }


        public string Business_unit { get; set; }


        [DataType(DataType.Date)]
        public DateTime Date_integration{ get; set; }


        [DataType(DataType.Date)]

        public DateTime Date_naissance { get; set; }

        public int Age { get; set; }
        
        public string Cin { get; set; }


        public string Tel1 { get; set; }

        public string Tel2 { get; set; }

        public string Mail { get; set; }
        public string genre { get; set; }   
        public string code { get; set; }
        public string situation_amoureuse { get; set; }
        public int salaire { get; set; }
        public int SoldeConge { get; set; }
        public int SoldeMaladie { get; set; }
    }
}
