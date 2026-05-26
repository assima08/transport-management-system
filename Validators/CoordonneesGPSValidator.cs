using TransportManagementSystem.Models;

namespace TransportManagementSystem.Validators
{
    public class CoordonneesGPSValidator
    {
        public List<string> Validate(CoordonneesGPS coordonneesGPS)
        {
            var errors = new List<string>();

            if (coordonneesGPS == null)
            {
                errors.Add("Les coordonnees GPS sont obligatoires.");
                return errors;
            }

            if (coordonneesGPS.Latitude < -90 || coordonneesGPS.Latitude > 90)
            {
                errors.Add("La latitude doit etre comprise entre -90 et 90.");
            }

            if (coordonneesGPS.Longitude < -180 || coordonneesGPS.Longitude > 180)
            {
                errors.Add("La longitude doit etre comprise entre -180 et 180.");
            }

            return errors;
        }
    }
}
