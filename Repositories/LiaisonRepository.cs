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
    public class LiaisonRepository
    {
        private AppDbContext _appDbContext;
        private readonly LiaisonValidator _liaisonValidator;

        public List<string> LastValidationErrors { get; private set; }

        //TODO : CONSTRUCTEUR
        public LiaisonRepository()
        {
            _appDbContext = new AppDbContext();
            _liaisonValidator = new LiaisonValidator();
            LastValidationErrors = new List<string>();
        }

        private void ValiderLiaison(Liaison liaison)
        {
            LastValidationErrors = _liaisonValidator.Validate(liaison);

            if (LastValidationErrors.Count > 0)
            {
                throw new InvalidOperationException(string.Join(Environment.NewLine, LastValidationErrors));
            }
        }

        // Ajout par Objet
        public void AjouterLiaison(Liaison liaison)
        {
            ValiderLiaison(liaison);
            _appDbContext.Set<Liaison>().Add(liaison);
            _appDbContext.SaveChanges();
        }
        //Ajout par attributs (fera appel a l'ajout par objet).
        public void AjouterEtcreerLiaison(Gare p_Depart, Gare p_Arrivee, double p_DistanceKm, double p_DureeMinutes, double p_Prix)
        {
            Liaison liaison = new Liaison
            {
                Depart = p_Depart,
                Arrivee = p_Arrivee,
                DistanceKm = p_DistanceKm,
                DureeMinutes = p_DureeMinutes,
                Prix = p_Prix
            };

            AjouterLiaison(liaison);
        }

        //Methodes de recherches par attributs
        public Liaison GetById(int p_Id)
        {
            Liaison it = _appDbContext.Set<Liaison>().Find(p_Id);
            return it;
        }

        public Liaison GetByDepart(Gare p_depart)
        {
            Liaison it = _appDbContext.Set<Liaison>().FirstOrDefault(l => l.Depart == p_depart);
            return it;
        }
        public Liaison GetByArrivee(Gare p_arrivee)
        {
            Liaison it = _appDbContext.Set<Liaison>().FirstOrDefault(l => l.Arrivee == p_arrivee);
            return it;
        }
        public Liaison GetByGares(Gare p_depart, Gare p_arrivee)
        {
            Liaison it = _appDbContext.Set<Liaison>().FirstOrDefault(l => l.Depart == p_depart && l.Arrivee == p_arrivee);
            return it;
        }
        public Liaison GetByDistanceKm(double p_DistanceKm)
        {
            Liaison it = _appDbContext.Set<Liaison>().FirstOrDefault(l => l.DistanceKm == p_DistanceKm);
            return it;
        }
        public Liaison GetByDureeMinutes(double p_DureeMinutes)
        {
            Liaison it = _appDbContext.Set<Liaison>().FirstOrDefault(l => l.DureeMinutes == p_DureeMinutes);
            return it;
        }
        public Liaison GetByPrix(double p_Prix)
        {
            Liaison it = _appDbContext.Set<Liaison>().FirstOrDefault(l => l.Prix == p_Prix);
            return it;
        }

        //suppression de l'objet.
        void SupprimerParObjet(Liaison liaison)
        {
            if (liaison == null) { return; }
            _appDbContext.Set<Liaison>().Remove(liaison);
            _appDbContext.SaveChanges();
        }
        //1- par depart
        public void SupprimerParDepart(Gare p_depart)
        {
            Liaison it = GetByDepart(p_depart);
            SupprimerParObjet(it);
        }
        //2 - par arrivee
        public void SupprimerParArrivee(Gare p_arrivee)
        {
            Liaison it = GetByArrivee(p_arrivee);
            SupprimerParObjet(it);
        }
        //3- par ID
        public void SupprimerParId(int p_id)
        {
            Liaison it = GetById(p_id);
            SupprimerParObjet(it);
        }
        //4- par gares
        public void SupprimerParGares(Gare p_depart, Gare p_arrivee)
        {
            Liaison it = GetByGares(p_depart, p_arrivee);
            SupprimerParObjet(it);
        }

        //Methodes d'assignations
        public void UpdateDepartParId(int p_id, Gare p_depart)
        {
            Liaison it = GetById(p_id);
            if (it == null) { return; }

            Gare oldDepart = it.Depart;
            it.Depart = p_depart;

            try
            {
                ValiderLiaison(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Depart = oldDepart;
                throw;
            }
        }
        public void UpdateArriveeParId(int p_id, Gare p_arrivee)
        {
            Liaison it = GetById(p_id);
            if (it == null) { return; }

            Gare oldArrivee = it.Arrivee;
            it.Arrivee = p_arrivee;

            try
            {
                ValiderLiaison(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Arrivee = oldArrivee;
                throw;
            }
        }
        public void UpdateDistanceKmParId(int p_id, double p_DistanceKm)
        {
            Liaison it = GetById(p_id);
            if (it == null) { return; }

            double oldDistanceKm = it.DistanceKm;
            it.DistanceKm = p_DistanceKm;

            try
            {
                ValiderLiaison(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.DistanceKm = oldDistanceKm;
                throw;
            }
        }
        public void UpdateDureeMinutesParId(int p_id, double p_DureeMinutes)
        {
            Liaison it = GetById(p_id);
            if (it == null) { return; }

            double oldDureeMinutes = it.DureeMinutes;
            it.DureeMinutes = p_DureeMinutes;

            try
            {
                ValiderLiaison(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.DureeMinutes = oldDureeMinutes;
                throw;
            }
        }
        public void UpdatePrixParId(int p_id, double p_Prix)
        {
            Liaison it = GetById(p_id);
            if (it == null) { return; }

            double oldPrix = it.Prix;
            it.Prix = p_Prix;

            try
            {
                ValiderLiaison(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Prix = oldPrix;
                throw;
            }
        }

        //TODO : OBTENIR LA LISTE
        public List<Liaison> GetAll()
        {
            return _appDbContext.Set<Liaison>().ToList();
        }
    }
}
