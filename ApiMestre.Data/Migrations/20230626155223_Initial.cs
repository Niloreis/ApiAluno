using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMestre.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "METRE",
                columns: table => new
                {
                    IDMESTRE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMIAL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FAIXA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DATANASCIMENTO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_METRE", x => x.IDMESTRE);
                });

            migrationBuilder.CreateTable(
                name: "ALUNO",
                columns: table => new
                {
                    IDALUNO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FAIXA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DATANASCIMENTO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDMESTRE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDPRESECA = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUNO", x => x.IDALUNO);
                    table.ForeignKey(
                        name: "FK_ALUNO_METRE_IDMESTRE",
                        column: x => x.IDMESTRE,
                        principalTable: "METRE",
                        principalColumn: "IDMESTRE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRESENCA",
                columns: table => new
                {
                    IDPRESNCA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PRESENCAS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA_DE_HOJE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDALUNO = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRESENCA", x => x.IDPRESNCA);
                    table.ForeignKey(
                        name: "FK_PRESENCA_ALUNO_IDALUNO",
                        column: x => x.IDALUNO,
                        principalTable: "ALUNO",
                        principalColumn: "IDALUNO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALUNO_IDMESTRE",
                table: "ALUNO",
                column: "IDMESTRE");

            migrationBuilder.CreateIndex(
                name: "IX_PRESENCA_IDALUNO",
                table: "PRESENCA",
                column: "IDALUNO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRESENCA");

            migrationBuilder.DropTable(
                name: "ALUNO");

            migrationBuilder.DropTable(
                name: "METRE");
        }
    }
}
