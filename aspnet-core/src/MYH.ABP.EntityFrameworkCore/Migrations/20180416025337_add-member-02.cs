using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MYH.ABP.Migrations
{
    public partial class addmember02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "MemberEntity",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MemberEntity",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "MemberEntity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "MemberEntity");
        }
    }
}
