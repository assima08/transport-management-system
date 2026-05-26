using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Models;
using TransportManagementSystem.Database;
using TransportManagementSystem.Validators;
using System.IO.Packaging;

namespace TransportManagementSystem.Repositories
{
    public class ModePaiementRepository
    {
        private AppDbContext _appDbContext;
        private readonly ModePaiementValidator _modePaiementValidator;

        public List<string> LastValidationErrors { get; private set; }

        //TODO : CONSTRUCTEUR
        public ModePaiementRepository()
        {
            _appDbContext = new AppDbContext();
            _modePaiementValidator = new ModePaiementValidator();
            LastValidationErrors = new List<string>();
        }

        private void ValiderModePaiement(ModePaiement modePaiement)
        {
            LastValidationErrors = _modePaiementValidator.Validate(modePaiement);

            if (LastValidationErrors.Count > 0)
            {
                throw new InvalidOperationException(string.Join(Environment.NewLine, LastValidationErrors));
            }
        }

        // Ajout par Objet
        public void AjouterModePaiement(ModePaiement modePaiement)
        {
            ValiderModePaiement(modePaiement);
            _appDbContext.ModePaiements.Add(modePaiement);
            _appDbContext.SaveChanges();
        }
        //Ajout par attributs (fera appel a l'ajout par objet).
        public void AjouterEtcreerModePaiement(string p_Name, string p_Description)
        {
            ModePaiement modePaiement = new ModePaiement(p_Name, p_Description);

            AjouterModePaiement(modePaiement);
        }

        //Methodes de recherches par attributs
        public ModePaiement GetById(int p_Id)
        {
            ModePaiement it = _appDbContext.ModePaiements.Find(p_Id);
            return it;
        }

        public ModePaiement GetByName(string p_name)
        {
            ModePaiement it = _appDbContext.ModePaiements.FirstOrDefault(m => m.Name == p_name);
            return it;
        }
        public ModePaiement GetByDescription(string p_description)
        {
            ModePaiement it = _appDbContext.ModePaiements.FirstOrDefault(m => m.Description == p_description);
            return it;
        }

        //suppression de l'objet.
        void SupprimerParObjet(ModePaiement modePaiement)
        {
            if (modePaiement == null) { return; }
            _appDbContext.ModePaiements.Remove(modePaiement);
            _appDbContext.SaveChanges();
        }
        //1- par nom
        public void SupprimerParName(string p_name)
        {
            ModePaiement it = GetByName(p_name);
            SupprimerParObjet(it);
        }
        //2 - par description
        public void SupprimerParDescription(string p_description)
        {
            ModePaiement it = GetByDescription(p_description);
            SupprimerParObjet(it);
        }
        //3- par ID
        public void SupprimerParId(int p_id)
        {
            ModePaiement it = GetById(p_id);
            SupprimerParObjet(it);
        }

        //Methodes d'assignations
        public void UpdateNameParId(int p_id, string p_name)
        {
            ModePaiement it = GetById(p_id);
            if (it == null) { return; }

            string oldName = it.Name;
            it.Name = p_name;

            try
            {
                ValiderModePaiement(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Name = oldName;
                throw;
            }
        }
        public void UpdateDescriptionParId(int p_id, string p_description)
        {
            ModePaiement it = GetById(p_id);
            if (it == null) { return; }

            string oldDescription = it.Description;
            it.Description = p_description;

            try
            {
                ValiderModePaiement(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Description = oldDescription;
                throw;
            }
        }

        //TODO : OBTENIR LA LISTE
        public List<ModePaiement> GetAll()
        {
            return _appDbContext.ModePaiements.ToList();
        }
    }
}
