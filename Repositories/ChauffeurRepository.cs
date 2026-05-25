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

        //TODO : AJOUT 

        public void  AjouterChauffeur(Chauffeur chauffeur)
        {
            _appDbContext.Chauffeurs.Add(chauffeur);
            _appDbContext.SaveChanges();
        }

        public void AjouterEtcreerChauffeur(string p_nom, string p_Prenom, string p_Telephone, string p_NumeroPermis, DateOnly p_DateExpirationPermis)
        {
            Chauffeur chauffeur = new Chauffeur(p_nom,p_Prenom,p_Telephone,p_NumeroPermis,p_DateExpirationPermis);
            _appDbContext.Chauffeurs.Add(chauffeur);
            _appDbContext.SaveChanges();
        }

        //TODO : SUPPRESSION
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
