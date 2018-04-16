using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MYH.ABP.Migrations
{
    public partial class modifymember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FakeId",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadUrl",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpenIdMini",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpenIdMp",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnionId",
                schema: "EWMS",
                table: "MemberEntity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "FakeId",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "HeadUrl",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "NickName",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "OpenIdMini",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "OpenIdMp",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "Sex",
                schema: "EWMS",
                table: "MemberEntity");

            migrationBuilder.DropColumn(
                name: "UnionId",
                schema: "EWMS",
                table: "MemberEntity");
        }
    }
}
