using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIT_STAMP.Data.Migrations
{
    public partial class UpdateUs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "UsImgUrl",
                table: "User",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsImgUrl",
                table: "User");
        }
    }
}
