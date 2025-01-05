using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Projeto_Thayssa.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beneficio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_beneficio = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    percentual = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contribuinte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RazaoSocial = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "date", nullable: false),
                    RegimeTributacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuinte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContribuinteBeneficio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContribuinteId = table.Column<int>(type: "integer", nullable: false),
                    BeneficioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContribuinteBeneficio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContribuinteBeneficio_Beneficio_BeneficioId",
                        column: x => x.BeneficioId,
                        principalTable: "Beneficio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContribuinteBeneficio_Contribuinte_ContribuinteId",
                        column: x => x.ContribuinteId,
                        principalTable: "Contribuinte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContribuinteBeneficio_BeneficioId",
                table: "ContribuinteBeneficio",
                column: "BeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_ContribuinteBeneficio_ContribuinteId",
                table: "ContribuinteBeneficio",
                column: "ContribuinteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContribuinteBeneficio");

            migrationBuilder.DropTable(
                name: "Beneficio");

            migrationBuilder.DropTable(
                name: "Contribuinte");
        }
    }
}
