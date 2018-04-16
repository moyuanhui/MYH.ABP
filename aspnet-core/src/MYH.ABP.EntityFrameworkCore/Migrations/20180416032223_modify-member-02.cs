using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MYH.ABP.Migrations
{
    public partial class modifymember02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                schema: "EWMS",
                table: "MemberEntity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);
        }
    }
}
