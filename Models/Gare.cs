using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Models
{
    public class Gare
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Ville ville { get; set; }

        public Gare() { }

        public Gare(string p_nom, string p_adresse, double p_latitude, double p_longitude, Ville p_ville)
        {
            Nom = p_nom;
            Adresse = p_adresse;
            Latitude = p_latitude;
            Longitude = p_longitude;
            ville = p_ville;
        }
    }
}
