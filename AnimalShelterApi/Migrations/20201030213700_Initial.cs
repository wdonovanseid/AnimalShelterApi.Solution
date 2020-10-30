using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelterApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    CatId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CatName = table.Column<string>(maxLength: 20, nullable: false),
                    CatBreed = table.Column<string>(nullable: false),
                    CatAge = table.Column<int>(nullable: false),
                    CatDetails = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    DogId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DogName = table.Column<string>(maxLength: 20, nullable: false),
                    DogBreed = table.Column<string>(nullable: false),
                    DogAge = table.Column<int>(nullable: false),
                    DogDetails = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.DogId);
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatId", "CatAge", "CatBreed", "CatDetails", "CatName" },
                values: new object[,]
                {
                    { 1, 3, "Persian", "Likes knocking things over", "Snowball" },
                    { 2, 6, "American", "Really Likes knocking things over", "Baseball" },
                    { 3, 9, "Persian", "Super Likes knocking things over", "Football" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "DogId", "DogAge", "DogBreed", "DogDetails", "DogName" },
                values: new object[,]
                {
                    { 1, 2, "Pitbull", "Chases own shadow", "Sam" },
                    { 2, 1, "Pitbull", "Chases own shadow sometimes", "Sammy" },
                    { 3, 20, "Pitbull", "Chases own shadow all the time", "Sammuel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Dogs");
        }
    }
}
