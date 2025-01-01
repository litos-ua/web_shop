using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternetShopApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeDefaultValuesToOrderFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "DeliveryRequirement",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "ReceivedStatus",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "TypeOfPayment",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "card",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "not paid",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "DeliveryRequirement",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: null,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "ReceivedStatus",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: null,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "TypeOfPayment",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: null,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "card");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: null,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "not paid");
        }
    }
}
