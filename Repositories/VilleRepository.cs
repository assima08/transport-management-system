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
    public class VilleRepository
    {
        private AppDbContext _appDbContext;
        private readonly VilleValidator _villeValidator;

        public List<string> LastValidationErrors { get; private set; }

        //TODO : CONSTRUCTEUR
        public VilleRepository()
        {
            _appDbContext = new AppDbContext();
            _villeValidator = new VilleValidator();
            LastValidationErrors = new List<string>();
        }

        private void ValiderVille(Ville ville)
        {
            LastValidationErrors = _villeValidator.Validate(ville);

            if (LastValidationErrors.Count > 0)
            {
                throw new InvalidOperationException(string.Join(Environment.NewLine, LastValidationErrors));
            }
        }

        // Ajout par Objet
        public void AjouterVille(Ville ville)
        {
            ValiderVille(ville);
            _appDbContext.Villes.Add(ville);
            _appDbContext.SaveChanges();
        }
        //Ajout par attributs (fera appel a l'ajout par objet).
        public void AjouterEtcreerVille(int p_Id, string P_NomVille, string p_Province, string p_Pays)
        {
            Ville ville = new Ville(p_Id, P_NomVille, p_Province, p_Pays);

            AjouterVille(ville);
        }

        //Methodes de recherches par attributs
        public Ville GetById(int p_Id)
        {
            Ville it = _appDbContext.Villes.Find(p_Id);
            return it;
        }

        public Ville GetByNomVille(string p_NomVille)
        {
            Ville it = _appDbContext.Villes.FirstOrDefault(v => v.NomVille == p_NomVille);
            return it;
        }
        public Ville GetByProvince(string p_Province)
        {
            Ville it = _appDbContext.Villes.FirstOrDefault(v => v.Province == p_Province);
            return it;
        }
        public Ville GetByPays(string p_Pays)
        {
            Ville it = _appDbContext.Villes.FirstOrDefault(v => v.Pays == p_Pays);
            return it;
        }

        //suppression de l'objet.
        void SupprimerParObjet(Ville ville)
        {
            if (ville == null) { return; }
            _appDbContext.Villes.Remove(ville);
            _appDbContext.SaveChanges();
        }
        //1- par nom
        public void SupprimerParNomVille(string p_NomVille)
        {
            Ville it = GetByNomVille(p_NomVille);
            SupprimerParObjet(it);
        }
        //2 - par province
        public void SupprimerParProvince(string p_Province)
        {
            Ville it = GetByProvince(p_Province);
            SupprimerParObjet(it);
        }
        //3- par ID
        public void SupprimerParId(int p_id)
        {
            Ville it = GetById(p_id);
            SupprimerParObjet(it);
        }
        //4- par pays
        public void SupprimerParPays(string p_Pays)
        {
            Ville it = GetByPays(p_Pays);
            SupprimerParObjet(it);
        }

        //Methodes d'assignations
        public void UpdateNomVilleParId(int p_id, string p_NomVille)
        {
            Ville it = GetById(p_id);
            if (it == null) { return; }

            string oldNomVille = it.NomVille;
            it.NomVille = p_NomVille;

            try
            {
                ValiderVille(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.NomVille = oldNomVille;
                throw;
            }
        }
        public void UpdateProvinceParId(int p_id, string p_Province)
        {
            Ville it = GetById(p_id);
            if (it == null) { return; }

            string oldProvince = it.Province;
            it.Province = p_Province;

            try
            {
                ValiderVille(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Province = oldProvince;
                throw;
            }
        }
        public void UpdatePaysParId(int p_id, string p_Pays)
        {
            Ville it = GetById(p_id);
            if (it == null) { return; }

            string oldPays = it.Pays;
            it.Pays = p_Pays;

            try
            {
                ValiderVille(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Pays = oldPays;
                throw;
            }
        }

        //TODO : OBTENIR LA LISTE
        public List<Ville> GetAll()
        {
            return _appDbContext.Villes.ToList();
        }
    }
}
