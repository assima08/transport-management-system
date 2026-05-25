using TransportManagementSystem.Models;

namespace TransportManagementSystem.Validators
{
    public class VilleValidator
    {
        public List<string> Validate(Ville ville)
        {
            var errors = new List<string>();

            if (ville == null)
            {
                errors.Add("La ville est obligatoire.");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(ville.NomVille))
            {
                errors.Add("Le nom de la ville est obligatoire.");
            }
            else if (ville.NomVille.Trim().Length > 100)
            {
                errors.Add("Le nom de la ville ne doit pas depasser 100 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(ville.Province))
            {
                errors.Add("La province est obligatoire.");
            }
            else if (ville.Province.Trim().Length > 100)
            {
                errors.Add("La province ne doit pas depasser 100 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(ville.Pays))
            {
                errors.Add("Le pays est obligatoire.");
            }
            else if (ville.Pays.Trim().Length > 100)
            {
                errors.Add("Le pays ne doit pas depasser 100 caracteres.");
            }

            return errors;
        }
    }
}
