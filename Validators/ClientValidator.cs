using System.Text.RegularExpressions;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Validators
{
    public class ClientValidator
    {
        public List<string> Validate(Client client)
        {
            var errors = new List<string>();

            if (client == null)
            {
                errors.Add("Le client est obligatoire.");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(client.Name))
            {
                errors.Add("Le nom du client est obligatoire.");
            }
            else if (client.Name.Trim().Length > 100)
            {
                errors.Add("Le nom du client ne doit pas depasser 100 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(client.FirstName))
            {
                errors.Add("Le prenom du client est obligatoire.");
            }
            else if (client.FirstName.Trim().Length > 100)
            {
                errors.Add("Le prenom du client ne doit pas depasser 100 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(client.Telephone))
            {
                errors.Add("Le telephone du client est obligatoire.");
            }
            else
            {
                string telephone = client.Telephone.Trim();

                if (telephone.Length < 10)
                {
                    errors.Add("Le telephone du client doit contenir au moins 10 caracteres.");
                }

                if (!Regex.IsMatch(telephone, @"^\+?[0-9\s().-]+$"))
                {
                    errors.Add("Le format du telephone du client est invalide.");
                }
            }

            if (string.IsNullOrWhiteSpace(client.Email))
            {
                errors.Add("L'email du client est obligatoire.");
            }
            else if (!Regex.IsMatch(client.Email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errors.Add("Le format de l'email du client est invalide.");
            }

            return errors;
        }
    }
}
