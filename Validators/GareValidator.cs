using TransportManagementSystem.Models;

namespace TransportManagementSystem.Validators
{
    public class GareValidator
    {
        public List<string> Validate(Gare gare)
        {
            var errors = new List<string>();

            if (gare == null)
            {
                errors.Add("La gare est obligatoire.");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(gare.Nom))
            {
                errors.Add("Le nom de la gare est obligatoire.");
            }
            else if (gare.Nom.Trim().Length > 100)
            {
                errors.Add("Le nom de la gare ne doit pas depasser 100 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(gare.Adresse))
            {
                errors.Add("L'adresse de la gare est obligatoire.");
            }
            else if (gare.Adresse.Trim().Length > 250)
            {
                errors.Add("L'adresse de la gare ne doit pas depasser 250 caracteres.");
            }

            if (gare.Latitude < -90 || gare.Latitude > 90)
            {
                errors.Add("La latitude de la gare doit etre comprise entre -90 et 90.");
            }

            if (gare.Longitude < -180 || gare.Longitude > 180)
            {
                errors.Add("La longitude de la gare doit etre comprise entre -180 et 180.");
            }

            if (gare.ville == null)
            {
                errors.Add("La ville de la gare est obligatoire.");
            }

            return errors;
        }
    }
}
