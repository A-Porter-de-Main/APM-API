using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APMApi.Migrations
{
    /// <inheritdoc />
    public partial class addedUserToRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "Requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "password",
                value: "$2a$05$HTVZpAVlBa1pYek9iDCRoufJ8HsAOBfEjuSWWP7dh.pUtUKZTk7MK");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_user_id",
                table: "Requests",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_user_id",
                table: "Requests",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_user_id",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_user_id",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Requests");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "password",
                value: "$2a$05$Z9r3MvlliHL.pJu9NSYBn.JK0VE9NNCw7dq4n/LPFex6bkCDQe13i");
        }
    }
}
