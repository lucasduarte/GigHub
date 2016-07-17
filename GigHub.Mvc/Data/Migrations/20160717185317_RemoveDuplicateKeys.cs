using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GigHub.Mvc.Data.Migrations
{
    public partial class RemoveDuplicateKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    GigId = table.Column<int>(maxLength: 450, nullable: false),
                    AttendeeId = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => new { x.GigId, x.AttendeeId });
                    table.ForeignKey(
                        name: "FK_Attendances_AspNetUsers_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Attendances_Gigs_GigId",
                        column: x => x.GigId,
                        principalTable: "Gigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Followings",
                columns: table => new
                {
                    FollowerId = table.Column<string>(maxLength: 450, nullable: false),
                    FolloweeId = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followings", x => new { x.FollowerId, x.FolloweeId });
                    table.ForeignKey(
                        name: "FK_Followings_AspNetUsers_FolloweeId",
                        column: x => x.FolloweeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Followings_AspNetUsers_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_AttendeeId",
                table: "Attendances",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_GigId",
                table: "Attendances",
                column: "GigId");

            migrationBuilder.CreateIndex(
                name: "IX_Followings_FolloweeId",
                table: "Followings",
                column: "FolloweeId");

            migrationBuilder.CreateIndex(
                name: "IX_Followings_FollowerId",
                table: "Followings",
                column: "FollowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Followings");
        }
    }
}
