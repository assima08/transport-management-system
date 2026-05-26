using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Models
{
    public class Liaison
    {
        public int Id { get; set; }

        public Gare Depart { get; set; }

        public Gare Arrivee { get; set; }

        public double DistanceKm { get; set; }

        public double DureeMinutes { get; set; }

        public double Prix { get; set; }

        public Liaison() { }

        public Liaison(Gare p_Depart, Gare p_Arrivee, double p_DistanceKm, double p_DureeMinutes, double p_Prix)
        {
            Depart = p_Depart;
            Arrivee = p_Arrivee;
            DistanceKm = p_DistanceKm;
            DureeMinutes = p_DureeMinutes;
            Prix = p_Prix;
        }
    }
}
