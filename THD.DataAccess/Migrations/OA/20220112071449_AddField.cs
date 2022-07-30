using Microsoft.EntityFrameworkCore.Migrations;

namespace THD.DataAccess.Migrations.OA
{
    public partial class AddField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GSCZ",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GSDH",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GSDZ",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GSMC",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GSYX",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GSCZ",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GSDH",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GSDZ",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GSMC",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GSYX",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Users");
        }
    }
}
