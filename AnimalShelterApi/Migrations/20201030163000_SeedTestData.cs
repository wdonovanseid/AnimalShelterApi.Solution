using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelterApi.Migrations
{
    public partial class SeedTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatId", "CatAge", "CatBreed", "CatDetails", "CatName" },
                values: new object[,]
                {
                    { 2, 6, "American", "Really Likes knocking things over", "Baseball" },
                    { 3, 9, "Persian", "Super Likes knocking things over", "Football" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "DogId", "DogAge", "DogBreed", "DogDetails", "DogName" },
                values: new object[,]
                {
                    { 2, 1, "Pitbull", "Chases own shadow sometimes", "Sammy" },
                    { 3, 20, "Pitbull", "Chases own shadow all the time", "Sammuel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 3);
        }
    }
}
