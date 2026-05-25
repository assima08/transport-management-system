using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransportManagementSystem.Models;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using System.IO;


/**
 * \brief implementation de la class AppDbContext
 * elle hérite de la class DbContext
 * sert à faire la connexion entre 
 */
namespace TransportManagementSystem.Database
{
    public class AppDbContext : DbContext
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


        public AppDbContext(){
         
        }
        /**
         * @brief etablissement de la connexion vers la BD
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //declaration de la variable de type Iconfiguration
            IConfiguration configuration = new ConfigurationBuilder()
                                                .SetBasePath(Directory.GetCurrentDirectory())
                                                .AddJsonFile("appsettings.json")
                                                .AddUserSecrets<AppDbContext>()
                                                .Build();

            //recuperons chaque élément de connexion
            string host = configuration["ConnectionStrings:Host"];
            string port = configuration["ConnectionStrings:Port"];
            string database = configuration["ConnectionStrings:Database"];
            string username = configuration["ConnectionStrings:Username"];
            string password = configuration["ConnectionStrings:Password"];

            //preparer la reque de connexion pour postgresql
            string ConnectionString =
                $"Host={host};" +
                $"Port={port};" +
                $"Database={database};" +
                $"Username={username};" +
                $"Password={password}";
            //etablir la connexion
            optionsBuilder.UseNpgsql(ConnectionString);
        }
        


    }
}
