using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class chef_assis_to_employer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ChefEquipes_ChefEquipeId",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "ChefEquipeId",
                table: "Activities",
                newName: "EmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_ChefEquipeId",
                table: "Activities",
                newName: "IX_Activities_EmployerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Employer_EmployerId",
                table: "Activities",
                column: "EmployerId",
                principalTable: "Employer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Employer_EmployerId",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "EmployerId",
                table: "Activities",
                newName: "ChefEquipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_EmployerId",
                table: "Activities",
                newName: "IX_Activities_ChefEquipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ChefEquipes_ChefEquipeId",
                table: "Activities",
                column: "ChefEquipeId",
                principalTable: "ChefEquipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
