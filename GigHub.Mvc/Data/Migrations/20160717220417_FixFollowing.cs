using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GigHub.Mvc.Data.Migrations
{
    public partial class FixFollowing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followings_AspNetUsers_FolloweeId",
                table: "Followings");

            migrationBuilder.DropForeignKey(
                name: "FK_Followings_AspNetUsers_FollowerId",
                table: "Followings");

            migrationBuilder.DropIndex(
                name: "IX_Followings_FolloweeId",
                table: "Followings");

            migrationBuilder.DropIndex(
                name: "IX_Followings_FollowerId",
                table: "Followings");

            migrationBuilder.AddColumn<string>(
                name: "FolloweeId1",
                table: "Followings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FollowerId1",
                table: "Followings",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FolloweeId",
                table: "Followings",
                maxLength: 450,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "FollowerId",
                table: "Followings",
                maxLength: 450,
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Followings_FolloweeId1",
                table: "Followings",
                column: "FolloweeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Followings_FollowerId1",
                table: "Followings",
                column: "FollowerId1");

            migrationBuilder.AlterColumn<string>(
                name: "AttendeeId",
                table: "Attendances",
                maxLength: 450,
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_AspNetUsers_FolloweeId1",
                table: "Followings",
                column: "FolloweeId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_AspNetUsers_FollowerId1",
                table: "Followings",
                column: "FollowerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followings_AspNetUsers_FolloweeId1",
                table: "Followings");

            migrationBuilder.DropForeignKey(
                name: "FK_Followings_AspNetUsers_FollowerId1",
                table: "Followings");

            migrationBuilder.DropIndex(
                name: "IX_Followings_FolloweeId1",
                table: "Followings");

            migrationBuilder.DropIndex(
                name: "IX_Followings_FollowerId1",
                table: "Followings");

            migrationBuilder.DropColumn(
                name: "FolloweeId1",
                table: "Followings");

            migrationBuilder.DropColumn(
                name: "FollowerId1",
                table: "Followings");

            migrationBuilder.AlterColumn<string>(
                name: "FolloweeId",
                table: "Followings",
                maxLength: 100,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "FollowerId",
                table: "Followings",
                maxLength: 100,
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Followings_FolloweeId",
                table: "Followings",
                column: "FolloweeId");

            migrationBuilder.CreateIndex(
                name: "IX_Followings_FollowerId",
                table: "Followings",
                column: "FollowerId");

            migrationBuilder.AlterColumn<string>(
                name: "AttendeeId",
                table: "Attendances",
                maxLength: 100,
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_AspNetUsers_FolloweeId",
                table: "Followings",
                column: "FolloweeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_AspNetUsers_FollowerId",
                table: "Followings",
                column: "FollowerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
