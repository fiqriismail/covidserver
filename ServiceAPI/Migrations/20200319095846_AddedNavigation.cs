using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceAPI.Migrations
{
    public partial class AddedNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HospitalStatId",
                table: "Dashboards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HospitalStats_HospitalId",
                table: "HospitalStats",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_HospitalStatId",
                table: "Dashboards",
                column: "HospitalStatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_HospitalStats_HospitalStatId",
                table: "Dashboards",
                column: "HospitalStatId",
                principalTable: "HospitalStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalStats_Hospitals_HospitalId",
                table: "HospitalStats",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_HospitalStats_HospitalStatId",
                table: "Dashboards");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalStats_Hospitals_HospitalId",
                table: "HospitalStats");

            migrationBuilder.DropIndex(
                name: "IX_HospitalStats_HospitalId",
                table: "HospitalStats");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_HospitalStatId",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "HospitalStatId",
                table: "Dashboards");
        }
    }
}
