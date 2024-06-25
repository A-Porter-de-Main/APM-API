using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APMApi.Migrations
{
    /// <inheritdoc />
    public partial class addingRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "desciption",
                table: "Users",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Deadline",
                table: "Requests",
                newName: "deadline");

            migrationBuilder.AddColumn<Guid>(
                name: "PictureId1",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "picture_id",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "role_id",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PictureId1",
                table: "Skills",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "picture_id",
                table: "Skills",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestId1",
                table: "Responses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "response_status_id",
                table: "Responses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "status_id",
                table: "Requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "Preferences",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PictureId1",
                table: "Objects",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "category_id",
                table: "Objects",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "picture_id",
                table: "Objects",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PictureId1",
                table: "ObjectCategories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "parent_id",
                table: "ObjectCategories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "picture_id",
                table: "ObjectCategories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "Issues",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "feedbacks_application",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "feedbacks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "response_id",
                table: "Chats",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "floor",
                table: "Addresses",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "Addresses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "RequestObjects",
                columns: table => new
                {
                    ObjectsId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestObjects", x => new { x.ObjectsId, x.RequestsId });
                    table.ForeignKey(
                        name: "FK_RequestObjects_Objects_ObjectsId",
                        column: x => x.ObjectsId,
                        principalTable: "Objects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestObjects_Requests_RequestsId",
                        column: x => x.RequestsId,
                        principalTable: "Requests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestPictures",
                columns: table => new
                {
                    PicturesId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPictures", x => new { x.PicturesId, x.RequestsId });
                    table.ForeignKey(
                        name: "FK_RequestPictures_Pictures_PicturesId",
                        column: x => x.PicturesId,
                        principalTable: "Pictures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestPictures_Requests_RequestsId",
                        column: x => x.RequestsId,
                        principalTable: "Requests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestSkills",
                columns: table => new
                {
                    RequestsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSkills", x => new { x.RequestsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_RequestSkills_Requests_RequestsId",
                        column: x => x.RequestsId,
                        principalTable: "Requests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestSkills_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponseStatuses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseStatuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserObjects",
                columns: table => new
                {
                    ObjectsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserObjects", x => new { x.ObjectsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserObjects_Objects_ObjectsId",
                        column: x => x.ObjectsId,
                        principalTable: "Objects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserObjects_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    SkillsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => new { x.SkillsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserSkills_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkills_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_picture_id",
                table: "Users",
                column: "picture_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PictureId1",
                table: "Users",
                column: "PictureId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_role_id",
                table: "Users",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_picture_id",
                table: "Skills",
                column: "picture_id");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_PictureId1",
                table: "Skills",
                column: "PictureId1");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_request_id",
                table: "Responses",
                column: "request_id");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_RequestId1",
                table: "Responses",
                column: "RequestId1");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_response_status_id",
                table: "Responses",
                column: "response_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_user_id",
                table: "Responses",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_status_id",
                table: "Requests",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_user_id",
                table: "Preferences",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Objects_category_id",
                table: "Objects",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_picture_id",
                table: "Objects",
                column: "picture_id");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_PictureId1",
                table: "Objects",
                column: "PictureId1");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectCategories_parent_id",
                table: "ObjectCategories",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectCategories_picture_id",
                table: "ObjectCategories",
                column: "picture_id");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectCategories_PictureId1",
                table: "ObjectCategories",
                column: "PictureId1");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_user_id",
                table: "Issues",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_application_user_id",
                table: "feedbacks_application",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_user_id",
                table: "feedbacks",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_response_id",
                table: "Chats",
                column: "response_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_user_id",
                table: "Addresses",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_RequestObjects_RequestsId",
                table: "RequestObjects",
                column: "RequestsId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestPictures_RequestsId",
                table: "RequestPictures",
                column: "RequestsId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSkills_SkillsId",
                table: "RequestSkills",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserObjects_UsersId",
                table: "UserObjects",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_UsersId",
                table: "UserSkills",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users",
                table: "Addresses",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Responses",
                table: "Chats",
                column: "response_id",
                principalTable: "Responses",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Users",
                table: "feedbacks",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBackApplications_Users",
                table: "feedbacks_application",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users",
                table: "Issues",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectCategories_ObjectCategories",
                table: "ObjectCategories",
                column: "parent_id",
                principalTable: "ObjectCategories",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectCategories_Pictures",
                table: "ObjectCategories",
                column: "picture_id",
                principalTable: "Pictures",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectCategories_Pictures_PictureId1",
                table: "ObjectCategories",
                column: "PictureId1",
                principalTable: "Pictures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_ObjectCategories",
                table: "Objects",
                column: "category_id",
                principalTable: "ObjectCategories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_Pictures",
                table: "Objects",
                column: "picture_id",
                principalTable: "Pictures",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_Pictures_PictureId1",
                table: "Objects",
                column: "PictureId1",
                principalTable: "Pictures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_Users",
                table: "Preferences",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Statuses",
                table: "Requests",
                column: "status_id",
                principalTable: "Statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Requests",
                table: "Responses",
                column: "request_id",
                principalTable: "Requests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Requests_RequestId1",
                table: "Responses",
                column: "RequestId1",
                principalTable: "Requests",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Statuses",
                table: "Responses",
                column: "response_status_id",
                principalTable: "ResponseStatuses",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Users",
                table: "Responses",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Pictures",
                table: "Skills",
                column: "picture_id",
                principalTable: "Pictures",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Pictures_PictureId1",
                table: "Skills",
                column: "PictureId1",
                principalTable: "Pictures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Pictures",
                table: "Users",
                column: "picture_id",
                principalTable: "Pictures",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Pictures_PictureId1",
                table: "Users",
                column: "PictureId1",
                principalTable: "Pictures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles",
                table: "Users",
                column: "role_id",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Responses",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Users",
                table: "feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBackApplications_Users",
                table: "feedbacks_application");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectCategories_ObjectCategories",
                table: "ObjectCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectCategories_Pictures",
                table: "ObjectCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectCategories_Pictures_PictureId1",
                table: "ObjectCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Objects_ObjectCategories",
                table: "Objects");

            migrationBuilder.DropForeignKey(
                name: "FK_Objects_Pictures",
                table: "Objects");

            migrationBuilder.DropForeignKey(
                name: "FK_Objects_Pictures_PictureId1",
                table: "Objects");

            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_Users",
                table: "Preferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Statuses",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Requests",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Requests_RequestId1",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Statuses",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Users",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Pictures",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Pictures_PictureId1",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Pictures",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Pictures_PictureId1",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles",
                table: "Users");

            migrationBuilder.DropTable(
                name: "RequestObjects");

            migrationBuilder.DropTable(
                name: "RequestPictures");

            migrationBuilder.DropTable(
                name: "RequestSkills");

            migrationBuilder.DropTable(
                name: "ResponseStatuses");

            migrationBuilder.DropTable(
                name: "UserObjects");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropIndex(
                name: "IX_Users_picture_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PictureId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_role_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Skills_picture_id",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_PictureId1",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Responses_request_id",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_RequestId1",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_response_status_id",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_user_id",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Requests_status_id",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_user_id",
                table: "Preferences");

            migrationBuilder.DropIndex(
                name: "IX_Objects_category_id",
                table: "Objects");

            migrationBuilder.DropIndex(
                name: "IX_Objects_picture_id",
                table: "Objects");

            migrationBuilder.DropIndex(
                name: "IX_Objects_PictureId1",
                table: "Objects");

            migrationBuilder.DropIndex(
                name: "IX_ObjectCategories_parent_id",
                table: "ObjectCategories");

            migrationBuilder.DropIndex(
                name: "IX_ObjectCategories_picture_id",
                table: "ObjectCategories");

            migrationBuilder.DropIndex(
                name: "IX_ObjectCategories_PictureId1",
                table: "ObjectCategories");

            migrationBuilder.DropIndex(
                name: "IX_Issues_user_id",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_feedbacks_application_user_id",
                table: "feedbacks_application");

            migrationBuilder.DropIndex(
                name: "IX_feedbacks_user_id",
                table: "feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Chats_response_id",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_user_id",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PictureId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "picture_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "role_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PictureId1",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "picture_id",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "RequestId1",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "response_status_id",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "status_id",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "PictureId1",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "picture_id",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "PictureId1",
                table: "ObjectCategories");

            migrationBuilder.DropColumn(
                name: "parent_id",
                table: "ObjectCategories");

            migrationBuilder.DropColumn(
                name: "picture_id",
                table: "ObjectCategories");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "feedbacks_application");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "feedbacks");

            migrationBuilder.DropColumn(
                name: "response_id",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Users",
                newName: "desciption");

            migrationBuilder.RenameColumn(
                name: "deadline",
                table: "Requests",
                newName: "Deadline");

            migrationBuilder.AddColumn<Guid>(
                name: "PictureId",
                table: "Requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "floor",
                table: "Addresses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
