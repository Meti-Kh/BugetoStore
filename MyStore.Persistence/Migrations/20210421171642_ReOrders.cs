using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyStore.Persistence.Migrations
{
    public partial class ReOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderState",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2021, 4, 21, 21, 46, 41, 632, DateTimeKind.Local).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2021, 4, 21, 21, 46, 41, 637, DateTimeKind.Local).AddTicks(900));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2021, 4, 21, 21, 46, 41, 637, DateTimeKind.Local).AddTicks(1101));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderState",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2021, 4, 21, 21, 17, 44, 576, DateTimeKind.Local).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2021, 4, 21, 21, 17, 44, 581, DateTimeKind.Local).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2021, 4, 21, 21, 17, 44, 581, DateTimeKind.Local).AddTicks(8355));
        }
    }
}
