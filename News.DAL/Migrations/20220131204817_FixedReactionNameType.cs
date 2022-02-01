using Microsoft.EntityFrameworkCore.Migrations;

namespace News.DAL.Migrations
{
    public partial class FixedReactionNameType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Reaction",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Reaction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

        }
    }
}
