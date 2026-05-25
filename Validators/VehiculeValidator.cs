using TransportManagementSystem.Models;

namespace TransportManagementSystem.Validators
{
    public class VehiculeValidator
    {
        public List<string> Validate(Vehicule vehicule)
        {
            var errors = new List<string>();

            if (vehicule == null)
            {
                errors.Add("Le vehicule est obligatoire.");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(vehicule.plaque))
            {
                errors.Add("La plaque du vehicule est obligatoire.");
            }
            else if (vehicule.plaque.Trim().Length < 2 || vehicule.plaque.Trim().Length > 20)
            {
                errors.Add("La plaque du vehicule doit contenir entre 2 et 20 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(vehicule.marque))
            {
                errors.Add("La marque du vehicule est obligatoire.");
            }
            else if (vehicule.marque.Trim().Length > 50)
            {
                errors.Add("La marque du vehicule ne doit pas depasser 50 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(vehicule.modele))
            {
                errors.Add("Le modele du vehicule est obligatoire.");
            }
            else if (vehicule.modele.Trim().Length > 50)
            {
                errors.Add("Le modele du vehicule ne doit pas depasser 50 caracteres.");
            }

            if (vehicule.capacite <= 0)
            {
                errors.Add("La capacite du vehicule doit etre positive.");
            }

            int currentYear = DateTime.Today.Year + 1;
            if (vehicule.annee < 1900 || vehicule.annee > currentYear)
            {
                errors.Add($"L'annee du vehicule doit etre comprise entre 1900 et {currentYear}.");
            }

            if (string.IsNullOrWhiteSpace(vehicule.statut))
            {
                errors.Add("Le statut du vehicule est obligatoire.");
            }
            else if (vehicule.statut.Trim().Length > 50)
            {
                errors.Add("Le statut du vehicule ne doit pas depasser 50 caracteres.");
            }

            return errors;
        }
    }
}
