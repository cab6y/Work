using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Work.Migrations
{
    public partial class PlaysAdultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "PlaysAdultRoles",
                table: "ExtrasAbout",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PlaysAdultRoles",
                table: "ExtrasAbout",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }
    }
}
