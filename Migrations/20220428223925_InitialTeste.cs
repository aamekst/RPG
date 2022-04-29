﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class InitialTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 222, 233, 82, 233, 58, 215, 85, 241, 221, 95, 189, 213, 4, 83, 49, 177, 77, 238, 254, 186, 14, 171, 97, 46, 160, 178, 210, 247, 99, 141, 90, 179, 136, 253, 227, 247, 21, 138, 35, 118, 61, 45, 92, 115, 151, 99, 36, 135, 80, 102, 67, 181, 19, 174, 108, 210, 78, 19, 177, 248, 24, 178, 204, 201 }, new byte[] { 149, 67, 44, 192, 42, 134, 209, 124, 210, 53, 121, 203, 137, 248, 84, 179, 39, 220, 98, 81, 71, 212, 43, 140, 54, 94, 99, 94, 163, 246, 168, 190, 223, 250, 97, 75, 55, 171, 165, 155, 145, 18, 206, 95, 89, 5, 165, 229, 240, 95, 131, 93, 4, 28, 174, 139, 157, 116, 136, 24, 253, 81, 219, 232, 53, 5, 234, 48, 12, 132, 117, 249, 123, 89, 29, 183, 180, 178, 169, 116, 226, 130, 166, 237, 147, 51, 59, 45, 41, 87, 209, 33, 110, 206, 93, 109, 255, 128, 193, 79, 192, 161, 51, 51, 60, 68, 122, 73, 70, 103, 100, 57, 67, 87, 146, 212, 85, 13, 152, 150, 137, 1, 216, 121, 245, 203, 60, 1 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 204, 184, 52, 114, 239, 18, 113, 94, 35, 190, 102, 12, 83, 199, 251, 99, 142, 172, 87, 168, 13, 107, 237, 14, 150, 135, 219, 69, 237, 190, 154, 200, 233, 111, 185, 65, 44, 173, 124, 129, 249, 77, 67, 14, 113, 173, 241, 82, 159, 187, 109, 53, 61, 198, 117, 242, 14, 247, 138, 69, 229, 45, 181, 61 }, new byte[] { 50, 114, 238, 72, 62, 53, 180, 201, 5, 187, 200, 42, 236, 17, 124, 226, 80, 226, 54, 168, 192, 222, 46, 70, 125, 176, 57, 44, 145, 137, 73, 226, 109, 66, 67, 91, 249, 76, 73, 40, 136, 153, 51, 222, 90, 151, 29, 232, 3, 236, 24, 73, 181, 54, 226, 31, 142, 111, 38, 233, 204, 12, 8, 129, 120, 226, 70, 9, 249, 38, 219, 78, 125, 245, 206, 244, 90, 25, 16, 49, 186, 82, 236, 129, 223, 103, 199, 211, 255, 226, 52, 196, 141, 56, 57, 46, 22, 91, 151, 215, 193, 119, 137, 144, 14, 127, 167, 200, 189, 247, 38, 0, 161, 48, 84, 62, 31, 96, 196, 187, 5, 142, 141, 29, 139, 208, 20, 93 } });
        }
    }
}
