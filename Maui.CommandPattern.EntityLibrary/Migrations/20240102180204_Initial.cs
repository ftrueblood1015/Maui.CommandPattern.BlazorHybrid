using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Maui.CommandPattern.EntityLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MtgSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReleaseYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtgSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MtgCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    MtgSetId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtgCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MtgCards_MtgSets_MtgSetId",
                        column: x => x.MtgSetId,
                        principalTable: "MtgSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MtgSets",
                columns: new[] { "Id", "Description", "IsActive", "Name", "ReleaseYear" },
                values: new object[,]
                {
                    { 1, "Alpha", true, "Alpha", 1993 },
                    { 2, "Beta", true, "Beta", 1993 }
                });

            migrationBuilder.InsertData(
                table: "MtgCards",
                columns: new[] { "Id", "Color", "Description", "IsActive", "MtgSetId", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "None", "Black Lotus", true, 1, "Black Lotus", "Artifact" },
                    { 2, "None", "Black Lotus", true, 2, "Black Lotus", "Artifact" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MtgCards_MtgSetId",
                table: "MtgCards",
                column: "MtgSetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MtgCards");

            migrationBuilder.DropTable(
                name: "MtgSets");
        }
    }
}
