using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APMApi.Migrations
{
    /// <inheritdoc />
    public partial class changedImageIntegration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectCategories_Pictures_picture_id",
                table: "ObjectCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Objects_Pictures_picture_id",
                table: "Objects");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Pictures_picture_id",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Pictures_picture_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_picture_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Skills_picture_id",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Objects_picture_id",
                table: "Objects");

            migrationBuilder.DropIndex(
                name: "IX_ObjectCategories_picture_id",
                table: "ObjectCategories");

            migrationBuilder.DropColumn(
                name: "picture_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "picture_id",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "picture_id",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "picture_id",
                table: "ObjectCategories");

            migrationBuilder.AddColumn<string>(
                name: "picture_path",
                table: "Users",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "picture_path",
                table: "Skills",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "picture_path",
                table: "Objects",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "picture_path",
                table: "ObjectCategories",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "picture_path",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "picture_path",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "picture_path",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "picture_path",
                table: "ObjectCategories");

            migrationBuilder.AddColumn<Guid>(
                name: "picture_id",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "picture_id",
                table: "Skills",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "picture_id",
                table: "Objects",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "picture_id",
                table: "ObjectCategories",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_picture_id",
                table: "Users",
                column: "picture_id");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_picture_id",
                table: "Skills",
                column: "picture_id");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_picture_id",
                table: "Objects",
                column: "picture_id");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectCategories_picture_id",
                table: "ObjectCategories",
                column: "picture_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectCategories_Pictures_picture_id",
                table: "ObjectCategories",
                column: "picture_id",
                principalTable: "Pictures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_Pictures_picture_id",
                table: "Objects",
                column: "picture_id",
                principalTable: "Pictures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Pictures_picture_id",
                table: "Skills",
                column: "picture_id",
                principalTable: "Pictures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Pictures_picture_id",
                table: "Users",
                column: "picture_id",
                principalTable: "Pictures",
                principalColumn: "id");
        }
    }
}
