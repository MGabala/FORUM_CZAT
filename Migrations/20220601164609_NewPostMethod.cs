using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FORUM_CZAT.Migrations
{
    public partial class NewPostMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.CreateTable(
                name: "NewPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Astronomy = table.Column<string>(type: "TEXT", nullable: false),
                    CryptoCurrencies = table.Column<string>(type: "TEXT", nullable: false),
                    Life = table.Column<string>(type: "TEXT", nullable: false),
                    Mathematic = table.Column<string>(type: "TEXT", nullable: false),
                    Programming = table.Column<string>(type: "TEXT", nullable: false),
                    Psychology = table.Column<string>(type: "TEXT", nullable: false),
                    Reading = table.Column<string>(type: "TEXT", nullable: false),
                    Religion = table.Column<string>(type: "TEXT", nullable: false),
                    Science = table.Column<string>(type: "TEXT", nullable: false),
                    SciFi = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewPosts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewPosts");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });
        }
    }
}
