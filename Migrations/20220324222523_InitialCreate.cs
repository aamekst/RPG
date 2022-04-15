using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pontosvida = table.Column<int>(type: "int", nullable: false),
                    Forca = table.Column<int>(type: "int", nullable: false),
                    Defesa = table.Column<int>(type: "int", nullable: false),
                    Inteligencia = table.Column<int>(type: "int", nullable: false),
                    Classe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personagens", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "personagens",
                columns: new[] { "Id", "Classe", "Defesa", "Forca", "Inteligencia", "Nome", "Pontosvida" },
                values: new object[,]
                {
                    { 1, 1, 23, 17, 33, "Nathaniel", 100 },
                    { 2, 1, 25, 15, 30, "Maddy", 100 },
                    { 3, 3, 21, 18, 35, "Cinzeiro", 100 },
                    { 4, 2, 18, 18, 37, "Cass", 100 },
                    { 5, 1, 17, 20, 31, "Rue", 100 },
                    { 6, 3, 13, 21, 34, "Lexi", 100 },
                    { 7, 2, 11, 25, 35, "Fez", 100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personagens");
        }
    }
}
