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
    public class ReservationRepository
    {
        private AppDbContext _appDbContext;
        private readonly ReservationValidator _reservationValidator;

        public List<string> LastValidationErrors { get; private set; }

        //TODO : CONSTRUCTEUR
        public ReservationRepository()
        {
            _appDbContext = new AppDbContext();
            _reservationValidator = new ReservationValidator();
            LastValidationErrors = new List<string>();
        }

        private void ValiderReservation(Reservation reservation)
        {
            LastValidationErrors = _reservationValidator.Validate(reservation);

            if (LastValidationErrors.Count > 0)
            {
                throw new InvalidOperationException(string.Join(Environment.NewLine, LastValidationErrors));
            }
        }

        // Ajout par Objet
        public void AjouterReservation(Reservation reservation)
        {
            ValiderReservation(reservation);
            _appDbContext.Reservations.Add(reservation);
            _appDbContext.SaveChanges();
        }
        //Ajout par attributs (fera appel a l'ajout par objet).
        public void AjouterEtcreerReservation(Client p_Client, Horaire p_Horaire, int p_numSiege, string p_statut, DateOnly p_DateReservation)
        {
            Reservation reservation = new Reservation(p_Client, p_Horaire, p_numSiege, p_statut, p_DateReservation);

            AjouterReservation(reservation);
        }

        //Methodes de recherches par attributs
        public Reservation GetById(int p_Id)
        {
            Reservation it = _appDbContext.Reservations.Find(p_Id);
            return it;
        }

        public Reservation GetByClient(Client p_client)
        {
            Reservation it = _appDbContext.Reservations.FirstOrDefault(r => r.Client == p_client);
            return it;
        }
        public Reservation GetByHoraire(Horaire p_horaire)
        {
            Reservation it = _appDbContext.Reservations.FirstOrDefault(r => r.Horaire == p_horaire);
            return it;
        }
        public Reservation GetByNumSiege(int p_numSiege)
        {
            Reservation it = _appDbContext.Reservations.FirstOrDefault(r => r.NumSiege == p_numSiege);
            return it;
        }
        public Reservation GetByStatut(string p_statut)
        {
            Reservation it = _appDbContext.Reservations.FirstOrDefault(r => r.Statut == p_statut);
            return it;
        }
        public Reservation GetByDateReservation(DateOnly p_DateReservation)
        {
            Reservation it = _appDbContext.Reservations.FirstOrDefault(r => r.DateReservation == p_DateReservation);
            return it;
        }

        //suppression de l'objet.
        void SupprimerParObjet(Reservation reservation)
        {
            if (reservation == null) { return; }
            _appDbContext.Reservations.Remove(reservation);
            _appDbContext.SaveChanges();
        }
        //1- par client
        public void SupprimerParClient(Client p_client)
        {
            Reservation it = GetByClient(p_client);
            SupprimerParObjet(it);
        }
        //2 - par horaire
        public void SupprimerParHoraire(Horaire p_horaire)
        {
            Reservation it = GetByHoraire(p_horaire);
            SupprimerParObjet(it);
        }
        //3- par ID
        public void SupprimerParId(int p_id)
        {
            Reservation it = GetById(p_id);
            SupprimerParObjet(it);
        }
        //4- par numero de siege
        public void SupprimerParNumSiege(int p_numSiege)
        {
            Reservation it = GetByNumSiege(p_numSiege);
            SupprimerParObjet(it);
        }

        //Methodes d'assignations
        public void UpdateClientParId(int p_id, Client p_client)
        {
            Reservation it = GetById(p_id);
            if (it == null) { return; }

            Client oldClient = it.Client;
            it.Client = p_client;

            try
            {
                ValiderReservation(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Client = oldClient;
                throw;
            }
        }
        public void UpdateHoraireParId(int p_id, Horaire p_horaire)
        {
            Reservation it = GetById(p_id);
            if (it == null) { return; }

            Horaire oldHoraire = it.Horaire;
            it.Horaire = p_horaire;

            try
            {
                ValiderReservation(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Horaire = oldHoraire;
                throw;
            }
        }
        public void UpdateNumSiegeParId(int p_id, int p_numSiege)
        {
            Reservation it = GetById(p_id);
            if (it == null) { return; }

            int oldNumSiege = it.NumSiege;
            it.NumSiege = p_numSiege;

            try
            {
                ValiderReservation(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.NumSiege = oldNumSiege;
                throw;
            }
        }
        public void UpdateStatutParId(int p_id, string p_statut)
        {
            Reservation it = GetById(p_id);
            if (it == null) { return; }

            string oldStatut = it.Statut;
            it.Statut = p_statut;

            try
            {
                ValiderReservation(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Statut = oldStatut;
                throw;
            }
        }
        public void UpdateDateReservationParId(int p_id, DateOnly p_DateReservation)
        {
            Reservation it = GetById(p_id);
            if (it == null) { return; }

            DateOnly oldDateReservation = it.DateReservation;
            it.DateReservation = p_DateReservation;

            try
            {
                ValiderReservation(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.DateReservation = oldDateReservation;
                throw;
            }
        }

        //TODO : OBTENIR LA LISTE
        public List<Reservation> GetAll()
        {
            return _appDbContext.Reservations.ToList();
        }
    }
}
