using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Models
{
    /**
     * \brief implantation de la classe modele Paiement
     */
    public class Paiement
    {
        public int Id { get; set; }
        public Reservation Reservation { get; set; }
        public ModePaiement ModePaiement { get; set; }
        public decimal Montant { get; set; }
        public DateOnly DatePaiement { get; set; }
        public string Statut { get; set; }

        public Paiement(int p_Id, Reservation p_Reservation, ModePaiement p_ModePaiement, decimal p_Montant, DateOnly p_DatePaiement, string p_Statut)
        {
            Id = p_Id;
            Reservation = p_Reservation;
            ModePaiement = p_ModePaiement;
            Montant = p_Montant;
            DatePaiement = p_DatePaiement;
            Statut = p_Statut;
        }
        public Paiement() { }   
    }
}
