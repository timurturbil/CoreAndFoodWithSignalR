using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAndFood.Migrations
{
    public partial class deneme1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "ThumbNailImageURL",
                table: "Foods",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Foods",
                newName: "ThumbNailImageURL");

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
