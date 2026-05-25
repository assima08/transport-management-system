using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Models;

/**
 * \brief implantation de la classe modele Reservation
 */

namespace TransportManagementSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Horaire Horaire { get; set; }
        public int NumSiege {  get; set; }
        public string Statut { get; set; }
        public DateOnly DateReservation { get; set; }
       
        public Reservation(int p_Id, Client p_Client, Horaire p_Horaire,int p_numSiege, string p_statut, DateOnly p_DateReservation) { 
            
            Id = p_Id;
            Client = p_Client;
            Horaire = p_Horaire;
            NumSiege = p_numSiege;
            Statut = p_statut;
            DateReservation = p_DateReservation;
        }
        public Reservation() { }
    }
}
