using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduMart.Migrations
{
    /// <inheritdoc />
    public partial class Order_And_OrderItem_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mentors_Skills_Mentors_Id",
                table: "Mentors_Skills");

            migrationBuilder.RenameColumn(
                name: "SkillID",
                table: "Skills",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Mentors_Skills",
                newName: "MentorID");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_SkillId",
                table: "OrderItems",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mentors_Skills_Mentors_MentorID",
                table: "Mentors_Skills",
                column: "MentorID",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mentors_Skills_Mentors_MentorID",
                table: "Mentors_Skills");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Skills",
                newName: "SkillID");

            migrationBuilder.RenameColumn(
                name: "MentorID",
                table: "Mentors_Skills",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mentors_Skills_Mentors_Id",
                table: "Mentors_Skills",
                column: "Id",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
