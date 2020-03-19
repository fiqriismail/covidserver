using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceAPI.Migrations
{
    public partial class RemovedStaticHospitalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_HospitalStats_HospitalDataId",
                table: "Dashboards");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalStats_Hospitals_HospitalId",
                table: "HospitalStats");

            migrationBuilder.DropIndex(
                name: "IX_HospitalStats_HospitalId",
                table: "HospitalStats");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_HospitalDataId",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "HospitalDataId",
                table: "Dashboards");

            migrationBuilder.AddColumn<int>(
                name: "DashboardId",
                table: "HospitalStats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HospitalStats_DashboardId",
                table: "HospitalStats",
                column: "DashboardId");

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalStats_Dashboards_DashboardId",
                table: "HospitalStats",
                column: "DashboardId",
                principalTable: "Dashboards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalStats_Dashboards_DashboardId",
                table: "HospitalStats");

            migrationBuilder.DropIndex(
                name: "IX_HospitalStats_DashboardId",
                table: "HospitalStats");

            migrationBuilder.DropColumn(
                name: "DashboardId",
                table: "HospitalStats");

            migrationBuilder.AddColumn<int>(
                name: "HospitalDataId",
                table: "Dashboards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HospitalStats_HospitalId",
                table: "HospitalStats",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_HospitalDataId",
                table: "Dashboards",
                column: "HospitalDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_HospitalStats_HospitalDataId",
                table: "Dashboards",
                column: "HospitalDataId",
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
    }
}
