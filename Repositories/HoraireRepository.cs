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
    public class HoraireRepository
    {
        private AppDbContext _appDbContext;
        private readonly HoraireValidator _horaireValidator;

        public List<string> LastValidationErrors { get; private set; }

        //TODO : CONSTRUCTEUR
        public HoraireRepository()
        {
            _appDbContext = new AppDbContext();
            _horaireValidator = new HoraireValidator();
            LastValidationErrors = new List<string>();
        }

        private void ValiderHoraire(Horaire horaire)
        {
            LastValidationErrors = _horaireValidator.Validate(horaire);

            if (LastValidationErrors.Count > 0)
            {
                throw new InvalidOperationException(string.Join(Environment.NewLine, LastValidationErrors));
            }
        }

        // Ajout par Objet
        public void AjouterHoraire(Horaire horaire)
        {
            ValiderHoraire(horaire);
            _appDbContext.Horaires.Add(horaire);
            _appDbContext.SaveChanges();
        }
        //Ajout par attributs (fera appel a l'ajout par objet).
        public void AjouterEtcreerHoraire(Vehicule p_Vehicule, Chauffeur p_Chauffeur, Trajet p_Trajet, DateOnly p_DateDepart, DateOnly p_DateArrivee)
        {
            Horaire horaire = new Horaire(p_Vehicule, p_Chauffeur, p_Trajet, p_DateDepart, p_DateArrivee);

            AjouterHoraire(horaire);
        }

        //Methodes de recherches par attributs
        public Horaire GetById(int p_Id)
        {
            Horaire it = _appDbContext.Horaires.Find(p_Id);
            return it;
        }

        public Horaire GetByVehicule(Vehicule p_vehicule)
        {
            Horaire it = _appDbContext.Horaires.FirstOrDefault(h => h.Vehicule == p_vehicule);
            return it;
        }
        public Horaire GetByChauffeur(Chauffeur p_chauffeur)
        {
            Horaire it = _appDbContext.Horaires.FirstOrDefault(h => h.Chauffeur == p_chauffeur);
            return it;
        }
        public Horaire GetByTrajet(Trajet p_trajet)
        {
            Horaire it = _appDbContext.Horaires.FirstOrDefault(h => h.Trajet == p_trajet);
            return it;
        }
        public Horaire GetByDateDepart(DateOnly p_DateDepart)
        {
            Horaire it = _appDbContext.Horaires.FirstOrDefault(h => h.DateDepart == p_DateDepart);
            return it;
        }
        public Horaire GetByDateArrivee(DateOnly p_DateArrivee)
        {
            Horaire it = _appDbContext.Horaires.FirstOrDefault(h => h.DateArrivee == p_DateArrivee);
            return it;
        }

        //suppression de l'objet.
        void SupprimerParObjet(Horaire horaire)
        {
            if (horaire == null) { return; }
            _appDbContext.Horaires.Remove(horaire);
            _appDbContext.SaveChanges();
        }
        //1- par vehicule
        public void SupprimerParVehicule(Vehicule p_vehicule)
        {
            Horaire it = GetByVehicule(p_vehicule);
            SupprimerParObjet(it);
        }
        //2 - par chauffeur
        public void SupprimerParChauffeur(Chauffeur p_chauffeur)
        {
            Horaire it = GetByChauffeur(p_chauffeur);
            SupprimerParObjet(it);
        }
        //3- par ID
        public void SupprimerParId(int p_id)
        {
            Horaire it = GetById(p_id);
            SupprimerParObjet(it);
        }
        //4- par trajet
        public void SupprimerParTrajet(Trajet p_trajet)
        {
            Horaire it = GetByTrajet(p_trajet);
            SupprimerParObjet(it);
        }

        //Methodes d'assignations
        public void UpdateVehiculeParId(int p_id, Vehicule p_vehicule)
        {
            Horaire it = GetById(p_id);
            if (it == null) { return; }

            Vehicule oldVehicule = it.Vehicule;
            it.Vehicule = p_vehicule;

            try
            {
                ValiderHoraire(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Vehicule = oldVehicule;
                throw;
            }
        }
        public void UpdateChauffeurParId(int p_id, Chauffeur p_chauffeur)
        {
            Horaire it = GetById(p_id);
            if (it == null) { return; }

            Chauffeur oldChauffeur = it.Chauffeur;
            it.Chauffeur = p_chauffeur;

            try
            {
                ValiderHoraire(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Chauffeur = oldChauffeur;
                throw;
            }
        }
        public void UpdateTrajetParId(int p_id, Trajet p_trajet)
        {
            Horaire it = GetById(p_id);
            if (it == null) { return; }

            Trajet oldTrajet = it.Trajet;
            it.Trajet = p_trajet;

            try
            {
                ValiderHoraire(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Trajet = oldTrajet;
                throw;
            }
        }
        public void UpdateDateDepartParId(int p_id, DateOnly p_DateDepart)
        {
            Horaire it = GetById(p_id);
            if (it == null) { return; }

            DateOnly oldDateDepart = it.DateDepart;
            it.DateDepart = p_DateDepart;

            try
            {
                ValiderHoraire(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.DateDepart = oldDateDepart;
                throw;
            }
        }
        public void UpdateDateArriveeParId(int p_id, DateOnly p_DateArrivee)
        {
            Horaire it = GetById(p_id);
            if (it == null) { return; }

            DateOnly oldDateArrivee = it.DateArrivee;
            it.DateArrivee = p_DateArrivee;

            try
            {
                ValiderHoraire(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.DateArrivee = oldDateArrivee;
                throw;
            }
        }

        //TODO : OBTENIR LA LISTE
        public List<Horaire> GetAll()
        {
            return _appDbContext.Horaires.ToList();
        }
    }
}
