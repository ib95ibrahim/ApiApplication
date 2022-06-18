using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class CreateTablesAndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Persons_ChefEquipeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityImmigrant_Persons_ImmigrantsId",
                table: "ActivityImmigrant");

            migrationBuilder.DropForeignKey(
                name: "FK_ImmigrantService_Persons_ImmigrantsId",
                table: "ImmigrantService");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Locations_LocationId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Persons_ChefEquipeId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Services_ServiceId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Rapports_Persons_AdministratorId",
                table: "Rapports");

            migrationBuilder.DropIndex(
                name: "IX_Persons_ChefEquipeId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_LocationId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_ServiceId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Administrator_PasswordHash",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Administrator_PasswordSalt",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Administrator_UserName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ChefEquipeId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "EmployerType",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "TypeEquipe",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Vulnerability",
                table: "Persons");

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrators_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EmployerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeEquipe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employer_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employer_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Immigrants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vulnerability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Immigrants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Immigrants_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Immigrants_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChefEquipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefEquipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChefEquipes_Employer_Id",
                        column: x => x.Id,
                        principalTable: "Employer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Assistants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ChefEquipeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assistants_ChefEquipes_ChefEquipeId",
                        column: x => x.ChefEquipeId,
                        principalTable: "ChefEquipes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assistants_Employer_Id",
                        column: x => x.Id,
                        principalTable: "Employer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assistants_ChefEquipeId",
                table: "Assistants",
                column: "ChefEquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employer_ServiceId",
                table: "Employer",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Immigrants_LocationId",
                table: "Immigrants",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ChefEquipes_ChefEquipeId",
                table: "Activities",
                column: "ChefEquipeId",
                principalTable: "ChefEquipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityImmigrant_Immigrants_ImmigrantsId",
                table: "ActivityImmigrant",
                column: "ImmigrantsId",
                principalTable: "Immigrants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImmigrantService_Immigrants_ImmigrantsId",
                table: "ImmigrantService",
                column: "ImmigrantsId",
                principalTable: "Immigrants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rapports_Administrators_AdministratorId",
                table: "Rapports",
                column: "AdministratorId",
                principalTable: "Administrators",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ChefEquipes_ChefEquipeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityImmigrant_Immigrants_ImmigrantsId",
                table: "ActivityImmigrant");

            migrationBuilder.DropForeignKey(
                name: "FK_ImmigrantService_Immigrants_ImmigrantsId",
                table: "ImmigrantService");

            migrationBuilder.DropForeignKey(
                name: "FK_Rapports_Administrators_AdministratorId",
                table: "Rapports");

            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Assistants");

            migrationBuilder.DropTable(
                name: "Immigrants");

            migrationBuilder.DropTable(
                name: "ChefEquipes");

            migrationBuilder.DropTable(
                name: "Employer");

            migrationBuilder.AddColumn<byte[]>(
                name: "Administrator_PasswordHash",
                table: "Persons",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Administrator_PasswordSalt",
                table: "Persons",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Administrator_UserName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthDate",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChefEquipeId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployerType",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Persons",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Persons",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeEquipe",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vulnerability",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ChefEquipeId",
                table: "Persons",
                column: "ChefEquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_LocationId",
                table: "Persons",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ServiceId",
                table: "Persons",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Persons_ChefEquipeId",
                table: "Activities",
                column: "ChefEquipeId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityImmigrant_Persons_ImmigrantsId",
                table: "ActivityImmigrant",
                column: "ImmigrantsId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImmigrantService_Persons_ImmigrantsId",
                table: "ImmigrantService",
                column: "ImmigrantsId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Locations_LocationId",
                table: "Persons",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Persons_ChefEquipeId",
                table: "Persons",
                column: "ChefEquipeId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Services_ServiceId",
                table: "Persons",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rapports_Persons_AdministratorId",
                table: "Rapports",
                column: "AdministratorId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
