using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media.Media3D;

/**
 * \brief implantation de la classe modele Vehicule
 */

namespace TransportManagementSystem.Models
{
    public class Vehicule
    {
        public int Id { get; set; }
        public string plaque { get; set; }
        public string marque { get; set; }
        public string modele { get; set; }
        public int capacite { get; set; }
        public int annee { get; set; }
        public string statut {  get; set; }
        public Vehicule(string p_plaque, string p_marque, string p_modele, int p_capacite, int p_annee,string p_statut ) {
            
            plaque = p_plaque;
            marque = p_marque;
            modele = p_modele;
            capacite = p_capacite;
            annee = p_annee;
            statut = p_statut;
        }
        public Vehicule() { }
    }
}
