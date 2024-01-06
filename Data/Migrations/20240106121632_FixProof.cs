using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIT_STAMP.Data.Migrations
{
    public partial class FixProof : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfflineVoting_User_UserId",
                table: "OfflineVoting");

            migrationBuilder.DropForeignKey(
                name: "FK_Proofs_OfflineVoting_VoteId",
                table: "Proofs");

            migrationBuilder.DropIndex(
                name: "IX_Proofs_VoteId",
                table: "Proofs");

            migrationBuilder.DropIndex(
                name: "IX_OfflineVoting_UserId",
                table: "OfflineVoting");

            migrationBuilder.DropColumn(
                name: "VoteId",
                table: "Proofs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OfflineVoting");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Proofs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProofId",
                table: "OfflineVoting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Proofs_UserId",
                table: "Proofs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfflineVoting_ProofId",
                table: "OfflineVoting",
                column: "ProofId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfflineVoting_Proofs_ProofId",
                table: "OfflineVoting",
                column: "ProofId",
                principalTable: "Proofs",
                principalColumn: "ProofId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proofs_User_UserId",
                table: "Proofs",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfflineVoting_Proofs_ProofId",
                table: "OfflineVoting");

            migrationBuilder.DropForeignKey(
                name: "FK_Proofs_User_UserId",
                table: "Proofs");

            migrationBuilder.DropIndex(
                name: "IX_Proofs_UserId",
                table: "Proofs");

            migrationBuilder.DropIndex(
                name: "IX_OfflineVoting_ProofId",
                table: "OfflineVoting");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Proofs");

            migrationBuilder.DropColumn(
                name: "ProofId",
                table: "OfflineVoting");

            migrationBuilder.AddColumn<int>(
                name: "VoteId",
                table: "Proofs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OfflineVoting",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Proofs_VoteId",
                table: "Proofs",
                column: "VoteId");

            migrationBuilder.CreateIndex(
                name: "IX_OfflineVoting_UserId",
                table: "OfflineVoting",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfflineVoting_User_UserId",
                table: "OfflineVoting",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proofs_OfflineVoting_VoteId",
                table: "Proofs",
                column: "VoteId",
                principalTable: "OfflineVoting",
                principalColumn: "VoteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
