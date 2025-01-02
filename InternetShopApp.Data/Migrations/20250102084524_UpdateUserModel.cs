using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternetShopApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedAt",
            //    table: "Stocks",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "Products",
            //    type: "nvarchar(100)",
            //    maxLength: 100,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Description",
            //    table: "Products",
            //    type: "nvarchar(200)",
            //    maxLength: 200,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedAt",
            //    table: "Products",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "TypeOfPayment",
            //    table: "Orders",
            //    type: "nvarchar(20)",
            //    maxLength: 20,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "PaymentStatus",
            //    table: "Orders",
            //    type: "nvarchar(50)",
            //    maxLength: 50,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedAt",
            //    table: "OrderItems",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "Categories",
            //    type: "nvarchar(50)",
            //    maxLength: 50,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Description",
            //    table: "Categories",
            //    type: "nvarchar(200)",
            //    maxLength: 200,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedAt",
            //    table: "Categories",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedAt",
            //    table: "Carts",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedAt",
            //    table: "CartItems",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2",
            //    oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedAt",
            //    table: "Stocks",
            //    type: "datetime2",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "Products",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(100)",
            //    oldMaxLength: 100);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Description",
            //    table: "Products",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(200)",
            //    oldMaxLength: 200,
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedAt",
            //    table: "Products",
            //    type: "datetime2",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2");

            //migrationBuilder.AlterColumn<string>(
            //    name: "TypeOfPayment",
            //    table: "Orders",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(20)",
            //    oldMaxLength: 20);

            //migrationBuilder.AlterColumn<string>(
            //    name: "PaymentStatus",
            //    table: "Orders",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(50)",
            //    oldMaxLength: 50);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedAt",
            //    table: "OrderItems",
            //    type: "datetime2",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "Categories",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(50)",
            //    oldMaxLength: 50);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Description",
            //    table: "Categories",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(200)",
            //    oldMaxLength: 200,
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedAt",
            //    table: "Categories",
            //    type: "datetime2",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedAt",
            //    table: "Carts",
            //    type: "datetime2",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedAt",
            //    table: "CartItems",
            //    type: "datetime2",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2");
        }
    }
}
