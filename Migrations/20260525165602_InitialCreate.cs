using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TransportManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chauffeurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Prenom = table.Column<string>(type: "text", nullable: false),
                    Telephone = table.Column<string>(type: "text", nullable: false),
                    NumeroPermis = table.Column<string>(type: "text", nullable: false),
                    DateExpirationPermis = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chauffeurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    Telephone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModePaiements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModePaiements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trajets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VilleDepartId = table.Column<int>(type: "integer", nullable: false),
                    VilleArriveeId = table.Column<int>(type: "integer", nullable: false),
                    HeureDepart = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    HeureArrivee = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Prix = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trajets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    plaque = table.Column<string>(type: "text", nullable: false),
                    marque = table.Column<string>(type: "text", nullable: false),
                    modele = table.Column<string>(type: "text", nullable: false),
                    capacite = table.Column<int>(type: "integer", nullable: false),
                    annee = table.Column<int>(type: "integer", nullable: false),
                    statut = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Villes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomVille = table.Column<string>(type: "text", nullable: false),
                    Province = table.Column<string>(type: "text", nullable: false),
                    Pays = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehiculeId = table.Column<int>(type: "integer", nullable: false),
                    ChauffeurId = table.Column<int>(type: "integer", nullable: false),
                    TrajetId = table.Column<int>(type: "integer", nullable: false),
                    DateDepart = table.Column<DateOnly>(type: "date", nullable: false),
                    DateArrivee = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horaires_Chauffeurs_ChauffeurId",
                        column: x => x.ChauffeurId,
                        principalTable: "Chauffeurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Horaires_Trajets_TrajetId",
                        column: x => x.TrajetId,
                        principalTable: "Trajets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Horaires_Vehicules_VehiculeId",
                        column: x => x.VehiculeId,
                        principalTable: "Vehicules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    HoraireId = table.Column<int>(type: "integer", nullable: false),
                    NumSiege = table.Column<int>(type: "integer", nullable: false),
                    Statut = table.Column<string>(type: "text", nullable: false),
                    DateReservation = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Horaires_HoraireId",
                        column: x => x.HoraireId,
                        principalTable: "Horaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paiements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReservationId = table.Column<int>(type: "integer", nullable: false),
                    ModePaiementId = table.Column<int>(type: "integer", nullable: false),
                    Montant = table.Column<decimal>(type: "numeric", nullable: false),
                    DatePaiement = table.Column<DateOnly>(type: "date", nullable: false),
                    Statut = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paiements_ModePaiements_ModePaiementId",
                        column: x => x.ModePaiementId,
                        principalTable: "ModePaiements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paiements_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horaires_ChauffeurId",
                table: "Horaires",
                column: "ChauffeurId");

            migrationBuilder.CreateIndex(
                name: "IX_Horaires_TrajetId",
                table: "Horaires",
                column: "TrajetId");

            migrationBuilder.CreateIndex(
                name: "IX_Horaires_VehiculeId",
                table: "Horaires",
                column: "VehiculeId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_ModePaiementId",
                table: "Paiements",
                column: "ModePaiementId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_ReservationId",
                table: "Paiements",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HoraireId",
                table: "Reservations",
                column: "HoraireId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paiements");

            migrationBuilder.DropTable(
                name: "Villes");

            migrationBuilder.DropTable(
                name: "ModePaiements");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Horaires");

            migrationBuilder.DropTable(
                name: "Chauffeurs");

            migrationBuilder.DropTable(
                name: "Trajets");

            migrationBuilder.DropTable(
                name: "Vehicules");
        }
    }
}
