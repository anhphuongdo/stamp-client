using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIT_STAMP.Data.Migrations
{
    public partial class Proofs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FanpageImg",
                table: "OfflineVoting");

            migrationBuilder.DropColumn(
                name: "StoryImg",
                table: "OfflineVoting");

            migrationBuilder.CreateTable(
                name: "Proofs",
                columns: table => new
                {
                    ProofId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoteId = table.Column<int>(type: "int", nullable: false),
                    FanpageImg = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    StoryImg = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proofs", x => x.ProofId);
                    table.ForeignKey(
                        name: "FK_Proofs_OfflineVoting_VoteId",
                        column: x => x.VoteId,
                        principalTable: "OfflineVoting",
                        principalColumn: "VoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proofs_VoteId",
                table: "Proofs",
                column: "VoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proofs");

            migrationBuilder.AddColumn<byte[]>(
                name: "FanpageImg",
                table: "OfflineVoting",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "StoryImg",
                table: "OfflineVoting",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
