using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IleriWebProje.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlatformId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mentors_Skills_Mentors_MentorID",
                table: "Mentors_Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Platforms_PlatformID",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "PlatformID",
                table: "Skills",
                newName: "PlatformId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_PlatformID",
                table: "Skills",
                newName: "IX_Skills_PlatformId");

            migrationBuilder.RenameColumn(
                name: "SkillOrganizerID",
                table: "Skill_Organizers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PlatformID",
                table: "Platforms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MentorID",
                table: "Mentors_Skills",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MentorID",
                table: "Mentors",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Skill_Organizers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Mentors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Mentors_Skills_Mentors_Id",
                table: "Mentors_Skills",
                column: "Id",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Platforms_PlatformId",
                table: "Skills",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mentors_Skills_Mentors_Id",
                table: "Mentors_Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Platforms_PlatformId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "PlatformId",
                table: "Skills",
                newName: "PlatformID");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_PlatformId",
                table: "Skills",
                newName: "IX_Skills_PlatformID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Skill_Organizers",
                newName: "SkillOrganizerID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Platforms",
                newName: "PlatformID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Mentors_Skills",
                newName: "MentorID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Mentors",
                newName: "MentorID");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Skill_Organizers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Mentors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Mentors_Skills_Mentors_MentorID",
                table: "Mentors_Skills",
                column: "MentorID",
                principalTable: "Mentors",
                principalColumn: "MentorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Platforms_PlatformID",
                table: "Skills",
                column: "PlatformID",
                principalTable: "Platforms",
                principalColumn: "PlatformID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
