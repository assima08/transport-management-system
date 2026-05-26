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
    public class PaiementRepository
    {
        private AppDbContext _appDbContext;
        private readonly PaiementValidator _paiementValidator;

        public List<string> LastValidationErrors { get; private set; }

        //TODO : CONSTRUCTEUR
        public PaiementRepository()
        {
            _appDbContext = new AppDbContext();
            _paiementValidator = new PaiementValidator();
            LastValidationErrors = new List<string>();
        }

        private void ValiderPaiement(Paiement paiement)
        {
            LastValidationErrors = _paiementValidator.Validate(paiement);

            if (LastValidationErrors.Count > 0)
            {
                throw new InvalidOperationException(string.Join(Environment.NewLine, LastValidationErrors));
            }
        }

        // Ajout par Objet
        public void AjouterPaiement(Paiement paiement)
        {
            ValiderPaiement(paiement);
            _appDbContext.Paiements.Add(paiement);
            _appDbContext.SaveChanges();
        }
        //Ajout par attributs (fera appel a l'ajout par objet).
        public void AjouterEtcreerPaiement(Reservation p_Reservation, ModePaiement p_ModePaiement, decimal p_Montant, DateOnly p_DatePaiement, string p_Statut)
        {
            Paiement paiement = new Paiement(p_Reservation, p_ModePaiement, p_Montant, p_DatePaiement, p_Statut);

            AjouterPaiement(paiement);
        }

        //Methodes de recherches par attributs
        public Paiement GetById(int p_Id)
        {
            Paiement it = _appDbContext.Paiements.Find(p_Id);
            return it;
        }

        public Paiement GetByReservation(Reservation p_reservation)
        {
            Paiement it = _appDbContext.Paiements.FirstOrDefault(p => p.Reservation == p_reservation);
            return it;
        }
        public Paiement GetByModePaiement(ModePaiement p_modePaiement)
        {
            Paiement it = _appDbContext.Paiements.FirstOrDefault(p => p.ModePaiement == p_modePaiement);
            return it;
        }
        public Paiement GetByMontant(decimal p_montant)
        {
            Paiement it = _appDbContext.Paiements.FirstOrDefault(p => p.Montant == p_montant);
            return it;
        }
        public Paiement GetByDatePaiement(DateOnly p_DatePaiement)
        {
            Paiement it = _appDbContext.Paiements.FirstOrDefault(p => p.DatePaiement == p_DatePaiement);
            return it;
        }
        public Paiement GetByStatut(string p_statut)
        {
            Paiement it = _appDbContext.Paiements.FirstOrDefault(p => p.Statut == p_statut);
            return it;
        }

        //suppression de l'objet.
        void SupprimerParObjet(Paiement paiement)
        {
            if (paiement == null) { return; }
            _appDbContext.Paiements.Remove(paiement);
            _appDbContext.SaveChanges();
        }
        //1- par reservation
        public void SupprimerParReservation(Reservation p_reservation)
        {
            Paiement it = GetByReservation(p_reservation);
            SupprimerParObjet(it);
        }
        //2 - par mode de paiement
        public void SupprimerParModePaiement(ModePaiement p_modePaiement)
        {
            Paiement it = GetByModePaiement(p_modePaiement);
            SupprimerParObjet(it);
        }
        //3- par ID
        public void SupprimerParId(int p_id)
        {
            Paiement it = GetById(p_id);
            SupprimerParObjet(it);
        }
        //4- par statut
        public void SupprimerParStatut(string p_statut)
        {
            Paiement it = GetByStatut(p_statut);
            SupprimerParObjet(it);
        }

        //Methodes d'assignations
        public void UpdateReservationParId(int p_id, Reservation p_reservation)
        {
            Paiement it = GetById(p_id);
            if (it == null) { return; }

            Reservation oldReservation = it.Reservation;
            it.Reservation = p_reservation;

            try
            {
                ValiderPaiement(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Reservation = oldReservation;
                throw;
            }
        }
        public void UpdateModePaiementParId(int p_id, ModePaiement p_modePaiement)
        {
            Paiement it = GetById(p_id);
            if (it == null) { return; }

            ModePaiement oldModePaiement = it.ModePaiement;
            it.ModePaiement = p_modePaiement;

            try
            {
                ValiderPaiement(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.ModePaiement = oldModePaiement;
                throw;
            }
        }
        public void UpdateMontantParId(int p_id, decimal p_montant)
        {
            Paiement it = GetById(p_id);
            if (it == null) { return; }

            decimal oldMontant = it.Montant;
            it.Montant = p_montant;

            try
            {
                ValiderPaiement(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Montant = oldMontant;
                throw;
            }
        }
        public void UpdateDatePaiementParId(int p_id, DateOnly p_DatePaiement)
        {
            Paiement it = GetById(p_id);
            if (it == null) { return; }

            DateOnly oldDatePaiement = it.DatePaiement;
            it.DatePaiement = p_DatePaiement;

            try
            {
                ValiderPaiement(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.DatePaiement = oldDatePaiement;
                throw;
            }
        }
        public void UpdateStatutParId(int p_id, string p_statut)
        {
            Paiement it = GetById(p_id);
            if (it == null) { return; }

            string oldStatut = it.Statut;
            it.Statut = p_statut;

            try
            {
                ValiderPaiement(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Statut = oldStatut;
                throw;
            }
        }

        //TODO : OBTENIR LA LISTE
        public List<Paiement> GetAll()
        {
            return _appDbContext.Paiements.ToList();
        }
    }
}
