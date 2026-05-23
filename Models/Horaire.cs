using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Models;

/**
 * \brief implantation de la classe modele Horaire
 */

namespace TransportManagementSystem.Models
{
    public class Horaire
    {
        public int Id { get; set; }
        public Vehicule Vehicule { get; set; }
        public Chauffeur Chauffeur { get; set; }
        public Trajet Trajet { get; set; }
        public DateOnly DateDepart {  get; set; }
        public DateOnly DateArrivee { get; set; }

        public Horaire(int p_Id, Vehicule p_Vehicule, Chauffeur p_Chauffeur, Trajet p_Trajet, DateOnly p_DateDepart, DateOnly p_DateArrivee) {
            Id = p_Id;
            Vehicule = p_Vehicule;
            Chauffeur = p_Chauffeur;
            Trajet = p_Trajet;
            DateDepart = p_DateDepart;
            DateArrivee = p_DateArrivee;
        }

    }
}
