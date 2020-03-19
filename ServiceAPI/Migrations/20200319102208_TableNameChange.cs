using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceAPI.Migrations
{
    public partial class TableNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_HospitalStats_HospitalStatId",
                table: "Dashboards");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_HospitalStatId",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "HospitalStatId",
                table: "Dashboards");

            migrationBuilder.AddColumn<int>(
                name: "HospitalDataId",
                table: "Dashboards",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_HospitalStats_HospitalDataId",
                table: "Dashboards");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_HospitalDataId",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "HospitalDataId",
                table: "Dashboards");

            migrationBuilder.AddColumn<int>(
                name: "HospitalStatId",
                table: "Dashboards",
                type: "int",
                nullable: true);

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
        }
    }
}
