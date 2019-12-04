using Microsoft.EntityFrameworkCore.Migrations;

namespace CIS174_TestCoreApp.Migrations
{
    public partial class AddedIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "WorkoutSummary",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDetailed_WorkoutId",
                table: "WorkoutDetailed",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutDetailed_WorkoutSummary_WorkoutId",
                table: "WorkoutDetailed",
                column: "WorkoutId",
                principalTable: "WorkoutSummary",
                principalColumn: "WorkoutId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutDetailed_WorkoutSummary_WorkoutId",
                table: "WorkoutDetailed");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutDetailed_WorkoutId",
                table: "WorkoutDetailed");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "WorkoutSummary");
        }
    }
}
