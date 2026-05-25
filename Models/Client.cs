using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * \brief implantation de la classe modele Client
 */

namespace TransportManagementSystem.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName  { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public Client(int p_Id, string p_Name, string p_firstName,string p_Telephone, string p_Email) {
            
            Id = p_Id;
            Name = p_Name;
            FirstName = p_firstName;
            Telephone = p_Telephone;
            Email = p_Email;
        }
        public Client() { }

    }
}
