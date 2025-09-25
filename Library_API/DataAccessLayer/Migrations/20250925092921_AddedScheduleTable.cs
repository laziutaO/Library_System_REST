using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedScheduleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LibrarySchedules_LibraryId",
                table: "LibrarySchedules");

            migrationBuilder.CreateIndex(
                name: "IX_LibrarySchedules_LibraryId_DayOfWeek",
                table: "LibrarySchedules",
                columns: new[] { "LibraryId", "DayOfWeek" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LibrarySchedules_LibraryId_DayOfWeek",
                table: "LibrarySchedules");

            migrationBuilder.CreateIndex(
                name: "IX_LibrarySchedules_LibraryId",
                table: "LibrarySchedules",
                column: "LibraryId");
        }
    }
}
