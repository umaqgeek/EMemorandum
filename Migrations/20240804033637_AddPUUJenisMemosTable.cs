﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMemorandum.Migrations
{
    public partial class AddPUUJenisMemosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PUU_JenisMemos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Butiran = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodPejabat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pejabat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PUU_JenisMemos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PUU_JenisMemos");
        }
    }
}