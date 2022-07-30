using Microsoft.EntityFrameworkCore.Migrations;

namespace THD.DataAccess.Migrations.App
{
    public partial class CreatePickupAndGuideAndPlay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Tours",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Stays",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Foods",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "Guides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PriceNew = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Info = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
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
                    Img1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img3 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img4 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img5 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img6 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img7 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img8 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img9 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img10 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Datein = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pid = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Map = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Video = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pickups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PriceNew = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Info = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
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
                    Img1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img3 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img4 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img5 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img6 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img7 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img8 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img9 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img10 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Datein = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pid = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Map = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Video = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Featrues = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pickups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VolumeRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Traffic = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HomeLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Img1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img3 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img4 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img5 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img6 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img7 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img8 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img9 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img10 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img11 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img12 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img13 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img14 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img15 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img16 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img17 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img18 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img19 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Img20 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Map = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReleaseDate = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Pid = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
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
                    PriceNew = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Supplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plays", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guides");

            migrationBuilder.DropTable(
                name: "Pickups");

            migrationBuilder.DropTable(
                name: "Plays");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Tours",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Tickets",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Stays",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Foods",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
