using TransportManagementSystem.Models;

namespace TransportManagementSystem.Validators
{
    public class PaiementValidator
    {
        public List<string> Validate(Paiement paiement)
        {
            var errors = new List<string>();

            if (paiement == null)
            {
                errors.Add("Le paiement est obligatoire.");
                return errors;
            }

            if (paiement.Reservation == null)
            {
                errors.Add("La reservation du paiement est obligatoire.");
            }

            if (paiement.ModePaiement == null)
            {
                errors.Add("Le mode de paiement est obligatoire.");
            }

            if (paiement.Montant <= 0)
            {
                errors.Add("Le montant du paiement doit etre positif.");
            }

            if (paiement.DatePaiement == default)
            {
                errors.Add("La date de paiement est obligatoire.");
            }
            else if (paiement.DatePaiement > DateOnly.FromDateTime(DateTime.Today))
            {
                errors.Add("La date de paiement ne peut pas etre future.");
            }

            if (string.IsNullOrWhiteSpace(paiement.Statut))
            {
                errors.Add("Le statut du paiement est obligatoire.");
            }
            else if (paiement.Statut.Trim().Length > 50)
            {
                errors.Add("Le statut du paiement ne doit pas depasser 50 caracteres.");
            }

            return errors;
        }
    }
}
