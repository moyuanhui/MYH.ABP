using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MYH.ABP.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_Person_PersonId",
                schema: "PB",
                table: "PhoneNumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneNumber",
                schema: "PB",
                table: "PhoneNumber");

            migrationBuilder.RenameTable(
                name: "PhoneNumber",
                schema: "PB",
                newName: "OrderInfo");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneNumber_PersonId",
                schema: "PB",
                table: "OrderInfo",
                newName: "IX_OrderInfo_PersonId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "PB",
                table: "OrderInfo",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                schema: "PB",
                table: "OrderInfo",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                schema: "PB",
                table: "OrderInfo",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "PB",
                table: "OrderInfo",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "PB",
                table: "OrderInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "PB",
                table: "OrderInfo",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                schema: "PB",
                table: "OrderInfo",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderInfo",
                schema: "PB",
                table: "OrderInfo",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrderInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderMsg = table.Column<string>(nullable: true),
                    OrderNum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInfo", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInfo_Person_PersonId",
                schema: "PB",
                table: "OrderInfo",
                column: "PersonId",
                principalSchema: "PB",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderInfo_Person_PersonId",
                schema: "PB",
                table: "OrderInfo");

            migrationBuilder.DropTable(
                name: "OrderInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderInfo",
                schema: "PB",
                table: "OrderInfo");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                schema: "PB",
                table: "OrderInfo");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                schema: "PB",
                table: "OrderInfo");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                schema: "PB",
                table: "OrderInfo");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "PB",
                table: "OrderInfo");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                schema: "PB",
                table: "OrderInfo");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                schema: "PB",
                table: "OrderInfo");

            migrationBuilder.RenameTable(
                name: "OrderInfo",
                schema: "PB",
                newName: "PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_OrderInfo_PersonId",
                schema: "PB",
                table: "PhoneNumber",
                newName: "IX_PhoneNumber_PersonId");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "PB",
                table: "PhoneNumber",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneNumber",
                schema: "PB",
                table: "PhoneNumber",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Person_PersonId",
                schema: "PB",
                table: "PhoneNumber",
                column: "PersonId",
                principalSchema: "PB",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
