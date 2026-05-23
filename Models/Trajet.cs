using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Models;

/**
 * \brief implantation de la classe modele Trajet
 */

namespace TransportManagementSystem.Models
{
    public class Trajet
    {
        public int Id { get; set; }
        public int VilleDepartId { get; set; }
        public int VilleArriveeId { get; set; }
        public TimeOnly HeureDepart { get; set; }
        public TimeOnly HeureArrivee { get; set; }
        public decimal Prix { get; set; }

        public Trajet(int p_Id, int p_VilleDepart, int p_VilleArrivee, TimeOnly p_HeureDepart, TimeOnly p_HeureArrivee, decimal p_Prix)
        {
            Id = p_Id;
            VilleDepartId = p_VilleDepart;
            VilleArriveeId = p_VilleArrivee;
            HeureDepart = p_HeureDepart;
            HeureArrivee = p_HeureArrivee;
            Prix = p_Prix;
        }

    }
}
