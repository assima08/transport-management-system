using TransportManagementSystem.Models;

namespace TransportManagementSystem.Validators
{
    public class HoraireValidator
    {
        public List<string> Validate(Horaire horaire)
        {
            var errors = new List<string>();

            if (horaire == null)
            {
                errors.Add("L'horaire est obligatoire.");
                return errors;
            }

            if (horaire.Vehicule == null)
            {
                errors.Add("Le vehicule de l'horaire est obligatoire.");
            }

            if (horaire.Chauffeur == null)
            {
                errors.Add("Le chauffeur de l'horaire est obligatoire.");
            }

            if (horaire.Trajet == null)
            {
                errors.Add("Le trajet de l'horaire est obligatoire.");
            }

            if (horaire.DateDepart == default)
            {
                errors.Add("La date de depart est obligatoire.");
            }

            if (horaire.DateArrivee == default)
            {
                errors.Add("La date d'arrivee est obligatoire.");
            }

            if (horaire.DateDepart != default && horaire.DateArrivee != default && horaire.DateArrivee < horaire.DateDepart)
            {
                errors.Add("La date d'arrivee doit etre egale ou posterieure a la date de depart.");
            }

            return errors;
        }
    }
}
