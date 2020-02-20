using Microsoft.EntityFrameworkCore.Migrations;

namespace GFT_Tickets.Migrations
{
    public partial class AtualizandoVendasSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Eventos_EventoId",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "EventoId",
                table: "Vendas",
                newName: "EventoID");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_EventoId",
                table: "Vendas",
                newName: "IX_Vendas_EventoID");

            migrationBuilder.AlterColumn<int>(
                name: "EventoID",
                table: "Vendas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Eventos_EventoID",
                table: "Vendas",
                column: "EventoID",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Eventos_EventoID",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "EventoID",
                table: "Vendas",
                newName: "EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_EventoID",
                table: "Vendas",
                newName: "IX_Vendas_EventoId");

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "Vendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Eventos_EventoId",
                table: "Vendas",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
