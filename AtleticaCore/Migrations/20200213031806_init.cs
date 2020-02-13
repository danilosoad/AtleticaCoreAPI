using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtleticaCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOGIN = table.Column<string>(nullable: true),
                    ACTION = table.Column<string>(nullable: true),
                    DATAHORA = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    EMAIL = table.Column<string>(nullable: true),
                    APROVADO = table.Column<bool>(nullable: false),
                    LOGIN = table.Column<string>(nullable: true),
                    SENHA = table.Column<string>(nullable: true),
                    SALT = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "ID", "APROVADO", "CPF", "EMAIL", "LOGIN", "NOME", "SALT", "SENHA" },
                values: new object[,]
                {
                    { 1, false, null, "danilo@gmail.com", null, "DANILO", null, null },
                    { 2, false, null, "bibi@gmail.com", null, "BIBI", null, null },
                    { 3, false, null, "bibi@gmail.com", null, "CARLOS", null, null },
                    { 4, false, null, "bibi@gmail.com", null, "JOELTON", null, null },
                    { 5, false, null, "bibi@gmail.com", null, "GIL BROTHER", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
