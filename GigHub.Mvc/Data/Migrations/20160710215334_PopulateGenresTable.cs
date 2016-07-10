using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GigHub.Mvc.Data.Migrations
{
    public partial class PopulateGenresTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Jazz')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Blues')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Rock')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Country')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Genres WHERE Id IN (1,2,3,4)");
        }
    }
}
