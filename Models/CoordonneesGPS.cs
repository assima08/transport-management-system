using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Models
{
    public class CoordonneesGPS
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public CoordonneesGPS() { }

        public CoordonneesGPS(double p_latitude, double p_longitude)
        {
            Latitude = p_latitude;
            Longitude = p_longitude;
        }
    }
}
