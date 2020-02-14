using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GFT_Tickets.Migrations
{
    public partial class CreateGftTicketsSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CasasDeShow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasasDeShow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenerosMusicais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Imagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenerosMusicais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Capacidade = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    ValorUnitario = table.Column<float>(nullable: false),
                    CasaDeShowId = table.Column<int>(nullable: true),
                    GeneroMusicalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_CasasDeShow_CasaDeShowId",
                        column: x => x.CasaDeShowId,
                        principalTable: "CasasDeShow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventos_GenerosMusicais_GeneroMusicalId",
                        column: x => x.GeneroMusicalId,
                        principalTable: "GenerosMusicais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    EventoId = table.Column<int>(nullable: true),
                    QuantidadeTicket = table.Column<int>(nullable: false),
                    TotalVenda = table.Column<float>(nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_CasaDeShowId",
                table: "Eventos",
                column: "CasaDeShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_GeneroMusicalId",
                table: "Eventos",
                column: "GeneroMusicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_EventoId",
                table: "Vendas",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_UsuarioId",
                table: "Vendas",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "CasasDeShow");

            migrationBuilder.DropTable(
                name: "GenerosMusicais");
        }
    }
}
