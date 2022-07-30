using Microsoft.EntityFrameworkCore.Migrations;

namespace THD.DataAccess.Migrations.App
{
    public partial class AddItListInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItListInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Period = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Area = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Price = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Language = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Characteristics = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Human = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Commitment = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Others = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    user = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    update = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItListInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItListInfos");
        }
    }
}
