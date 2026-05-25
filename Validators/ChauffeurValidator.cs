using System.Text.RegularExpressions;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Validators
{
    public class ChauffeurValidator
    {
        private const int TelephoneMinLength = 10;
        private const int TextMaxLength = 100;

        public List<string> Validate(Chauffeur chauffeur)
        {
            var errors = new List<string>();

            if (chauffeur == null)
            {
                errors.Add("Le chauffeur est obligatoire.");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(chauffeur.Nom))
            {
                errors.Add("Le nom est obligatoire.");
            }
            else if (chauffeur.Nom.Trim().Length > TextMaxLength)
            {
                errors.Add($"Le nom ne doit pas depasser {TextMaxLength} caracteres.");
            }

            if (string.IsNullOrWhiteSpace(chauffeur.Prenom))
            {
                errors.Add("Le prenom est obligatoire.");
            }
            else if (chauffeur.Prenom.Trim().Length > TextMaxLength)
            {
                errors.Add($"Le prenom ne doit pas depasser {TextMaxLength} caracteres.");
            }

            if (string.IsNullOrWhiteSpace(chauffeur.Telephone))
            {
                errors.Add("Le telephone est obligatoire.");
            }
            else
            {
                string telephone = chauffeur.Telephone.Trim();

                if (telephone.Length < TelephoneMinLength)
                {
                    errors.Add($"Le telephone doit contenir au moins {TelephoneMinLength} caracteres.");
                }

                if (!Regex.IsMatch(telephone, @"^\+?[0-9\s().-]+$"))
                {
                    errors.Add("Le format du telephone est invalide.");
                }
            }

            if (string.IsNullOrWhiteSpace(chauffeur.NumeroPermis))
            {
                errors.Add("Le numero de permis est obligatoire.");
            }
            else if (chauffeur.NumeroPermis.Trim().Length > 50)
            {
                errors.Add("Le numero de permis ne doit pas depasser 50 caracteres.");
            }

            if (chauffeur.DateExpirationPermis <= DateOnly.FromDateTime(DateTime.Today))
            {
                errors.Add("La date d'expiration du permis doit etre future.");
            }

            return errors;
        }
    }
}
