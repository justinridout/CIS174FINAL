using Microsoft.EntityFrameworkCore.Migrations;

namespace CIS174_TestCoreApp.Migrations
{
    public partial class AddedWorkoutNameAndTargetedMuscleGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TargetedMuscleGroup",
                table: "WorkoutSummary",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExerciseName",
                table: "WorkoutDetailed",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetedMuscleGroup",
                table: "WorkoutSummary");

            migrationBuilder.DropColumn(
                name: "ExerciseName",
                table: "WorkoutDetailed");
        }
    }
}
