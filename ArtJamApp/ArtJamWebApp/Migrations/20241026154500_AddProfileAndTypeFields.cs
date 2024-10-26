using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtJamWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileAndTypeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistProfiles_IdentityUser_UserId",
                table: "ArtistProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicianProfiles_IdentityUser_UserId",
                table: "MusicianProfiles");

            migrationBuilder.DropIndex(
                name: "IX_MusicianProfiles_UserId",
                table: "MusicianProfiles");

            migrationBuilder.DropIndex(
                name: "IX_ArtistProfiles_UserId",
                table: "ArtistProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "MusicianProfiles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "IsMusician",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ArtistProfiles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianProfiles_UserId",
                table: "MusicianProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArtistProfiles_UserId",
                table: "ArtistProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistProfiles_AspNetUsers_UserId",
                table: "ArtistProfiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicianProfiles_AspNetUsers_UserId",
                table: "MusicianProfiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistProfiles_AspNetUsers_UserId",
                table: "ArtistProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicianProfiles_AspNetUsers_UserId",
                table: "MusicianProfiles");

            migrationBuilder.DropIndex(
                name: "IX_MusicianProfiles_UserId",
                table: "MusicianProfiles");

            migrationBuilder.DropIndex(
                name: "IX_ArtistProfiles_UserId",
                table: "ArtistProfiles");

            migrationBuilder.DropColumn(
                name: "IsMusician",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MusicianProfiles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ArtistProfiles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianProfiles_UserId",
                table: "MusicianProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistProfiles_UserId",
                table: "ArtistProfiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistProfiles_IdentityUser_UserId",
                table: "ArtistProfiles",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicianProfiles_IdentityUser_UserId",
                table: "MusicianProfiles",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
