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
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.RenameColumn(
                name: "desciption",
                table: "Users",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Deadline",
                table: "Requests",
                newName: "deadline");

            migrationBuilder.RenameColumn(
                name: "PictureId",
                table: "Requests",
                newName: "status_id");

            migrationBuilder.AddColumn<Guid>(
                name: "picture_id",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "role_id",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "picture_id",
                table: "Skills",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "Responses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "request_id",
                table: "Responses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "response_status_id",
                table: "Responses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "Preferences",
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
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "feedbacks_application",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "feedbacks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "response_id",
                table: "Chats",
                type: "uuid",
                nullable: true);

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
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ObjectModelRequest",
                columns: table => new
                {
                    ObjectsId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectModelRequest", x => new { x.ObjectsId, x.RequestsId });
                    table.ForeignKey(
                        name: "FK_ObjectModelRequest_Objects_ObjectsId",
                        column: x => x.ObjectsId,
                        principalTable: "Objects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectModelRequest_Requests_RequestsId",
                        column: x => x.RequestsId,
                        principalTable: "Requests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectModelUser",
                columns: table => new
                {
                    ObjectsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectModelUser", x => new { x.ObjectsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ObjectModelUser_Objects_ObjectsId",
                        column: x => x.ObjectsId,
                        principalTable: "Objects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectModelUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "RequestSkill",
                columns: table => new
                {
                    RequestsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSkill", x => new { x.RequestsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_RequestSkill_Requests_RequestsId",
                        column: x => x.RequestsId,
                        principalTable: "Requests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestSkill_Skills_SkillsId",
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
                name: "SkillUser",
                columns: table => new
                {
                    SkillsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillUser", x => new { x.SkillsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_SkillUser_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillUser_Users_UsersId",
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
                name: "IX_Users_role_id",
                table: "Users",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_picture_id",
                table: "Skills",
                column: "picture_id");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_request_id",
                table: "Responses",
                column: "request_id");

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
                name: "IX_ObjectCategories_parent_id",
                table: "ObjectCategories",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectCategories_picture_id",
                table: "ObjectCategories",
                column: "picture_id");

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
                name: "IX_ObjectModelRequest_RequestsId",
                table: "ObjectModelRequest",
                column: "RequestsId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectModelUser_UsersId",
                table: "ObjectModelUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureRequest_RequestsId",
                table: "PictureRequest",
                column: "RequestsId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSkill_SkillsId",
                table: "RequestSkill",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillUser_UsersId",
                table: "SkillUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_user_id",
                table: "Addresses",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Responses_response_id",
                table: "Chats",
                column: "response_id",
                principalTable: "Responses",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_Users_user_id",
                table: "feedbacks",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_application_Users_user_id",
                table: "feedbacks_application",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users_user_id",
                table: "Issues",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectCategories_ObjectCategories_parent_id",
                table: "ObjectCategories",
                column: "parent_id",
                principalTable: "ObjectCategories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectCategories_Pictures_picture_id",
                table: "ObjectCategories",
                column: "picture_id",
                principalTable: "Pictures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_ObjectCategories_category_id",
                table: "Objects",
                column: "category_id",
                principalTable: "ObjectCategories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_Pictures_picture_id",
                table: "Objects",
                column: "picture_id",
                principalTable: "Pictures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_Users_user_id",
                table: "Preferences",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Statuses_status_id",
                table: "Requests",
                column: "status_id",
                principalTable: "Statuses",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Requests_request_id",
                table: "Responses",
                column: "request_id",
                principalTable: "Requests",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_ResponseStatuses_response_status_id",
                table: "Responses",
                column: "response_status_id",
                principalTable: "ResponseStatuses",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Users_user_id",
                table: "Responses",
                column: "user_id",
                principalTable: "Users",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_role_id",
                table: "Users",
                column: "role_id",
                principalTable: "Roles",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_user_id",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Responses_response_id",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_Users_user_id",
                table: "feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_application_Users_user_id",
                table: "feedbacks_application");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users_user_id",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectCategories_ObjectCategories_parent_id",
                table: "ObjectCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectCategories_Pictures_picture_id",
                table: "ObjectCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Objects_ObjectCategories_category_id",
                table: "Objects");

            migrationBuilder.DropForeignKey(
                name: "FK_Objects_Pictures_picture_id",
                table: "Objects");

            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_Users_user_id",
                table: "Preferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Statuses_status_id",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Requests_request_id",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_ResponseStatuses_response_status_id",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Users_user_id",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Pictures_picture_id",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Pictures_picture_id",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_role_id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ObjectModelRequest");

            migrationBuilder.DropTable(
                name: "ObjectModelUser");

            migrationBuilder.DropTable(
                name: "PictureRequest");

            migrationBuilder.DropTable(
                name: "RequestSkill");

            migrationBuilder.DropTable(
                name: "ResponseStatuses");

            migrationBuilder.DropTable(
                name: "SkillUser");

            migrationBuilder.DropIndex(
                name: "IX_Users_picture_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_role_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Skills_picture_id",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Responses_request_id",
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
                name: "IX_ObjectCategories_parent_id",
                table: "ObjectCategories");

            migrationBuilder.DropIndex(
                name: "IX_ObjectCategories_picture_id",
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
                name: "picture_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "role_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "picture_id",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "response_status_id",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "picture_id",
                table: "Objects");

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

            migrationBuilder.RenameColumn(
                name: "status_id",
                table: "Requests",
                newName: "PictureId");

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "Responses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "request_id",
                table: "Responses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "floor",
                table: "Addresses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    chat_id = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
                });
        }
    }
}
