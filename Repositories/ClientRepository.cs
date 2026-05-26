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
    public class ClientRepository
    {
        private AppDbContext _appDbContext;
        private readonly ClientValidator _clientValidator;

        public List<string> LastValidationErrors { get; private set; }

        //TODO : CONSTRUCTEUR
        public ClientRepository()
        {
            _appDbContext = new AppDbContext();
            _clientValidator = new ClientValidator();
            LastValidationErrors = new List<string>();
        }

        private void ValiderClient(Client client)
        {
            LastValidationErrors = _clientValidator.Validate(client);

            if (LastValidationErrors.Count > 0)
            {
                throw new InvalidOperationException(string.Join(Environment.NewLine, LastValidationErrors));
            }
        }

        // Ajout par Objet
        public void AjouterClient(Client client)
        {
            ValiderClient(client);
            _appDbContext.Clients.Add(client);
            _appDbContext.SaveChanges();
        }
        //Ajout par attributs (fera appel a l'ajout par objet).
        public void AjouterEtcreerClient(string p_Name, string p_firstName, string p_Telephone, string p_Email)
        {
            Client client = new Client(p_Name, p_firstName, p_Telephone, p_Email);

            AjouterClient(client);
        }

        //Methodes de recherches par attributs
        public Client GetById(int p_Id)
        {
            Client it = _appDbContext.Clients.Find(p_Id);
            return it;
        }

        public Client GetByTelephone(string p_telephone)
        {
            Client it = _appDbContext.Clients.FirstOrDefault(c => c.Telephone == p_telephone);
            return it;
        }
        public Client GetByEmail(string p_email)
        {
            Client it = _appDbContext.Clients.FirstOrDefault(c => c.Email == p_email);
            return it;
        }
        public Client GetByNom(string p_name, string p_firstName)
        {
            Client it = _appDbContext.Clients.FirstOrDefault(c => c.Name == p_name && c.FirstName == p_firstName);
            return it;
        }

        //suppression de l'objet.
        void SupprimerParObjet(Client client)
        {
            if (client == null) { return; }
            _appDbContext.Clients.Remove(client);
            _appDbContext.SaveChanges();
        }
        //1- par nom + prenom
        public void SupprimerParNom(string p_name, string p_firstName)
        {
            Client it = GetByNom(p_name, p_firstName);
            SupprimerParObjet(it);
        }
        //2 - par telephone
        public void SupprimerParTelephone(string p_telephone)
        {
            Client it = GetByTelephone(p_telephone);
            SupprimerParObjet(it);
        }
        //3- par ID
        public void SupprimerParId(int p_id)
        {
            Client it = GetById(p_id);
            SupprimerParObjet(it);
        }
        //4- par email
        public void SupprimerParEmail(string p_email)
        {
            Client it = GetByEmail(p_email);
            SupprimerParObjet(it);
        }

        //Methodes d'assignations
        public void UpdateTelephone(string p_numeroTelephone, string p_NewTelephone)
        {
            Client it = GetByTelephone(p_numeroTelephone);
            if (it == null) { return; }

            string oldTelephone = it.Telephone;
            it.Telephone = p_NewTelephone;

            try
            {
                ValiderClient(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Telephone = oldTelephone;
                throw;
            }
        }
        public void UpdateEmail(string p_email, string p_NewEmail)
        {
            Client it = GetByEmail(p_email);
            if (it == null) { return; }

            string oldEmail = it.Email;
            it.Email = p_NewEmail;

            try
            {
                ValiderClient(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Email = oldEmail;
                throw;
            }
        }
        public void UpdateNameParId(int p_id, string p_name)
        {
            Client it = GetById(p_id);
            if (it == null) { return; }

            string oldName = it.Name;
            it.Name = p_name;

            try
            {
                ValiderClient(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.Name = oldName;
                throw;
            }
        }
        public void UpdateFirstNameParId(int p_id, string p_firstName)
        {
            Client it = GetById(p_id);
            if (it == null) { return; }

            string oldFirstName = it.FirstName;
            it.FirstName = p_firstName;

            try
            {
                ValiderClient(it);
                _appDbContext.SaveChanges();
            }
            catch
            {
                it.FirstName = oldFirstName;
                throw;
            }
        }

        //TODO : OBTENIR LA LISTE
        public List<Client> GetAll()
        {
            return _appDbContext.Clients.ToList();
        }
    }
}
