using TransportManagementSystem.Models;

namespace TransportManagementSystem.Validators
{
    public class LiaisonValidator
    {
        public List<string> Validate(Liaison liaison)
        {
            var errors = new List<string>();

            if (liaison == null)
            {
                errors.Add("La liaison est obligatoire.");
                return errors;
            }

            if (liaison.Depart == null)
            {
                errors.Add("La gare de depart est obligatoire.");
            }

            if (liaison.Arrivee == null)
            {
                errors.Add("La gare d'arrivee est obligatoire.");
            }

            if (liaison.Depart != null && liaison.Arrivee != null && liaison.Depart == liaison.Arrivee)
            {
                errors.Add("La gare de depart doit etre differente de la gare d'arrivee.");
            }

            if (liaison.DistanceKm <= 0)
            {
                errors.Add("La distance de la liaison doit etre positive.");
            }

            if (liaison.DureeMinutes <= 0)
            {
                errors.Add("La duree de la liaison doit etre positive.");
            }

            if (liaison.Prix < 0)
            {
                errors.Add("Le prix de la liaison ne peut pas etre negatif.");
            }

            return errors;
        }
    }
}
