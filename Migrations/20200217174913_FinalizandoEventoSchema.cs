using Microsoft.EntityFrameworkCore.Migrations;

namespace GFT_Tickets.Migrations
{
    public partial class FinalizandoEventoSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_GenerosMusicais_GeneroMusicalId",
                table: "Eventos");

            migrationBuilder.RenameColumn(
                name: "GeneroMusicalId",
                table: "Eventos",
                newName: "GeneroMusicalID");

            migrationBuilder.RenameIndex(
                name: "IX_Eventos_GeneroMusicalId",
                table: "Eventos",
                newName: "IX_Eventos_GeneroMusicalID");

            migrationBuilder.AlterColumn<int>(
                name: "GeneroMusicalID",
                table: "Eventos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_GenerosMusicais_GeneroMusicalID",
                table: "Eventos",
                column: "GeneroMusicalID",
                principalTable: "GenerosMusicais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_GenerosMusicais_GeneroMusicalID",
                table: "Eventos");

            migrationBuilder.RenameColumn(
                name: "GeneroMusicalID",
                table: "Eventos",
                newName: "GeneroMusicalId");

            migrationBuilder.RenameIndex(
                name: "IX_Eventos_GeneroMusicalID",
                table: "Eventos",
                newName: "IX_Eventos_GeneroMusicalId");

            migrationBuilder.AlterColumn<int>(
                name: "GeneroMusicalId",
                table: "Eventos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_GenerosMusicais_GeneroMusicalId",
                table: "Eventos",
                column: "GeneroMusicalId",
                principalTable: "GenerosMusicais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
