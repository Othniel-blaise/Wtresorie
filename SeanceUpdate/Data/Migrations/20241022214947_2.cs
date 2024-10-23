using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeanceUpdate.Data.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompteDetresoG10",
                columns: table => new
                {
                    CptNumero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CptDesignation = table.Column<string>(type: "Varchar(50)", maxLength: 255, nullable: false),
                    CptDescription = table.Column<string>(type: "Varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompteDetresoG10", x => x.CptNumero);
                });

            migrationBuilder.CreateTable(
                name: "NatureG10",
                columns: table => new
                {
                    NatCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NatDesignation = table.Column<string>(type: "Varchar(50)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatureG10", x => x.NatCode);
                });

            migrationBuilder.CreateTable(
                name: "OrdonateurG10",
                columns: table => new
                {
                    OrdCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdNom = table.Column<string>(type: "Varchar(50)", maxLength: 255, nullable: false),
                    OrdPrenom = table.Column<string>(type: "Varchar(50)", maxLength: 255, nullable: false),
                    OrdFonction = table.Column<string>(type: "Varchar(50)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdonateurG10", x => x.OrdCode);
                });

            migrationBuilder.CreateTable(
                name: "OperationG10",
                columns: table => new
                {
                    OperRef = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperDate = table.Column<DateTime>(type: "Date", nullable: false),
                    OperLibelle = table.Column<string>(type: "Varchar(255)", nullable: false),
                    OperMontDebit = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    OperMontCredit = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    OperSolde = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    OperBeneficiaire = table.Column<string>(type: "Varchar(255)", nullable: false),
                    OperExecutant = table.Column<string>(type: "Varchar(255)", nullable: false),
                    OperObserva = table.Column<string>(type: "Varchar(255)", nullable: false),
                    NatCode = table.Column<int>(type: "int", nullable: false),
                    CptNumero = table.Column<int>(type: "int", nullable: false),
                    OrdCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationG10", x => x.OperRef);
                    table.ForeignKey(
                        name: "FK_OperationG10_CompteDetresoG10_CptNumero",
                        column: x => x.CptNumero,
                        principalTable: "CompteDetresoG10",
                        principalColumn: "CptNumero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationG10_NatureG10_NatCode",
                        column: x => x.NatCode,
                        principalTable: "NatureG10",
                        principalColumn: "NatCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationG10_OrdonateurG10_OrdCode",
                        column: x => x.OrdCode,
                        principalTable: "OrdonateurG10",
                        principalColumn: "OrdCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationG10_CptNumero",
                table: "OperationG10",
                column: "CptNumero");

            migrationBuilder.CreateIndex(
                name: "IX_OperationG10_NatCode",
                table: "OperationG10",
                column: "NatCode");

            migrationBuilder.CreateIndex(
                name: "IX_OperationG10_OrdCode",
                table: "OperationG10",
                column: "OrdCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationG10");

            migrationBuilder.DropTable(
                name: "CompteDetresoG10");

            migrationBuilder.DropTable(
                name: "NatureG10");

            migrationBuilder.DropTable(
                name: "OrdonateurG10");
        }
    }
}
