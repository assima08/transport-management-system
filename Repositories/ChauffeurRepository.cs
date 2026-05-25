using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Models;
using TransportManagementSystem.Database;

namespace TransportManagementSystem.Repositories
{
    public class ChauffeurRepository
    {
        private AppDbContext _appDbContext;

        //TODO : CONSTRUCTEUR
        public ChauffeurRepository()
        {
            _appDbContext = new AppDbContext();
        }

        // Ajout par Objet
        public void  AjouterChauffeur(Chauffeur chauffeur)
        {
            _appDbContext.Chauffeurs.Add(chauffeur);
            _appDbContext.SaveChanges();
        }
        //Ajout par attributs (fera appel a l'ajout par objet.
        public void AjouterEtcreerChauffeur(string p_nom, string p_Prenom, string p_Telephone, string p_NumeroPermis, DateOnly p_DateExpirationPermis)
        {
            Chauffeur chauffeur = new Chauffeur(p_nom,p_Prenom,p_Telephone,p_NumeroPermis,p_DateExpirationPermis);

            AjouterChauffeur(chauffeur);
        }

        //Methodes de recherches par attributs
        public Chauffeur GetById(int p_Id)
        {
             Chauffeur it = _appDbContext.Chauffeurs.Find(p_Id);
            return it;
        }

        public Chauffeur GetByTelephone(string p_telephone)
        {
            Chauffeur it = _appDbContext.Chauffeurs.FirstOrDefault(c=> c.Telephone == p_telephone);
            return it;
        }
        public Chauffeur GetByNom(string p_nom, string p_prenom)
        {
            Chauffeur it = _appDbContext.Chauffeurs.FirstOrDefault(c => c.Nom == p_nom && c.Prenom == p_prenom);
            return it;
        }
       

        //suppression de l'objet.
        public void SupprimerChauffeur(Chauffeur chauffeur)
        {
            _appDbContext.Chauffeurs.Remove(chauffeur);
            _appDbContext.SaveChanges();
        }

        //TODO : OBTENIR LA LISTE
        public List<Chauffeur> GetAll()
        {
            return _appDbContext.Chauffeurs.ToList();
        }

    }
}
