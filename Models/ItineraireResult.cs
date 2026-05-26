using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Models
{
    public class ItineraireResult
    {
        public List<Gare> Etapes { get; set; }

        public double DistanceTotale { get; set; }

        public double DureeTotale { get; set; }

        public double PrixTotal { get; set; }

        public ItineraireResult()
        {
            Etapes = new List<Gare>();
        }

        public ItineraireResult(List<Gare> p_Etapes, double p_DistanceTotale, double p_DureeTotale, double p_PrixTotal)
        {
            Etapes = p_Etapes ?? new List<Gare>();
            DistanceTotale = p_DistanceTotale;
            DureeTotale = p_DureeTotale;
            PrixTotal = p_PrixTotal;
        }
    }
}
