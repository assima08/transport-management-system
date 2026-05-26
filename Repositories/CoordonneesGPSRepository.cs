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
    public class CoordonneesGPSRepository
    {
        private AppDbContext _appDbContext;
        private readonly CoordonneesGPSValidator _coordonneesGPSValidator;

        public List<string> LastValidationErrors { get; private set; }

        //TODO : CONSTRUCTEUR
        public CoordonneesGPSRepository()
        {
            _appDbContext = new AppDbContext();
            _coordonneesGPSValidator = new CoordonneesGPSValidator();
            LastValidationErrors = new List<string>();
        }

        private void ValiderCoordonneesGPS(CoordonneesGPS coordonneesGPS)
        {
            LastValidationErrors = _coordonneesGPSValidator.Validate(coordonneesGPS);

            if (LastValidationErrors.Count > 0)
            {
                throw new InvalidOperationException(string.Join(Environment.NewLine, LastValidationErrors));
            }
        }

        // Ajout par Objet
        public void AjouterCoordonneesGPS(CoordonneesGPS coordonneesGPS)
        {
            ValiderCoordonneesGPS(coordonneesGPS);
            _appDbContext.Set<CoordonneesGPS>().Add(coordonneesGPS);
            _appDbContext.SaveChanges();
        }
        //Ajout par attributs (fera appel a l'ajout par objet).
        public void AjouterEtcreerCoordonneesGPS(double p_latitude, double p_longitude)
        {
            CoordonneesGPS coordonneesGPS = new CoordonneesGPS
            {
                Latitude = p_latitude,
                Longitude = p_longitude
            };

            AjouterCoordonneesGPS(coordonneesGPS);
        }

        //Methodes de recherches par attributs
        public CoordonneesGPS GetByLatitude(double p_latitude)
        {
            CoordonneesGPS it = _appDbContext.Set<CoordonneesGPS>().FirstOrDefault(c => c.Latitude == p_latitude);
            return it;
        }
        public CoordonneesGPS GetByLongitude(double p_longitude)
        {
            CoordonneesGPS it = _appDbContext.Set<CoordonneesGPS>().FirstOrDefault(c => c.Longitude == p_longitude);
            return it;
        }
        public CoordonneesGPS GetByCoordonnees(double p_latitude, double p_longitude)
        {
            CoordonneesGPS it = _appDbContext.Set<CoordonneesGPS>().FirstOrDefault(c => c.Latitude == p_latitude && c.Longitude == p_longitude);
            return it;
        }

        //suppression de l'objet.
        void SupprimerParObjet(CoordonneesGPS coordonneesGPS)
        {
            if (coordonneesGPS == null) { return; }
            _appDbContext.Set<CoordonneesGPS>().Remove(coordonneesGPS);
            _appDbContext.SaveChanges();
        }
        //1- par latitude
        public void SupprimerParLatitude(double p_latitude)
        {
            CoordonneesGPS it = GetByLatitude(p_latitude);
            SupprimerParObjet(it);
        }
        //2 - par longitude
        public void SupprimerParLongitude(double p_longitude)
        {
            CoordonneesGPS it = GetByLongitude(p_longitude);
            SupprimerParObjet(it);
        }
        //3- par coordonnees
        public void SupprimerParCoordonnees(double p_latitude, double p_longitude)
        {
            CoordonneesGPS it = GetByCoordonnees(p_latitude, p_longitude);
            SupprimerParObjet(it);
        }

        //Methodes d'assignations
        public void UpdateLatitude(double p_latitude, double p_NewLatitude)
        {
            CoordonneesGPS it = GetByLatitude(p_latitude);
            if (it == null) { return; }

            double oldLatitude = it.Latitude;
            it.Latitude = p_NewLatitude;

            try
            {
                ValiderCoordonneesGPS(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Latitude = oldLatitude;
                throw;
            }
        }
        public void UpdateLongitude(double p_longitude, double p_NewLongitude)
        {
            CoordonneesGPS it = GetByLongitude(p_longitude);
            if (it == null) { return; }

            double oldLongitude = it.Longitude;
            it.Longitude = p_NewLongitude;

            try
            {
                ValiderCoordonneesGPS(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Longitude = oldLongitude;
                throw;
            }
        }
        public void UpdateCoordonnees(double p_latitude, double p_longitude, double p_NewLatitude, double p_NewLongitude)
        {
            CoordonneesGPS it = GetByCoordonnees(p_latitude, p_longitude);
            if (it == null) { return; }

            double oldLatitude = it.Latitude;
            double oldLongitude = it.Longitude;
            it.Latitude = p_NewLatitude;
            it.Longitude = p_NewLongitude;

            try
            {
                ValiderCoordonneesGPS(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Latitude = oldLatitude;
                it.Longitude = oldLongitude;
                throw;
            }
        }

        //TODO : OBTENIR LA LISTE
        public List<CoordonneesGPS> GetAll()
        {
            return _appDbContext.Set<CoordonneesGPS>().ToList();
        }
    }
}
