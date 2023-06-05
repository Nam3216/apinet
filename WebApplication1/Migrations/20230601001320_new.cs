using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ModelClasses",
                columns: new[] { "id", "description", "img", "name", "price", "quantity" },
                values: new object[,]
                {
                    { 1, "first casa", "https://www.puntodebreak.com/files/styles/eht/public/medvedev-prensa-seyboth-wild.jpg?itok=l74U9Mki", "casa1", 0, 0 },
                    { 2, "secon casa", "https://www.elgrafico.com.ar/media/cache/pub_news_details_large/media/i/c7/93/c793620737acdccd2d5b00b4d0f0483f613b22b6.jpg", "casa2", 0, 0 },
                    { 3, "third casa", "https://imgresizer.eurosport.com/unsafe/1200x0/filters:format(webp):focal(1312x271:1314x269)/origin-imgresizer.eurosport.com/2023/03/22/3667442-74657768-2560-1440.jpg", "casa3", 0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModelClasses",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ModelClasses",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ModelClasses",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
