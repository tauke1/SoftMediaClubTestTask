using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoftMediaClubTestTask.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicPerformanceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicPerformanceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Firstname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Lastname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Middlename = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AcademicPerformanceTypeId = table.Column<int>(type: "integer", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AcademicPerformanceTypes_AcademicPerformanceTypeId",
                        column: x => x.AcademicPerformanceTypeId,
                        principalTable: "AcademicPerformanceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AcademicPerformanceTypes",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "A", "Отлично" },
                    { 2, "B", "Хорошо" },
                    { 3, "С", "Удовлетворительно" },
                    { 4, "D", "Неудовлетворительно" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPerformanceTypes_Code",
                table: "AcademicPerformanceTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AcademicPerformanceTypeId",
                table: "Students",
                column: "AcademicPerformanceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AcademicPerformanceTypes");
        }
    }
}
