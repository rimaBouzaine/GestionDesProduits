using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDesProduits.Migrations
{
    public partial class m7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "prixProduitEnPromo",
                table: "ProduitPromo",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "NomProduit",
                table: "LigneProduit",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prixProduitEnPromo",
                table: "ProduitPromo");

            migrationBuilder.AlterColumn<int>(
                name: "NomProduit",
                table: "LigneProduit",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
