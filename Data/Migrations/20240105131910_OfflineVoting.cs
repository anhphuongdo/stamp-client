using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIT_STAMP.Data.Migrations
{
    public partial class OfflineVoting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfflineVoting",
                columns: table => new
                {
                    VoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FanpageImg = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    StoryImg = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfflineVoting", x => x.VoteId);
                    table.ForeignKey(
                        name: "FK_OfflineVoting_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfflineVoting_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfflineVoting_ProductId",
                table: "OfflineVoting",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OfflineVoting_UserId",
                table: "OfflineVoting",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfflineVoting");
        }
    }
}
