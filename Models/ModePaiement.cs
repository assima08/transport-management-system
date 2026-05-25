using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * \brief implantation de la classe modele ModePaiement
 */

namespace TransportManagementSystem.Models
{
    public class ModePaiement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ModePaiement(string p_Name, string p_Description) {
           
            Name = p_Name;
            Description = p_Description;
        }
        public ModePaiement() { }
    }
}
