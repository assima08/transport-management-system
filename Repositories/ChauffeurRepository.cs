using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Models;
using TransportManagementSystem.Database;
using System.IO.Packaging;

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
        //Ajout par attributs (fera appel a l'ajout par objet).
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
        public Chauffeur GetByyNumPermis(string p_NumPermis) { 
        
                Chauffeur it = _appDbContext.Chauffeurs.FirstOrDefault(c => c.NumeroPermis == p_NumPermis);
            return it;
        }
       

        //suppression de l'objet.
        void SupprimerParObjet(Chauffeur chauffeur){
                if (chauffeur == null) { return; }
            _appDbContext.Chauffeurs.Remove(chauffeur);
            _appDbContext.SaveChanges();
        }
        //1- par nom + prenom
        public void SupprimerParNom(string  p_nom, string  p_prenom)
        {
            Chauffeur it = GetByNom(p_nom, p_prenom);
            SupprimerParObjet(it);
        }
        //2 - par telephone
        public void SupprimerParTelephone(string p_telephone)
        {
            Chauffeur it = GetByTelephone(p_telephone);
            SupprimerParObjet(it);
            
        }
        //3- par ID
        public void SupprimerParId(int p_id)
        {
            Chauffeur it = GetById(p_id);
            SupprimerParObjet(it);
        }
        //4- Par Numérp de permis
        public void SupprimerParNumeroPermis(string p_numeroPermis)
        {
            Chauffeur it = GetByyNumPermis(p_numeroPermis);
            SupprimerParObjet(it);
        }

        //Methodes d'assignations

        public void UpdateTelephone(string p_numeroTelephone, string p_NewTelephone)
        {
            Chauffeur it = GetByTelephone(p_numeroTelephone);
            if (it == null) { return; }
            it.Telephone = p_NewTelephone;
            
            _appDbContext.SaveChanges();

        }
        public void UpdateNumeroPermis(string p_Permis, string p_NewNumPermis)
        {
            Chauffeur it = GetByyNumPermis(p_Permis);
            if (it == null) { return; }
            it.NumeroPermis = p_NewNumPermis;

            _appDbContext.SaveChanges();

        }
        public void UpdateNomParId(int p_id,string p_nom)
        {
            Chauffeur it = GetById(p_id);
            if (it == null) { return; }
            it.Nom = p_nom;
            _appDbContext.SaveChanges();
        }

        public void UpdatePreomParId(int p_id, string p_prenom)
        {
            Chauffeur it = GetById(p_id);
            if (it == null) { return; }
            it.Prenom = p_prenom;
            _appDbContext.SaveChanges();
        }

        //TODO : OBTENIR LA LISTE
        public List<Chauffeur> GetAll()
        {
            return _appDbContext.Chauffeurs.ToList();
        }

    }
}
