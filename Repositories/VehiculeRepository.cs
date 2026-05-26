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
    public class VehiculeRepository
    {
        private AppDbContext _appDbContext;
        private readonly VehiculeValidator _vehiculeValidator;

        public List<string> LastValidationErrors { get; private set; }

        //TODO : CONSTRUCTEUR
        public VehiculeRepository()
        {
            _appDbContext = new AppDbContext();
            _vehiculeValidator = new VehiculeValidator();
            LastValidationErrors = new List<string>();
        }

        private void ValiderVehicule(Vehicule vehicule)
        {
            LastValidationErrors = _vehiculeValidator.Validate(vehicule);

            if (LastValidationErrors.Count > 0)
            {
                throw new InvalidOperationException(string.Join(Environment.NewLine, LastValidationErrors));
            }
        }

        // Ajout par Objet
        public void AjouterVehicule(Vehicule vehicule)
        {
            ValiderVehicule(vehicule);
            _appDbContext.Vehicules.Add(vehicule);
            _appDbContext.SaveChanges();
        }
        //Ajout par attributs (fera appel a l'ajout par objet).
        public void AjouterEtcreerVehicule(string p_plaque, string p_marque, string p_modele, int p_capacite, int p_annee, string p_statut)
        {
            Vehicule vehicule = new Vehicule(p_plaque, p_marque, p_modele, p_capacite, p_annee, p_statut);

            AjouterVehicule(vehicule);
        }

        //Methodes de recherches par attributs
        public Vehicule GetById(int p_Id)
        {
            Vehicule it = _appDbContext.Vehicules.Find(p_Id);
            return it;
        }

        public Vehicule GetByPlaque(string p_plaque)
        {
            Vehicule it = _appDbContext.Vehicules.FirstOrDefault(v => v.plaque == p_plaque);
            return it;
        }
        public Vehicule GetByMarque(string p_marque)
        {
            Vehicule it = _appDbContext.Vehicules.FirstOrDefault(v => v.marque == p_marque);
            return it;
        }
        public Vehicule GetByModele(string p_modele)
        {
            Vehicule it = _appDbContext.Vehicules.FirstOrDefault(v => v.modele == p_modele);
            return it;
        }
        public Vehicule GetByStatut(string p_statut)
        {
            Vehicule it = _appDbContext.Vehicules.FirstOrDefault(v => v.statut == p_statut);
            return it;
        }

        //suppression de l'objet.
        void SupprimerParObjet(Vehicule vehicule)
        {
            if (vehicule == null) { return; }
            _appDbContext.Vehicules.Remove(vehicule);
            _appDbContext.SaveChanges();
        }
        //1- par plaque
        public void SupprimerParPlaque(string p_plaque)
        {
            Vehicule it = GetByPlaque(p_plaque);
            SupprimerParObjet(it);
        }
        //2 - par ID
        public void SupprimerParId(int p_id)
        {
            Vehicule it = GetById(p_id);
            SupprimerParObjet(it);
        }
        //3- par statut
        public void SupprimerParStatut(string p_statut)
        {
            Vehicule it = GetByStatut(p_statut);
            SupprimerParObjet(it);
        }

        //Methodes d'assignations
        public void UpdatePlaque(string p_plaque, string p_NewPlaque)
        {
            Vehicule it = GetByPlaque(p_plaque);
            if (it == null) { return; }

            string oldPlaque = it.plaque;
            it.plaque = p_NewPlaque;

            try
            {
                ValiderVehicule(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.plaque = oldPlaque;
                throw;
            }
        }
        public void UpdateMarqueParId(int p_id, string p_marque)
        {
            Vehicule it = GetById(p_id);
            if (it == null) { return; }

            string oldMarque = it.marque;
            it.marque = p_marque;

            try
            {
                ValiderVehicule(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.marque = oldMarque;
                throw;
            }
        }
        public void UpdateModeleParId(int p_id, string p_modele)
        {
            Vehicule it = GetById(p_id);
            if (it == null) { return; }

            string oldModele = it.modele;
            it.modele = p_modele;

            try
            {
                ValiderVehicule(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.modele = oldModele;
                throw;
            }
        }
        public void UpdateCapaciteParId(int p_id, int p_capacite)
        {
            Vehicule it = GetById(p_id);
            if (it == null) { return; }

            int oldCapacite = it.capacite;
            it.capacite = p_capacite;

            try
            {
                ValiderVehicule(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.capacite = oldCapacite;
                throw;
            }
        }
        public void UpdateAnneeParId(int p_id, int p_annee)
        {
            Vehicule it = GetById(p_id);
            if (it == null) { return; }

            int oldAnnee = it.annee;
            it.annee = p_annee;

            try
            {
                ValiderVehicule(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.annee = oldAnnee;
                throw;
            }
        }
        public void UpdateStatutParId(int p_id, string p_statut)
        {
            Vehicule it = GetById(p_id);
            if (it == null) { return; }

            string oldStatut = it.statut;
            it.statut = p_statut;

            try
            {
                ValiderVehicule(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.statut = oldStatut;
                throw;
            }
        }

        //TODO : OBTENIR LA LISTE
        public List<Vehicule> GetAll()
        {
            return _appDbContext.Vehicules.ToList();
        }
    }
}
