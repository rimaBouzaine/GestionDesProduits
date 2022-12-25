using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDesProduits.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LigneProduit_ProduitPromo_ProduitPromoId",
                table: "LigneProduit");

            migrationBuilder.DropColumn(
                name: "NomProduit",
                table: "LigneProduit");

            migrationBuilder.AlterColumn<int>(
                name: "ProduitPromoId",
                table: "LigneProduit",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LigneProduit_ProduitPromo_ProduitPromoId",
                table: "LigneProduit",
                column: "ProduitPromoId",
                principalTable: "ProduitPromo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LigneProduit_ProduitPromo_ProduitPromoId",
                table: "LigneProduit");

            migrationBuilder.AlterColumn<int>(
                name: "ProduitPromoId",
                table: "LigneProduit",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "NomProduit",
                table: "LigneProduit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_LigneProduit_ProduitPromo_ProduitPromoId",
                table: "LigneProduit",
                column: "ProduitPromoId",
                principalTable: "ProduitPromo",
                principalColumn: "Id");
        }
    }
}
