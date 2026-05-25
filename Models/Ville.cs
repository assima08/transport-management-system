using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * \brief implantation de la classe modele Ville
 */

namespace TransportManagementSystem.Models
{
    public class Ville
    {
        public int Id { get; set; }
        public string NomVille { get; set; }
        public string Province { get; set; }
        public string Pays { get; set; }

        public Ville(int p_Id, string P_NomVille, string p_Province, string p_Pays) { 
            
            NomVille = P_NomVille;
            Province = p_Province;
            Pays = p_Pays;

        }
        public Ville() { }
    }
}
