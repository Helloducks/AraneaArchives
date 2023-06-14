using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraneaArchives.Data.Migrations
{
    /// <inheritdoc />
    public partial class didsomeChangesInName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "NoteName",
                table: "Notes",
                newName: "NotesName");

            migrationBuilder.RenameColumn(
                name: "NoteContents",
                table: "Notes",
                newName: "NotesContents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotesName",
                table: "Notes",
                newName: "NoteName");

            migrationBuilder.RenameColumn(
                name: "NotesContents",
                table: "Notes",
                newName: "NoteContents");

            migrationBuilder.AddColumn<int>(
                name: "NoteId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
