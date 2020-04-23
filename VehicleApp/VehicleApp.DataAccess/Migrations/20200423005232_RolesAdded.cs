using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleApp.DataAccess.Migrations
{
    public partial class RolesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d04b0ffd-0174-4ce5-9525-baf4796be7de", "88649640-475c-4d47-8ff8-a95d0bb457a0" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d04b0ffd-0174-4ce5-9525-baf4796be7de", "b291dc4c-6127-46e2-95f2-318977854e1a" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4789e08d-9ffd-4428-93cc-4fd2955c5c65", "0ab3115c-cbf6-4137-85da-b04c016266a9", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2bdfd6f-5ba4-4660-8022-c6b374af4dae", "94b8ec73-112f-4ec4-accf-5fd95eaaecfa", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4789e08d-9ffd-4428-93cc-4fd2955c5c65", 0, "250d72aa-5b6b-4219-b7bb-09e0145978b9", "manager@mail.com", true, null, false, null, "manager@mail.com", "MANAGER", "AQAAAAEAACcQAAAAECty05zm53+q33ZoMUV91Mu56iYyagJsN4g7qT26wnctz91qK0oVXthoci3v5zOadw==", null, false, "", false, "manager" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a2bdfd6f-5ba4-4660-8022-c6b374af4dae", "4789e08d-9ffd-4428-93cc-4fd2955c5c65" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "a2bdfd6f-5ba4-4660-8022-c6b374af4dae", "94b8ec73-112f-4ec4-accf-5fd95eaaecfa" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a2bdfd6f-5ba4-4660-8022-c6b374af4dae", "4789e08d-9ffd-4428-93cc-4fd2955c5c65" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4789e08d-9ffd-4428-93cc-4fd2955c5c65", "250d72aa-5b6b-4219-b7bb-09e0145978b9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4789e08d-9ffd-4428-93cc-4fd2955c5c65", "0ab3115c-cbf6-4137-85da-b04c016266a9" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d04b0ffd-0174-4ce5-9525-baf4796be7de", "88649640-475c-4d47-8ff8-a95d0bb457a0", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d04b0ffd-0174-4ce5-9525-baf4796be7de", 0, "b291dc4c-6127-46e2-95f2-318977854e1a", "manager@mail.com", true, null, false, null, "manager@mail.com", "MANAGER", "AQAAAAEAACcQAAAAEMHINIlppplLS7QAUanqGSs75SGIlABDJ9AzjF0+VOahCdzNb3wEZwIrRWRXYJnKhA==", null, false, "", false, "manager" });
        }
    }
}
