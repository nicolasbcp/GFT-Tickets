using Microsoft.EntityFrameworkCore.Migrations;

namespace GFT_Tickets.Migrations
{
    public partial class AtualizandoEventosSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_CasasDeShow_CasaDeShowId",
                table: "Eventos");

            migrationBuilder.RenameColumn(
                name: "CasaDeShowId",
                table: "Eventos",
                newName: "CasaDeShowID");

            migrationBuilder.RenameIndex(
                name: "IX_Eventos_CasaDeShowId",
                table: "Eventos",
                newName: "IX_Eventos_CasaDeShowID");

            migrationBuilder.AlterColumn<int>(
                name: "CasaDeShowID",
                table: "Eventos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_CasasDeShow_CasaDeShowID",
                table: "Eventos",
                column: "CasaDeShowID",
                principalTable: "CasasDeShow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_CasasDeShow_CasaDeShowID",
                table: "Eventos");

            migrationBuilder.RenameColumn(
                name: "CasaDeShowID",
                table: "Eventos",
                newName: "CasaDeShowId");

            migrationBuilder.RenameIndex(
                name: "IX_Eventos_CasaDeShowID",
                table: "Eventos",
                newName: "IX_Eventos_CasaDeShowId");

            migrationBuilder.AlterColumn<int>(
                name: "CasaDeShowId",
                table: "Eventos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_CasasDeShow_CasaDeShowId",
                table: "Eventos",
                column: "CasaDeShowId",
                principalTable: "CasasDeShow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
