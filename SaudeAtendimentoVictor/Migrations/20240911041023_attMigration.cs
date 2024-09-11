using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaudeAtendimentoVictor.Migrations
{
    public partial class attMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroSequencial = table.Column<int>(type: "int", nullable: false),
                    PacienteID = table.Column<int>(type: "int", nullable: false),
                    DataHoraChegada = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimento_Paciente_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendimento_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Triagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtendimentoID = table.Column<int>(type: "int", nullable: false),
                    Sintomas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PressaoArterial = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Peso = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Altura = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    EspecialidadeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Triagem_Atendimento_AtendimentoID",
                        column: x => x.AtendimentoID,
                        principalTable: "Atendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Triagem_Especialidade_EspecialidadeID",
                        column: x => x.EspecialidadeID,
                        principalTable: "Especialidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_PacienteID",
                table: "Atendimento",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_StatusID",
                table: "Atendimento",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Triagem_AtendimentoID",
                table: "Triagem",
                column: "AtendimentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Triagem_EspecialidadeID",
                table: "Triagem",
                column: "EspecialidadeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Triagem");

            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropTable(
                name: "Especialidade");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
