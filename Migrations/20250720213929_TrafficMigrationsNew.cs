using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Traffic_Control_System.Migrations
{
    public partial class TrafficMigrationsNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Violations_LaneId",
                table: "Violations",
                column: "LaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Violations_Lanes_LaneId",
                table: "Violations",
                column: "LaneId",
                principalTable: "Lanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Violations_Lanes_LaneId",
                table: "Violations");

            migrationBuilder.DropIndex(
                name: "IX_Violations_LaneId",
                table: "Violations");
        }
    }
}
