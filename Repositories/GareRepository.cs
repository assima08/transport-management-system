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
    public class GareRepository
    {
        private AppDbContext _appDbContext;
        private readonly GareValidator _gareValidator;

        public List<string> LastValidationErrors { get; private set; }

        //TODO : CONSTRUCTEUR
        public GareRepository()
        {
            _appDbContext = new AppDbContext();
            _gareValidator = new GareValidator();
            LastValidationErrors = new List<string>();
        }

        private void ValiderGare(Gare gare)
        {
            LastValidationErrors = _gareValidator.Validate(gare);

            if (LastValidationErrors.Count > 0)
            {
                throw new InvalidOperationException(string.Join(Environment.NewLine, LastValidationErrors));
            }
        }

        // Ajout par Objet
        public void AjouterGare(Gare gare)
        {
            ValiderGare(gare);
            _appDbContext.Set<Gare>().Add(gare);
            _appDbContext.SaveChanges();
        }
        //Ajout par attributs (fera appel a l'ajout par objet).
        public void AjouterEtcreerGare(string p_nom, string p_adresse, double p_latitude, double p_longitude, Ville p_ville)
        {
            Gare gare = new Gare(p_nom, p_adresse, p_latitude, p_longitude, p_ville);

            AjouterGare(gare);
        }

        //Methodes de recherches par attributs
        public Gare GetById(int p_Id)
        {
            Gare it = _appDbContext.Set<Gare>().Find(p_Id);
            return it;
        }

        public Gare GetByNom(string p_nom)
        {
            Gare it = _appDbContext.Set<Gare>().FirstOrDefault(g => g.Nom == p_nom);
            return it;
        }
        public Gare GetByAdresse(string p_adresse)
        {
            Gare it = _appDbContext.Set<Gare>().FirstOrDefault(g => g.Adresse == p_adresse);
            return it;
        }
        public Gare GetByLatitude(double p_latitude)
        {
            Gare it = _appDbContext.Set<Gare>().FirstOrDefault(g => g.Latitude == p_latitude);
            return it;
        }
        public Gare GetByLongitude(double p_longitude)
        {
            Gare it = _appDbContext.Set<Gare>().FirstOrDefault(g => g.Longitude == p_longitude);
            return it;
        }
        public Gare GetByCoordonnees(double p_latitude, double p_longitude)
        {
            Gare it = _appDbContext.Set<Gare>().FirstOrDefault(g => g.Latitude == p_latitude && g.Longitude == p_longitude);
            return it;
        }
        public Gare GetByVille(Ville p_ville)
        {
            Gare it = _appDbContext.Set<Gare>().FirstOrDefault(g => g.ville == p_ville);
            return it;
        }

        //suppression de l'objet.
        void SupprimerParObjet(Gare gare)
        {
            if (gare == null) { return; }
            _appDbContext.Set<Gare>().Remove(gare);
            _appDbContext.SaveChanges();
        }
        //1- par nom
        public void SupprimerParNom(string p_nom)
        {
            Gare it = GetByNom(p_nom);
            SupprimerParObjet(it);
        }
        //2 - par adresse
        public void SupprimerParAdresse(string p_adresse)
        {
            Gare it = GetByAdresse(p_adresse);
            SupprimerParObjet(it);
        }
        //3- par ID
        public void SupprimerParId(int p_id)
        {
            Gare it = GetById(p_id);
            SupprimerParObjet(it);
        }
        //4- par coordonnees
        public void SupprimerParCoordonnees(double p_latitude, double p_longitude)
        {
            Gare it = GetByCoordonnees(p_latitude, p_longitude);
            SupprimerParObjet(it);
        }

        //Methodes d'assignations
        public void UpdateNomParId(int p_id, string p_nom)
        {
            Gare it = GetById(p_id);
            if (it == null) { return; }

            string oldNom = it.Nom;
            it.Nom = p_nom;

            try
            {
                ValiderGare(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Nom = oldNom;
                throw;
            }
        }
        public void UpdateAdresseParId(int p_id, string p_adresse)
        {
            Gare it = GetById(p_id);
            if (it == null) { return; }

            string oldAdresse = it.Adresse;
            it.Adresse = p_adresse;

            try
            {
                ValiderGare(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Adresse = oldAdresse;
                throw;
            }
        }
        public void UpdateLatitudeParId(int p_id, double p_latitude)
        {
            Gare it = GetById(p_id);
            if (it == null) { return; }

            double oldLatitude = it.Latitude;
            it.Latitude = p_latitude;

            try
            {
                ValiderGare(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Latitude = oldLatitude;
                throw;
            }
        }
        public void UpdateLongitudeParId(int p_id, double p_longitude)
        {
            Gare it = GetById(p_id);
            if (it == null) { return; }

            double oldLongitude = it.Longitude;
            it.Longitude = p_longitude;

            try
            {
                ValiderGare(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Longitude = oldLongitude;
                throw;
            }
        }
        public void UpdateVilleParId(int p_id, Ville p_ville)
        {
            Gare it = GetById(p_id);
            if (it == null) { return; }

            Ville oldVille = it.ville;
            it.ville = p_ville;

            try
            {
                ValiderGare(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.ville = oldVille;
                throw;
            }
        }

        //TODO : OBTENIR LA LISTE
        public List<Gare> GetAll()
        {
            return _appDbContext.Set<Gare>().ToList();
        }
    }
}
