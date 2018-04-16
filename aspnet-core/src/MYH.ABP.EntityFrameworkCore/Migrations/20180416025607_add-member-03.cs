using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MYH.ABP.Migrations
{
    public partial class addmember03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EWMS");

            migrationBuilder.RenameTable(
                name: "MemberEntity",
                newSchema: "EWMS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "MemberEntity",
                schema: "EWMS");
        }
    }
}
