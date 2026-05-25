using TransportManagementSystem.Models;

namespace TransportManagementSystem.Validators
{
    public class TrajetValidator
    {
        public List<string> Validate(Trajet trajet)
        {
            var errors = new List<string>();

            if (trajet == null)
            {
                errors.Add("Le trajet est obligatoire.");
                return errors;
            }

            if (trajet.VilleDepartId <= 0)
            {
                errors.Add("La ville de depart est obligatoire.");
            }

            if (trajet.VilleArriveeId <= 0)
            {
                errors.Add("La ville d'arrivee est obligatoire.");
            }

            if (trajet.VilleDepartId > 0 && trajet.VilleDepartId == trajet.VilleArriveeId)
            {
                errors.Add("La ville de depart doit etre differente de la ville d'arrivee.");
            }

            if (trajet.Prix <= 0)
            {
                errors.Add("Le prix du trajet doit etre positif.");
            }

            if (trajet.HeureDepart == trajet.HeureArrivee)
            {
                errors.Add("L'heure de depart doit etre differente de l'heure d'arrivee.");
            }

            return errors;
        }
    }
}
