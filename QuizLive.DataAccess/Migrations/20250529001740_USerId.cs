using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizLive.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class USerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_AspNetUsers_AppUserId1",
                table: "ExamResults");

            migrationBuilder.DropIndex(
                name: "IX_ExamResults_AppUserId1",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "ExamResults");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "ExamResults",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_AppUserId",
                table: "ExamResults",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_AspNetUsers_AppUserId",
                table: "ExamResults",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_AspNetUsers_AppUserId",
                table: "ExamResults");

            migrationBuilder.DropIndex(
                name: "IX_ExamResults_AppUserId",
                table: "ExamResults");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "ExamResults",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId1",
                table: "ExamResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_AppUserId1",
                table: "ExamResults",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_AspNetUsers_AppUserId1",
                table: "ExamResults",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
