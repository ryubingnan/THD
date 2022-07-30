using Microsoft.EntityFrameworkCore.Migrations;

namespace THD.DataAccess.Migrations
{
    public partial class CreateTour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Days = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img4 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img5 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img6 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img7 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img8 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img9 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img10 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img11 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img12 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img13 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img14 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img15 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img16 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img17 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img18 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img19 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Img20 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Info1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info3 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info4 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info5 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info6 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info7 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info8 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info9 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info10 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info11 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info12 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info13 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info14 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info15 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info16 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info17 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info18 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info19 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Info20 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Map = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Video = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ReleaseDate = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Pid = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StartPlace = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Day1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day7 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day8 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day9 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day10 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day11 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day12 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day13 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day14 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day15 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day16 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day17 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day18 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day19 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Day20 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    PriceNew = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
