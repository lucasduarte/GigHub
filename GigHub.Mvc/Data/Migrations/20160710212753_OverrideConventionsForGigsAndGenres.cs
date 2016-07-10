﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GigHub.Mvc.Data.Migrations
{
    public partial class OverrideConventionsForGigsAndGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_AspNetUsers_ArtistId",
                table: "Gigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Genres_GenreId",
                table: "Gigs");

            migrationBuilder.AlterColumn<string>(
                name: "Venue",
                table: "Gigs",
                maxLength: 255,
                nullable: false);

            migrationBuilder.AlterColumn<byte>(
                name: "GenreId",
                table: "Gigs",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ArtistId",
                table: "Gigs",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                maxLength: 255,
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_AspNetUsers_ArtistId",
                table: "Gigs",
                column: "ArtistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Genres_GenreId",
                table: "Gigs",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_AspNetUsers_ArtistId",
                table: "Gigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Genres_GenreId",
                table: "Gigs");

            migrationBuilder.AlterColumn<string>(
                name: "Venue",
                table: "Gigs",
                nullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "GenreId",
                table: "Gigs",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArtistId",
                table: "Gigs",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_AspNetUsers_ArtistId",
                table: "Gigs",
                column: "ArtistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Genres_GenreId",
                table: "Gigs",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
