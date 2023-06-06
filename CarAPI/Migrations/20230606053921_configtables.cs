using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAPI.Migrations
{
    public partial class configtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "VarChar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVarChar");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "NText",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVarChar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "NVarChar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "NVarChar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NText");
        }
    }
}
