using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Programers.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9186), new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9203) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9217), new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9219) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9223), new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9224) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9227), new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9228) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9232), new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9233) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9236), new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9237) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9240), new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9242) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9245), new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9246) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9249), new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9250) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9254), new DateTime(2021, 8, 5, 10, 32, 37, 168, DateTimeKind.Local).AddTicks(9255) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7489), new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7503) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7517), new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7518) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7522), new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7523) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7526), new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7527) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7530), new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7532) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7535), new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7536) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7540), new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7541) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7544), new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7545) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7548), new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7550) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7553), new DateTime(2021, 8, 5, 10, 32, 37, 171, DateTimeKind.Local).AddTicks(7554) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(3108), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(2081), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(3643) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4857), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4855), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4859) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4865), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4863), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4866) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4871), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4870), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4873) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4877), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4876), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4879) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4884), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4882), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4885) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4889), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4888), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4891) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4895), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4894), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4896) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4901), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4900), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4903) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4911), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4910), new DateTime(2021, 8, 5, 10, 32, 37, 165, DateTimeKind.Local).AddTicks(4913) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "88980a0e-f9b1-4aa4-88f2-32d1c9196163");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "606eb314-e406-454f-98de-4e56c7258073");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "600a76a3-837f-46cd-a268-1c314ff6565c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "3a600bd4-1996-4e8e-ad7e-b1da07b125b2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "dd042597-1b5d-418a-8380-21d1a847812b");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "8adbc1a4-4f55-471b-9b46-1d7e0c5d5246");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "b4236985-32f2-4227-87f0-0e84ca22cd2d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "2f269338-064a-4696-8472-d737412efa48");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "61529e8c-9cfe-464c-97ef-f2ad34f35f5a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "8956af6d-f800-433a-bb80-6eb58d33af50");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "dac1bfeb-660f-4a32-8153-b8406fbb0356");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "6e85a9ef-4a0a-4e85-bd34-2c4f440060dc");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "96748b08-e944-465f-9907-76c294223683");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "152dca20-2ff8-4fe8-98df-ff2c5ca30a3a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "dd687cb8-a69e-46db-8669-4b22e4390d57");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "417a1b72-b4b2-4302-89f4-4c13e38dfda6");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "96e53405-550f-4bd8-b750-dab1a6250266");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18,
                column: "ConcurrencyStamp",
                value: "2973221f-2fa6-44dc-a731-4fa21781aafb");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19,
                column: "ConcurrencyStamp",
                value: "a5ec034f-a81a-4ed3-8102-a4d69bd8242f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20,
                column: "ConcurrencyStamp",
                value: "28540d4e-f792-4aef-90ab-5eb0ae5c2475");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21,
                column: "ConcurrencyStamp",
                value: "5a6ada6a-585a-4c74-b394-f518aceb2bf7");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22,
                column: "ConcurrencyStamp",
                value: "bd58a97b-755c-4495-947d-4d0fb5ea251f");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c02b16c-d8a7-468b-8ca4-3b631b06d909", "AQAAAAEAACcQAAAAEPKSn6GAWc0rSrP0iA2hcg8rEICQjjJOQBy5CbEMxWJCKhdUKOHJWHGdMQ4KXBBNyA==", "a100ce28-8dca-47e3-87a3-980b159a2451" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b41ca4f9-8190-4618-8f3d-6dca6d227c8e", "AQAAAAEAACcQAAAAEPz+2l+Yk27c3NobTlu5wV2DwxApPty8ZHZGENZi2u0rOUuuUS2uBDHQF25Xj7SvPA==", "378c0a02-74a5-4668-9ad4-053bc0ef8727" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5321), new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5357), new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5359) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5362), new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5364) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5367), new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5368) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5371), new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5372) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5375), new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5508) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5513), new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5515) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5518), new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5519) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5522), new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5524) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5527), new DateTime(2021, 8, 5, 10, 11, 2, 242, DateTimeKind.Local).AddTicks(5528) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2492), new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2506) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2520), new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2522) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2525), new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2526) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2529), new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2531) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2534), new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2535) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2538), new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2540) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2543), new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2544) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2547), new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2548) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2552), new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2553) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2556), new DateTime(2021, 8, 5, 10, 11, 2, 245, DateTimeKind.Local).AddTicks(2557) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 238, DateTimeKind.Local).AddTicks(9046), new DateTime(2021, 8, 5, 10, 11, 2, 238, DateTimeKind.Local).AddTicks(8002), new DateTime(2021, 8, 5, 10, 11, 2, 238, DateTimeKind.Local).AddTicks(9591) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(813), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(810), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(814) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(821), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(819), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(822) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(827), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(825), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(828) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(833), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(831), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(834) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(839), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(837), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(840) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(898), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(897), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(905), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(903), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(906) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(911), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(909), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(912) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(917), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(915), new DateTime(2021, 8, 5, 10, 11, 2, 239, DateTimeKind.Local).AddTicks(918) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4f2a10f8-9900-410a-985b-69862a107232");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "17d52254-507e-4f73-88ee-51d9404323b0");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "7b0334dd-222c-445a-a8a9-f2b5a4b8636d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "fa3dbd34-c766-4fdf-a4dd-05b4fcd6e4b1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "32c3dbde-1d3d-432a-b0b3-a82059be371a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "367a672c-23f6-412e-89d3-b73c7bf5f92c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "5c50f7f7-bfab-406d-8ff8-318a76d58e71");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "0894a490-81ad-47a0-8a5a-c2e0f7813688");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "085bce20-fd32-4904-9000-282bce01c308");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "e353dcc8-82bc-4507-b94c-03c28be30f93");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "8a0e654b-6a08-4c15-8567-013ec4f93176");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "2f75f81b-398b-4413-9eb3-b8c1af20c6cc");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "754a049e-cfa4-480d-8ca0-299c61097954");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "8ada5803-4c89-41ac-a5dc-5133d0b04068");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "46f6961e-b16e-45a8-8f63-92db2af0dcf3");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "b28a36ac-f8ed-41a4-9f10-db3ee3dbe3ec");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "acfb71ea-fc96-40c5-85f4-261c7c3672dd");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18,
                column: "ConcurrencyStamp",
                value: "77f90a59-0caa-419e-8d43-8805626bfa1f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19,
                column: "ConcurrencyStamp",
                value: "53de2331-0045-4ffa-8dc0-df15c167c2ff");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20,
                column: "ConcurrencyStamp",
                value: "9a2ccc67-3854-4f4d-b2a0-7e40059d0803");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21,
                column: "ConcurrencyStamp",
                value: "392808dd-9a6c-49bb-a93e-362084526c50");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22,
                column: "ConcurrencyStamp",
                value: "944ffbe2-ce09-4640-b7b2-1fef380a6ad3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b1829f9-5c4b-4e88-b2b1-163b286737ad", "AQAAAAEAACcQAAAAEDmUI6I/RAskNcstIvfm0wq9kRB2Aq9xTNFzZURh9460YrPwbnHVMW5KpnVDHlB3jA==", "e667d1c8-00f3-4711-93f3-4c4a7714f5dd" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c11db409-384e-4a53-a5ce-14bafce4bb9e", "AQAAAAEAACcQAAAAEE6hHBTQM8a4HmEP7qw9l3AsBT5YTF+P44Fu/IoriX0yq6L7uFvDRZhkV0GPHFCQOg==", "d7f155f9-1a5e-4ca6-b1b2-6cd351321383" });
        }
    }
}
