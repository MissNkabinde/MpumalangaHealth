using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MpumalangaHealth.Migrations
{
    /// <inheritdoc />
    public partial class AddNewsItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsItems",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "ArticleID",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "CurrentStatus",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "DateApproved",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "DatePublished",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "NewsItems");

            migrationBuilder.RenameColumn(
                name: "RevisionNotes",
                table: "NewsItems",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "DateSubmitted",
                table: "NewsItems",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "NewsItems",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Admins",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "AdminID",
                table: "Admins",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "NewsItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "NewsItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsItems",
                table: "NewsItems",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsItems",
                table: "NewsItems");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "NewsItems",
                newName: "DateSubmitted");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "NewsItems",
                newName: "RevisionNotes");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "NewsItems",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Admins",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admins",
                newName: "AdminID");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "NewsItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "NewsItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ArticleID",
                table: "NewsItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ApprovedBy",
                table: "NewsItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "NewsItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentStatus",
                table: "NewsItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateApproved",
                table: "NewsItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublished",
                table: "NewsItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "NewsItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsItems",
                table: "NewsItems",
                column: "ArticleID");
        }
    }
}
