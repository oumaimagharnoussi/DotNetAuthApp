using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackAppPFE.Migrations
{
    /// <inheritdoc />
    public partial class user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_users_ImageId",
                schema: "HR",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "users",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "users",
                newName: "userNumber");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "users",
                newName: "picture");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "qualification");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                schema: "HR",
                table: "Tickets",
                newName: "ImageuserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ImageId",
                schema: "HR",
                table: "Tickets",
                newName: "IX_Tickets_ImageuserId");

            migrationBuilder.AlterColumn<int>(
                name: "qualification",
                table: "users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_users_ImageuserId",
                schema: "HR",
                table: "Tickets",
                column: "ImageuserId",
                principalTable: "users",
                principalColumn: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_users_ImageuserId",
                schema: "HR",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "userNumber",
                table: "users",
                newName: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "qualification",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "picture",
                table: "users",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "ImageuserId",
                schema: "HR",
                table: "Tickets",
                newName: "ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ImageuserId",
                schema: "HR",
                table: "Tickets",
                newName: "IX_Tickets_ImageId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Tel",
                table: "users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_users_ImageId",
                schema: "HR",
                table: "Tickets",
                column: "ImageId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
