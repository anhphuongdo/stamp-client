using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIT_STAMP.Data.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.RenameColumn(
                name: "UsImgUrl",
                table: "User",
                newName: "FullName");

            migrationBuilder.AddColumn<int>(
                name: "STT",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageUrl",
                table: "News",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Group_User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "STT",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Group_User");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "User",
                newName: "UsImgUrl");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageUrl",
                table: "News",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });
        }
    }
}
