using TransportManagementSystem.Models;

namespace TransportManagementSystem.Validators
{
    public class ModePaiementValidator
    {
        public List<string> Validate(ModePaiement modePaiement)
        {
            var errors = new List<string>();

            if (modePaiement == null)
            {
                errors.Add("Le mode de paiement est obligatoire.");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(modePaiement.Name))
            {
                errors.Add("Le nom du mode de paiement est obligatoire.");
            }
            else if (modePaiement.Name.Trim().Length > 100)
            {
                errors.Add("Le nom du mode de paiement ne doit pas depasser 100 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(modePaiement.Description))
            {
                errors.Add("La description du mode de paiement est obligatoire.");
            }
            else if (modePaiement.Description.Trim().Length > 250)
            {
                errors.Add("La description du mode de paiement ne doit pas depasser 250 caracteres.");
            }

            return errors;
        }
    }
}
