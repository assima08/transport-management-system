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
    public class TrajetRepository
    {
        private AppDbContext _appDbContext;
        private readonly TrajetValidator _trajetValidator;

        public List<string> LastValidationErrors { get; private set; }

        //TODO : CONSTRUCTEUR
        public TrajetRepository()
        {
            _appDbContext = new AppDbContext();
            _trajetValidator = new TrajetValidator();
            LastValidationErrors = new List<string>();
        }

        private void ValiderTrajet(Trajet trajet)
        {
            LastValidationErrors = _trajetValidator.Validate(trajet);

            if (LastValidationErrors.Count > 0)
            {
                throw new InvalidOperationException(string.Join(Environment.NewLine, LastValidationErrors));
            }
        }

        // Ajout par Objet
        public void AjouterTrajet(Trajet trajet)
        {
            ValiderTrajet(trajet);
            _appDbContext.Trajets.Add(trajet);
            _appDbContext.SaveChanges();
        }
        //Ajout par attributs (fera appel a l'ajout par objet).
        public void AjouterEtcreerTrajet(int p_VilleDepart, int p_VilleArrivee, TimeOnly p_HeureDepart, TimeOnly p_HeureArrivee, decimal p_Prix)
        {
            Trajet trajet = new Trajet(p_VilleDepart, p_VilleArrivee, p_HeureDepart, p_HeureArrivee, p_Prix);

            AjouterTrajet(trajet);
        }

        //Methodes de recherches par attributs
        public Trajet GetById(int p_Id)
        {
            Trajet it = _appDbContext.Trajets.Find(p_Id);
            return it;
        }

        public Trajet GetByVilleDepartId(int p_VilleDepartId)
        {
            Trajet it = _appDbContext.Trajets.FirstOrDefault(t => t.VilleDepartId == p_VilleDepartId);
            return it;
        }
        public Trajet GetByVilleArriveeId(int p_VilleArriveeId)
        {
            Trajet it = _appDbContext.Trajets.FirstOrDefault(t => t.VilleArriveeId == p_VilleArriveeId);
            return it;
        }
        public Trajet GetByHeureDepart(TimeOnly p_HeureDepart)
        {
            Trajet it = _appDbContext.Trajets.FirstOrDefault(t => t.HeureDepart == p_HeureDepart);
            return it;
        }
        public Trajet GetByHeureArrivee(TimeOnly p_HeureArrivee)
        {
            Trajet it = _appDbContext.Trajets.FirstOrDefault(t => t.HeureArrivee == p_HeureArrivee);
            return it;
        }
        public Trajet GetByPrix(decimal p_Prix)
        {
            Trajet it = _appDbContext.Trajets.FirstOrDefault(t => t.Prix == p_Prix);
            return it;
        }

        //suppression de l'objet.
        void SupprimerParObjet(Trajet trajet)
        {
            if (trajet == null) { return; }
            _appDbContext.Trajets.Remove(trajet);
            _appDbContext.SaveChanges();
        }
        //1- par ville de depart
        public void SupprimerParVilleDepartId(int p_VilleDepartId)
        {
            Trajet it = GetByVilleDepartId(p_VilleDepartId);
            SupprimerParObjet(it);
        }
        //2 - par ville d'arrivee
        public void SupprimerParVilleArriveeId(int p_VilleArriveeId)
        {
            Trajet it = GetByVilleArriveeId(p_VilleArriveeId);
            SupprimerParObjet(it);
        }
        //3- par ID
        public void SupprimerParId(int p_id)
        {
            Trajet it = GetById(p_id);
            SupprimerParObjet(it);
        }
        //4- par prix
        public void SupprimerParPrix(decimal p_Prix)
        {
            Trajet it = GetByPrix(p_Prix);
            SupprimerParObjet(it);
        }

        //Methodes d'assignations
        public void UpdateVilleDepartIdParId(int p_id, int p_VilleDepartId)
        {
            Trajet it = GetById(p_id);
            if (it == null) { return; }

            int oldVilleDepartId = it.VilleDepartId;
            it.VilleDepartId = p_VilleDepartId;

            try
            {
                ValiderTrajet(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.VilleDepartId = oldVilleDepartId;
                throw;
            }
        }
        public void UpdateVilleArriveeIdParId(int p_id, int p_VilleArriveeId)
        {
            Trajet it = GetById(p_id);
            if (it == null) { return; }

            int oldVilleArriveeId = it.VilleArriveeId;
            it.VilleArriveeId = p_VilleArriveeId;

            try
            {
                ValiderTrajet(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.VilleArriveeId = oldVilleArriveeId;
                throw;
            }
        }
        public void UpdateHeureDepartParId(int p_id, TimeOnly p_HeureDepart)
        {
            Trajet it = GetById(p_id);
            if (it == null) { return; }

            TimeOnly oldHeureDepart = it.HeureDepart;
            it.HeureDepart = p_HeureDepart;

            try
            {
                ValiderTrajet(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.HeureDepart = oldHeureDepart;
                throw;
            }
        }
        public void UpdateHeureArriveeParId(int p_id, TimeOnly p_HeureArrivee)
        {
            Trajet it = GetById(p_id);
            if (it == null) { return; }

            TimeOnly oldHeureArrivee = it.HeureArrivee;
            it.HeureArrivee = p_HeureArrivee;

            try
            {
                ValiderTrajet(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.HeureArrivee = oldHeureArrivee;
                throw;
            }
        }
        public void UpdatePrixParId(int p_id, decimal p_Prix)
        {
            Trajet it = GetById(p_id);
            if (it == null) { return; }

            decimal oldPrix = it.Prix;
            it.Prix = p_Prix;

            try
            {
                ValiderTrajet(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Prix = oldPrix;
                throw;
            }
        }

        //TODO : OBTENIR LA LISTE
        public List<Trajet> GetAll()
        {
            return _appDbContext.Trajets.ToList();
        }
    }
}
