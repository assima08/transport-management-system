using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Database
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Chauffeur> Chauffeurs { get; set; }
        public DbSet<Horaire> Horaires { get; set; }
        public DbSet<ModePaiement> ModePaiements { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Trajet> Trajets { get; set; }
        public DbSet<Vehicule> Vehicules { get; set; }
        public DbSet<Ville> Villes { get; set; }


    }
}
