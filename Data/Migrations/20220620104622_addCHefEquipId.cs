using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class addCHefEquipId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ChefEquipes_ChefEquipeId",
                table: "Activities");

            migrationBuilder.AlterColumn<int>(
                name: "ChefEquipeId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ChefEquipes_ChefEquipeId",
                table: "Activities",
                column: "ChefEquipeId",
                principalTable: "ChefEquipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ChefEquipes_ChefEquipeId",
                table: "Activities");

            migrationBuilder.AlterColumn<int>(
                name: "ChefEquipeId",
                table: "Activities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ChefEquipes_ChefEquipeId",
                table: "Activities",
                column: "ChefEquipeId",
                principalTable: "ChefEquipes",
                principalColumn: "Id");
        }
    }
}
