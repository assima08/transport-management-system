using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace TransportManagementSystem.Models
{
    public class Chauffeur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string NumeroPermis { get; set; }
        public DateOnly DateExpirationPermis { get; set; }

        public Chauffeur(int p_Id, string p_nom, string p_Prenom, string p_Telephone, string p_NumeroPermis, DateOnly p_DateExpirationPermis ) {
            int id = p_Id;
            Nom = p_nom;
            Prenom = p_Prenom;
            Telephone = p_Telephone;
            NumeroPermis = p_NumeroPermis;
            DateExpirationPermis = p_DateExpirationPermis;
        }
    }
}
