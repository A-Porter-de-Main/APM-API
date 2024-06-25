using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APMApi.Migrations
{
    /// <inheritdoc />
    public partial class removedFloorOnAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PictureRequest");

            migrationBuilder.DropColumn(
                name: "floor",
                table: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "RequestId",
                table: "Pictures",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_RequestId",
                table: "Pictures",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Requests_RequestId",
                table: "Pictures",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Requests_RequestId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_RequestId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Pictures");

            migrationBuilder.AddColumn<string>(
                name: "floor",
                table: "Addresses",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PictureRequest",
                columns: table => new
                {
                    PicturesId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureRequest", x => new { x.PicturesId, x.RequestsId });
                    table.ForeignKey(
                        name: "FK_PictureRequest_Pictures_PicturesId",
                        column: x => x.PicturesId,
                        principalTable: "Pictures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PictureRequest_Requests_RequestsId",
                        column: x => x.RequestsId,
                        principalTable: "Requests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PictureRequest_RequestsId",
                table: "PictureRequest",
                column: "RequestsId");
        }
    }
}
