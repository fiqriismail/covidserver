using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dashboards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedDateTime = table.Column<DateTime>(nullable: false),
                    LocalNewCases = table.Column<int>(nullable: false),
                    LocalTotalCases = table.Column<int>(nullable: false),
                    LocalDeaths = table.Column<int>(nullable: false),
                    LocalNewDeaths = table.Column<int>(nullable: false),
                    LocalRecovered = table.Column<int>(nullable: false),
                    GlobalNewCases = table.Column<int>(nullable: false),
                    GlobalTotalCases = table.Column<int>(nullable: false),
                    GlobalDeaths = table.Column<int>(nullable: false),
                    GlobalNewDeaths = table.Column<int>(nullable: false),
                    GlobalRecovered = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalStats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalId = table.Column<int>(nullable: false),
                    CumulativeLocal = table.Column<int>(nullable: false),
                    CumulativeForeign = table.Column<int>(nullable: false),
                    TreatmentLocal = table.Column<int>(nullable: false),
                    TreatmentForeign = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CumulativeTotal = table.Column<int>(nullable: false),
                    TreatmentTotal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalStats", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "National Institute of Infectious Diseases" },
                    { 15, "DMH" },
                    { 14, "LRH" },
                    { 13, "PGH – Badulla" },
                    { 12, "TH – Rathnapura" },
                    { 11, "DGH – Negombo" },
                    { 10, "DGH- Gampaha" },
                    { 16, "DGH – Polonnaruwa" },
                    { 9, "TH – Batticaloa" },
                    { 7, "TH- Jaffna" },
                    { 6, "TH - Kurunegala" },
                    { 5, "TH - Anuradhapura" },
                    { 4, "TH - Karapitiya" },
                    { 3, "TH - Ragama" },
                    { 2, "National Hospital Sri Lanka" },
                    { 8, "National Hospital Kandy" },
                    { 17, "TH - Kalubowila" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dashboards");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "HospitalStats");
        }
    }
}
