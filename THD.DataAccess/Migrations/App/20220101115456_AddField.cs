using Microsoft.EntityFrameworkCore.Migrations;

namespace THD.DataAccess.Migrations.App
{
    public partial class AddField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Tours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Stays",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Foods",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Stays");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Foods");
        }
    }
}
