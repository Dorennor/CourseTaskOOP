using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseTaskOOP.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    IsLogged = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    IsLogged = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    IsLogged = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    IsLogged = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamLeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    IsLogged = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamLeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    HoursToComplete = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    TeamLeaderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_TeamLeaders_TeamLeaderId",
                        column: x => x.TeamLeaderId,
                        principalTable: "TeamLeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Deadline = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    IsLogged = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deadline = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 1, "Administrator", false, "CF-83-5D-E3-D4-EA-01-36-7C-45-E4-12-E7-A9-39-3A-85-A4-E4-0A-F1-49-ED-8C-3E-D6-C3-7C-05-B6-7B-27-81-3D-7F-F8-07-2C-10-35-CE-DD-19-41-5A-DF-17-12-8D-63-18-6F-05-F0-D6-56-00-2B-0C-A1-C3-4F-44-A0", "Administrator", "Administrator" });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 2, "Admin", false, "C7-AD-44-CB-AD-76-2A-5D-A0-A4-52-F9-E8-54-FD-C1-E0-E7-A5-2A-38-01-5F-23-F3-EA-B1-D8-0B-93-1D-D4-72-63-4D-FA-C7-1C-D3-4E-BC-35-D1-6A-B7-FB-8A-90-C8-1F-97-51-13-D6-C7-53-8D-C6-9D-D8-DE-90-77-EC", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 1, "clemens@pacocharyan.co.uk", "Nicholas Wolf Jr.", false, "BC-1A-4C-B5-88-77-DA-14-02-91-85-36-0C-59-CF-6F-56-FF-18-EA-0B-F2-93-1A-86-C9-5A-86-43-6C-16-91-BA-6E-13-3C-C6-8E-B5-73-33-F1-7C-B4-3B-66-6F-37-EC-78-A5-DD-54-1F-E3-31-E3-E2-9D-16-A6-51-D7-3C" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 2, "liana@bernier.uk", "Mrs. Jarrett Homenick III", false, "A3-54-E0-6B-97-8D-C6-8C-BC-93-B8-FC-52-D7-13-56-46-D9-AA-89-0B-4F-DD-59-75-2C-BD-6F-B7-51-19-31-1F-88-33-AE-7D-79-01-BB-7F-56-D7-61-44-7F-E5-B8-5F-A0-90-4A-D7-82-0E-CC-BE-53-38-39-48-92-BC-C4" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 3, "yasmeen@littelhegmann.name", "Dahlia Jones", false, "60-42-2A-D7-AC-A8-D3-C5-0D-AB-47-5A-FE-68-C6-12-79-CB-FF-20-E0-AD-89-52-E5-AD-60-7B-C0-1C-23-38-F8-24-8B-87-44-23-68-0D-CF-69-5E-A3-A7-DB-80-12-D9-A6-EE-6C-4A-7D-DB-50-0B-B5-B0-47-0A-84-E3-3E" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 4, "amos_jaskolski@watersweimann.uk", "Mr. Alta Nitzsche DVM", false, "E7-95-A4-14-C4-FF-31-EB-55-89-D0-CB-9B-24-63-17-CE-53-D4-AB-AD-9B-50-44-BB-2E-1B-8D-67-8D-19-44-42-B7-F8-5E-89-C7-D8-E3-6D-8C-A5-09-D2-6A-A4-CC-8C-EB-D9-8E-EF-F5-7F-BF-AF-2C-4B-5B-EE-11-11-A2" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 5, "aiden@feest.ca", "Garry Kuhn", false, "D3-50-70-F4-F2-E1-32-39-0B-B7-83-85-13-11-05-F6-98-BE-D0-ED-F4-49-8F-E4-52-D8-E7-99-D9-5D-55-74-E2-17-CB-58-13-EA-74-A8-49-4F-36-1F-EC-B8-FF-7D-78-08-CD-C0-43-3A-94-A2-F8-89-D5-A1-53-C6-47-1C" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 6, "gudrun@gottlieb.com", "Ervin Hintz", false, "7D-59-50-17-BE-A2-BA-BC-DB-E0-51-1F-76-C4-54-25-BF-97-CF-C4-A6-C3-85-B3-BB-50-10-D2-E9-5F-B0-5C-CE-AB-B0-FA-B4-2B-D6-09-FA-E9-8F-B1-CB-5D-C9-1E-BC-74-8E-1C-2B-66-EA-E7-B3-77-D9-1C-6A-DC-3A-2A" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 7, "sam_treutel@abbott.ca", "Jade Amira Ortiz IV", false, "E2-81-1D-A7-05-E3-66-41-79-0B-A7-37-88-D5-91-C7-4C-35-2E-48-A5-0F-9A-94-91-48-F9-4A-94-F8-BD-AE-2D-B7-43-3B-39-AE-80-DF-F5-42-8B-B1-C8-2E-42-49-01-30-FE-BC-AC-42-10-F0-BF-78-88-AE-82-78-4A-20" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 8, "thad.murphy@wyman.co.uk", "Ryan Kirlin", false, "C5-B5-6F-FE-54-7D-96-E2-A8-CC-6E-4F-83-9F-5A-D2-B9-B8-22-2C-6D-6D-3D-DE-89-9A-64-75-5D-70-E2-EB-EE-F6-38-E1-A0-B2-39-9C-06-9C-AF-98-6C-12-72-91-42-3D-AB-ED-D4-A0-1B-27-F7-9D-E6-A3-BF-D1-22-22" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 9, "jamar_zieme@baumbach.biz", "Gerda Lance Monahan Sr.", false, "0F-D5-D8-BB-95-A2-67-8C-3A-72-2B-98-51-40-F0-24-17-C7-0A-FC-79-1A-CB-2A-7D-EB-1C-04-9E-E2-D1-CF-6D-85-46-60-D6-6C-6A-EB-07-D2-EF-0C-67-FD-CF-81-81-83-B5-DA-77-AB-4E-2F-7F-77-60-76-1D-C8-93-B8" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 10, "pascale_carter@sanford.uk", "Sydnie Goldner", false, "8C-48-70-BB-96-8D-93-F4-DE-1E-2C-AA-1D-02-CD-99-39-C4-25-A3-61-24-FD-77-5A-B2-45-24-89-C9-95-3E-D5-9B-15-01-67-17-66-57-D8-2E-DC-98-B0-83-72-8F-0C-B6-6A-51-BB-8B-07-0C-8D-9C-C4-50-1D-3C-5C-A7" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 11, "lewis_strosin@jakubowski.biz", "Nyah Lesch", false, "4E-C1-7D-8F-15-41-28-DF-2C-5E-E9-5E-28-13-9C-16-E7-27-86-CE-6F-85-6D-52-ED-21-13-1B-3A-D9-15-A5-42-5B-53-10-EB-DF-DB-F3-E8-F5-0D-BB-D1-D4-BD-73-C1-8D-4B-0A-41-1C-A4-45-AD-EE-E1-12-AA-60-75-71" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 12, "hayden_auer@ledner.uk", "Anibal Schuppe", false, "25-51-B1-2F-AA-B9-15-17-F4-B6-DA-9E-E6-28-45-9B-87-8F-8A-D3-FF-77-55-27-84-AD-32-41-D4-F1-3C-2E-AB-2D-E9-F8-66-AD-58-80-F5-A1-D0-A2-1F-D4-0F-9E-05-F9-31-12-78-04-3E-2B-77-CC-DB-66-8D-1D-F7-55" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 13, "wilford@hilllpurdy.uk", "Prof. Freddy Bert Satterfield", false, "DD-86-8D-38-15-CF-92-71-47-F1-10-69-0E-AC-37-47-D0-A8-E4-8F-6D-6E-06-17-EF-B3-26-CC-5E-8C-04-9E-4D-FC-88-B0-C2-18-FB-3C-0B-FA-3A-CB-10-C0-85-76-BF-7B-E5-21-11-5E-51-67-D1-75-C1-00-C9-06-08-26" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 14, "zack.kris@leuschke.name", "Ms. Angelita Chris Gutkowski Sr.", false, "39-D0-9F-DD-CD-71-4A-F0-DC-C5-35-34-DB-53-64-98-A6-AE-D9-29-D7-5D-32-61-82-66-EE-82-DA-97-24-86-D5-2F-C1-97-42-4D-6F-E0-E8-B8-6F-3D-A5-EE-A0-60-E6-B5-FC-13-83-59-C3-23-E4-78-33-15-E7-E1-3E-50" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 15, "kelley@bruenkuphal.us", "Felipe Feest", false, "E0-AE-E0-4B-85-BA-5A-97-9F-E8-1F-C8-9E-5B-CF-1A-99-66-8F-76-28-3B-52-E3-80-F7-6A-41-D6-D8-A3-56-F6-70-2E-E3-37-AE-2E-11-19-20-61-E6-91-EE-89-91-3D-BC-B0-FD-DE-50-AD-5B-DA-46-87-18-77-BE-A1-31" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 16, "madison_macejkovic@kertzmannrice.uk", "Peter Loyal Schaefer MD", false, "0E-89-38-DD-A1-4B-BD-21-05-B1-08-57-96-3E-A5-FF-A4-54-C1-88-2C-90-5D-8C-0B-73-11-D3-5C-9B-E8-4C-0D-43-6E-BB-2A-85-D4-25-5A-FC-58-FB-23-CE-9A-8D-13-5F-FE-DC-D6-A7-73-82-07-6A-E6-8C-A0-FB-00-50" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 17, "amie@stroman.biz", "Prof. Marguerite Goldner", false, "3B-6C-9D-B9-BD-DC-F2-6A-77-F0-2C-D0-12-5B-44-F3-72-92-3C-40-76-2D-13-C2-2E-94-3A-AE-FD-50-39-94-67-F9-7D-C9-3A-B0-5E-7E-DE-4B-6A-B6-EB-54-31-07-68-1F-E3-AF-E2-7D-54-97-A8-3C-1F-79-05-E7-B6-95" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 18, "lily.grant@rueckerrolfson.ca", "Abagail Boyer", false, "BA-8F-C7-32-A9-37-10-E5-8E-F1-1A-24-A4-E8-AF-EB-8D-E8-68-35-F7-E7-93-EA-90-85-BE-3F-59-A8-B8-8E-7A-F2-B8-49-D0-36-C3-B1-07-FF-90-6F-C8-6D-25-CF-C9-9D-44-89-AA-82-68-B5-30-F8-F4-CF-94-78-B9-33" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 19, "seamus.rice@marvin.us", "Lysanne Dicki", false, "B1-A1-4D-4E-91-61-91-F3-6E-82-ED-21-95-EF-82-CC-1B-06-CE-09-43-E3-42-D1-A9-F2-6B-68-37-07-11-31-A5-65-C5-A6-7D-7F-EE-EE-2C-29-D0-58-1A-C6-D9-D3-F9-02-3A-1B-29-04-36-48-E8-0D-6B-C5-C5-02-1F-ED" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 20, "donny_mitchell@collins.com", "Orville Carolina Swaniawski Jr.", false, "9E-FB-CC-E0-CF-9D-9E-4F-52-2D-A8-85-1C-CC-2E-2D-A1-CA-5A-89-EB-1D-80-B4-D4-A1-67-D0-04-EA-97-59-98-9A-E8-9E-10-49-1E-68-BA-6B-9D-A6-7E-CC-7A-87-C5-D6-59-6B-9F-06-AB-CF-A3-F6-EB-31-BC-8F-AA-05" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 21, "janis.johns@shanahanpfeffer.biz", "Archibald Bartoletti", false, "AE-69-7A-58-7E-BE-D4-F7-E5-6C-55-E4-7F-19-6C-72-7E-D7-3B-C4-57-75-2B-52-EA-D0-DC-32-EE-AB-A6-69-2D-4F-19-CF-23-B7-59-C9-19-90-25-C3-41-31-4F-CC-AA-94-D8-B6-E7-6F-D0-E6-62-18-B2-D3-71-38-E8-34" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 22, "paxton.ernser@reichel.info", "Wilhelmine Windler", false, "0E-17-67-00-1F-DF-E5-51-6B-83-82-12-82-63-4F-1D-33-9C-33-52-3F-43-78-50-DD-E1-E9-62-E2-23-62-55-B5-F0-59-A2-8C-A1-5B-4A-AA-B0-61-17-C2-8D-0F-53-1C-74-DE-CD-94-6E-D9-48-0B-0C-3B-E2-16-8B-F2-CC" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 23, "jaunita_ratke@mantejast.name", "Ericka Lockman", false, "83-AD-F2-9E-95-82-DD-BF-87-BE-11-2A-69-2D-C2-E6-9C-A1-62-E4-2C-CA-23-F7-22-CE-A1-B7-E4-38-BF-03-E9-60-9D-E1-7B-89-3B-22-01-59-48-73-F5-AB-91-7D-B8-B3-88-A7-0C-2B-1C-76-DE-C9-8A-89-20-EE-C8-8F" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 24, "albert_kovacek@lebsack.com", "Prof. Hertha Heathcote III", false, "45-A5-CF-A6-0A-D4-7B-7F-65-F9-7B-B9-74-57-53-E7-BA-B3-4D-E4-8A-83-20-C6-A3-1E-B5-18-1E-B9-8A-55-32-CE-80-A9-7C-D1-E8-4E-FD-E1-98-76-49-51-07-C4-C5-18-6A-25-6A-9A-EE-8E-21-59-F3-B3-E2-CA-E7-4F" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 25, "maximo_waelchi@jaskolski.biz", "Mohamed West", false, "C6-8F-A6-F8-8F-D0-64-C5-40-F4-80-1C-49-42-A9-85-0A-47-C2-2D-1E-BC-65-DC-C6-E7-F7-EB-9F-D7-A2-3E-10-CC-72-DF-7C-3C-C2-F6-2F-9A-05-4B-16-81-2C-B8-5F-07-F1-9B-1C-74-C8-40-34-98-C6-7A-43-CE-ED-6B" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 26, "dax_lueilwitz@heathcotelesch.us", "Elta Champlin", false, "F5-32-B5-50-2E-08-C1-D3-6A-B8-96-32-2A-A3-FD-E9-2C-4E-47-A3-CD-1E-1A-C0-E5-CE-63-88-2D-D2-FD-2F-D5-37-C6-27-74-FA-FE-3B-D0-D6-A5-2C-7E-BF-8C-87-AC-61-E7-0F-74-87-D0-1A-B3-3E-7D-F0-6F-2D-8F-2D" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 27, "jamar.wilderman@donnelly.info", "Fausto Wintheiser", false, "DD-88-C5-D5-F8-8B-BE-93-4C-66-D5-5D-39-23-B8-69-14-3E-DB-40-E8-8C-F1-DB-78-3C-95-86-BB-F9-8D-8A-DA-9E-76-C3-61-1C-60-C6-72-CB-B1-16-34-52-03-C3-24-52-91-24-73-00-F8-02-39-66-66-90-DE-E4-40-C1" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 28, "foster@morissettecorkery.info", "Miss Fred Ardith Anderson", false, "29-0E-A0-E8-9B-01-5E-5B-B9-E6-74-E0-8C-5F-7B-F6-57-AB-E7-93-B5-33-82-52-47-8C-EB-B5-03-9F-E0-F7-14-6E-00-14-74-28-76-BF-DC-E5-23-22-26-19-A5-39-E1-F0-F4-58-A9-5D-00-42-03-2A-74-24-53-D7-6D-5E" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 29, "arvel_shanahan@skiles.uk", "Antonietta Windler", false, "65-B3-EF-BE-C8-01-DB-21-66-7C-6D-15-23-CF-A9-C8-CE-6B-A6-43-7C-A7-3C-F3-68-86-AC-97-F4-90-B1-F8-19-0B-88-BA-2A-7F-BA-85-94-07-34-B1-35-32-7C-55-C0-24-69-58-28-0F-C3-24-27-EC-FE-99-B2-D7-41-9F" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FullName", "IsLogged", "PasswordHash" },
                values: new object[] { 30, "maymie@braun.info", "Verna Violette Johns IV", false, "78-26-37-72-0B-3B-FD-05-C0-64-20-F3-C7-7F-36-98-A0-54-91-6C-24-C4-6D-6B-E4-F0-73-4C-BC-AC-6D-8C-89-F1-8D-2D-9B-F0-2B-AE-69-CD-67-64-CB-C7-24-FC-5C-BB-3E-07-47-4D-BF-6B-02-46-49-B1-4D-9A-8B-23" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 1, "Layne Daugherty", false, "64-47-71-9C-48-DE-94-FD-F0-99-B6-48-81-B6-21-7E-02-CD-56-CF-A9-B8-14-64-9E-84-FC-21-77-42-9B-09-A5-EE-0D-FC-DF-48-E8-C7-1E-99-0E-73-8E-BF-8C-D1-DD-E4-8D-A1-94-93-C5-5E-3B-07-3F-76-EC-CC-A6-44", "Frontend developer", "oscar" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 2, "Rupert Vandervort", false, "6C-A6-9D-41-B7-86-ED-BC-1B-8E-5C-6D-3B-C2-8C-EC-F3-24-70-7A-83-1E-42-A7-BE-2F-D9-36-17-FF-18-E5-67-EE-1C-DB-95-E7-FB-68-F8-BE-E7-F4-23-E9-3C-9B-29-E0-9D-2A-21-B2-3B-0D-65-E5-B6-A9-A3-D5-FA-F9", "Backend developer", "sebastian" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 3, "Davon McDermott", false, "AC-F3-73-87-F7-03-99-11-DD-D2-D5-B0-C8-B4-C6-B0-E0-A4-57-90-9E-24-3B-40-DC-21-11-5D-A2-00-D3-AE-C4-F9-40-02-B5-63-70-A0-EA-14-7B-47-DC-F6-09-84-B8-2D-44-94-69-E1-88-41-44-49-7C-8D-1F-F2-69-F8", "Backend developer", "rollin" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 4, "Jaydon Runolfsson", false, "D8-AA-E4-62-18-F9-CC-D9-9A-F5-D6-64-36-99-EC-03-86-1E-2D-E0-AF-7A-17-5E-AA-42-FB-6C-0B-8B-60-AC-0B-5F-24-79-9C-EA-49-19-CF-CC-91-64-D4-AB-02-5C-63-FC-3E-7F-54-BB-7F-21-68-3B-40-E0-3B-21-C8-39", "Tester", "arlene.towne" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 5, "Sydnie Terry", false, "A7-C3-5E-32-E3-E5-62-E1-AD-20-F9-3C-D0-28-81-D3-2E-68-34-92-D7-D9-CC-2F-0C-07-C5-27-AB-56-71-A9-0B-F3-5C-9C-3F-5F-7D-16-05-73-05-F0-12-C6-CF-C1-73-C8-EA-A2-8F-C5-4C-61-19-4E-53-6E-D2-6B-8B-49", "Tester", "abraham" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 6, "Kelvin Langosh", false, "36-26-8A-31-BD-61-77-42-1A-EC-F4-27-FA-CA-10-5B-AA-FF-5A-A8-BB-1A-05-A4-3A-1E-FE-4A-E0-2B-A3-98-79-94-97-CB-F9-9B-E3-7E-26-81-10-0E-43-C4-0E-E8-DC-9B-8D-87-66-4D-0D-15-DC-5E-06-6D-D8-A3-53-CE", "DevOPS", "guadalupe" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 7, "Annabelle Kirlin", false, "3C-51-32-CE-E1-1C-45-04-BC-CF-DA-25-73-31-69-EF-FA-ED-5E-E0-5F-69-9A-80-94-37-FD-52-83-89-EF-21-DD-0E-CE-E1-CD-54-32-10-CE-3D-6D-2D-2E-48-1F-7B-5A-BF-38-3E-B4-E6-EA-6D-AF-14-2E-40-B1-09-E3-0F", "Frontend developer", "earnest_larson" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 8, "Mauricio Simonis", false, "02-F7-B6-E1-E4-9D-4E-7A-37-53-C2-C9-84-15-43-B2-9C-8F-8D-34-33-B7-A2-3F-79-66-96-55-A8-70-55-3E-89-7A-A6-17-78-FD-64-F5-2D-A3-CA-A0-D8-60-5B-07-71-EA-15-B5-D7-56-DC-A0-F9-B6-0A-D0-F4-B2-BB-0C", "DevOPS", "nasir_goyette" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 9, "Zaria Feeney", false, "C6-04-7A-13-01-B7-F7-51-A7-8D-A7-4F-6A-5C-75-5D-2C-CB-A4-37-F5-13-BA-00-E1-5D-C9-2E-8E-23-52-2F-63-B8-81-51-B8-92-87-93-3B-78-88-32-B2-3A-E0-B7-C3-03-09-F5-80-0F-10-18-ED-69-ED-25-E6-CA-49-02", "DevOPS", "hermina" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 10, "Roel Abshire", false, "E4-69-10-08-2F-57-00-5F-93-8B-1A-84-FC-6B-0B-C5-F6-31-BC-EB-94-ED-67-73-3A-52-88-60-A9-F5-4A-7D-46-CE-F8-91-53-D9-A9-39-D5-E5-BF-88-BC-76-E1-AB-F1-0E-9D-A1-01-43-25-2D-47-C9-4F-75-16-B8-AC-81", "Tester", "mabelle" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 11, "Hassan Heaney", false, "84-48-C7-0E-B5-F6-45-F0-5B-DC-E6-B3-20-E4-0A-5A-F4-5E-C9-1A-10-D2-97-A6-9E-CE-CC-7D-D3-14-D5-52-96-6E-7A-C1-17-7E-25-B7-3E-FD-BC-60-F9-14-2E-FD-D7-9F-17-FD-F4-50-60-5B-22-3B-E6-BE-16-29-64-AE", "Tester", "francesca" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 12, "Tamara Padberg", false, "E6-9E-21-4A-D4-FF-89-F2-F5-D0-0C-DA-94-47-94-BF-71-24-79-4F-D1-80-ED-6D-E0-0C-D3-E9-B4-E0-A5-C2-01-AE-15-32-01-55-E0-DF-07-91-63-35-6A-BD-6F-06-7E-C9-FD-69-D9-2E-33-EF-0F-EA-6D-17-7D-49-90-DC", "Frontend developer", "tyra_lesch" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 13, "Milo Bruen", false, "A6-AB-29-FA-D8-0D-B6-FA-9A-2F-38-B5-04-80-BA-A5-81-40-3B-BD-1A-8A-36-1F-A6-C9-0B-EC-98-FD-D2-78-9C-15-A4-61-32-E7-DF-B1-F6-AA-36-4F-FB-02-4C-20-EA-5C-0F-C2-58-2E-25-6A-5B-6D-5C-EC-44-5F-73-C8", "DevOPS", "cleve" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 14, "Virginie Jenkins", false, "C2-9D-47-94-FE-59-33-2A-3F-05-99-F5-25-F0-29-42-D6-B9-D6-E9-A3-39-5A-FD-F5-2A-5F-2F-55-32-FE-47-53-17-61-04-50-F9-0B-6D-ED-CA-3B-C5-FE-3A-EE-C4-4F-6E-FC-F4-B6-94-DB-59-27-FC-D0-B4-0C-D6-21-F7", "Frontend developer", "andres" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 15, "Suzanne Olson", false, "21-67-C0-7B-8D-19-EA-A8-2A-61-C1-69-AD-CB-A2-EA-5C-99-C0-48-18-23-59-DC-50-C7-EB-D0-EF-7D-F2-BA-0C-ED-2A-93-C8-96-2B-07-A4-F9-E6-F7-2D-C2-84-AA-BE-4E-0B-DD-2D-23-4F-0F-13-70-1E-08-42-29-E8-53", "Tester", "adele.schmeler" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 16, "Amara Koss", false, "4F-04-27-74-E5-99-5F-1B-5A-E1-6C-19-BA-97-F7-DB-93-AF-C8-03-B6-61-94-AA-16-10-7F-2B-94-4B-8F-68-C7-C3-F9-68-38-41-4B-CD-BD-C7-FB-E1-A8-90-77-CC-CD-A3-E9-B0-E6-7B-40-D8-2B-58-1A-3E-6E-0A-BB-77", "DevOPS", "damaris.parisian" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 17, "Jaquelin Howell", false, "83-B9-41-E0-92-A3-F5-FC-2E-00-14-5A-3A-7C-28-18-36-F5-AB-C7-CB-97-8E-4E-44-AD-C0-0E-4D-CA-AB-6B-15-75-B8-D1-8D-7A-96-21-C6-7E-20-46-7F-C3-E6-78-90-21-C5-E8-12-B6-96-AC-4D-96-10-74-F4-FF-EA-3A", "Frontend developer", "declan.hudson" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 18, "Roma Greenholt", false, "25-84-73-24-20-81-2A-A4-73-E8-D5-A6-F6-6E-BC-22-28-7F-5E-43-7E-C9-47-C4-46-C5-D4-D5-71-F0-AF-FB-16-BA-4F-2C-51-33-A0-CF-5D-A3-A8-95-FC-5B-3A-3F-EF-42-F4-59-81-A0-1B-17-2A-E9-E3-C8-63-0C-AD-5F", "DevOPS", "curtis" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 19, "Darrin Dare", false, "9B-52-03-6F-1C-A2-34-44-9D-2B-01-69-87-F4-E5-5B-41-C6-C3-85-5C-00-AB-A7-39-D9-CB-56-3D-0D-DC-F3-61-78-81-80-A9-81-F9-0A-CB-1A-52-DC-8C-53-B9-D6-4A-4B-B2-CF-57-28-43-BE-BA-3F-FF-DA-F5-9C-F3-A6", "Tester", "novella.schmidt" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 20, "Mortimer Runte", false, "4C-1C-71-AB-0E-6B-31-D1-EF-0E-0B-2C-3F-6C-72-02-A0-0B-0B-3B-28-91-93-0A-7A-80-57-44-7C-1E-77-E4-39-64-22-80-4F-C0-C9-51-E2-64-7C-DD-31-FC-56-D9-FA-89-C2-78-AB-8E-BA-5E-24-13-72-0C-26-26-BE-0C", "DevOPS", "christ.blanda" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 21, "Kane McKenzie", false, "4C-7B-47-10-D7-B0-DE-80-DC-A7-49-C0-75-20-6A-46-25-1B-CD-65-EE-B5-07-7D-9F-C5-87-C7-79-4C-C5-83-F5-45-0A-E4-51-40-EE-0A-5D-25-6F-39-6B-60-D9-1F-9E-F9-D1-87-E3-52-60-B7-FD-9D-23-EA-C8-9C-23-C0", "Frontend developer", "aaron.zboncak" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 22, "Lamont Hickle", false, "EA-FC-6D-0F-C6-D8-40-8D-08-1C-CA-A7-7E-08-C9-E1-AD-FA-BB-9A-A6-2D-5A-54-54-E8-2A-E6-50-F3-91-EF-A7-2D-EC-62-B7-56-A1-43-EA-88-0F-06-EC-6F-00-C6-D0-32-93-1A-A6-65-E5-8F-9D-0A-98-AF-4C-46-A7-F4", "Frontend developer", "sophie_schmitt" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 23, "Aiyana Schoen", false, "F9-F6-4D-66-FB-A4-FC-60-C7-41-3E-91-C1-DB-F3-93-2B-30-51-57-D2-E2-FF-92-89-6B-33-FE-46-6D-BD-F1-0A-69-2A-AE-31-5A-25-73-AD-D4-49-73-59-60-71-5A-16-98-98-82-14-72-F2-80-86-FC-ED-82-79-54-D3-E4", "Tester", "ernesto_walsh" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 24, "Abbey Koss", false, "B4-A9-47-3A-63-5A-C3-1F-A8-98-FB-33-32-CE-3E-A8-BE-C7-21-77-8B-3D-C6-16-62-17-BF-7C-EC-27-67-C1-1E-91-30-44-2C-D9-00-25-03-12-A6-48-8C-9A-3E-4C-D4-48-D2-27-5F-CE-B6-2E-CB-A8-F0-48-C0-AA-04-5F", "Backend developer", "lonzo" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 25, "Cary Waelchi", false, "3A-C5-B9-29-A2-2A-1B-3B-AB-3E-37-C8-02-16-7C-4D-65-AF-B3-29-95-FC-C4-26-F3-54-67-47-B1-D8-47-8F-E3-97-88-AD-B0-AE-37-3B-3A-05-12-52-A7-03-BC-EB-9A-56-80-44-DE-12-1D-F7-30-C9-31-89-86-66-B6-A2", "Tester", "logan" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 26, "Roy Swaniawski", false, "D7-DC-36-16-54-BA-A5-9A-81-0F-60-B0-63-8F-19-6A-D3-ED-3B-FE-6E-F8-99-0E-21-B2-91-21-A8-EB-4B-54-FA-8E-6F-38-EE-14-60-37-BF-E9-8C-B2-49-F2-22-96-64-DC-DA-47-96-07-33-61-16-EE-AF-D3-26-A9-91-4E", "Tester", "rodrick.lynch" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 27, "Lauriane Kautzer", false, "A9-72-D5-6E-C0-06-AF-8A-A5-3B-68-63-EE-43-98-9D-5B-23-AB-BA-7F-5B-1A-E2-13-B7-8B-CD-34-ED-00-9A-70-B0-3D-96-6E-75-B5-F4-AC-82-4F-D2-30-5E-D0-75-F0-43-3F-D3-35-CB-1A-CD-E6-BB-99-BC-93-2E-BB-75", "Backend developer", "heloise" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 28, "Jennyfer Heller", false, "F1-55-22-9F-BC-C4-25-22-99-CD-77-3B-6B-3D-BA-C3-91-E0-06-35-B0-6C-15-D4-61-A7-26-3B-29-A3-72-66-66-AF-7F-40-EE-60-34-7B-EB-7B-B2-55-01-C3-99-25-A1-B2-A1-45-66-E6-63-A4-44-94-42-4C-FB-2D-D7-76", "Backend developer", "amara" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 29, "Darrion Wolf", false, "76-2C-2E-E5-74-29-79-7C-E1-55-B1-B1-64-90-46-23-BD-B6-EA-FA-CE-4C-C0-1D-07-76-B2-0C-3E-F7-06-38-71-86-0F-17-48-28-9E-EC-2E-57-DE-A3-C7-3E-FD-37-B5-6B-C8-12-7B-19-98-50-10-CE-4A-B2-A0-6A-EF-9D", "DevOPS", "albert_ledner" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 30, "Gerson Schinner", false, "A2-6E-77-93-BD-31-A4-E0-C6-9C-26-99-9F-49-D9-C4-5D-3E-87-46-CC-83-E8-B9-89-E2-86-D8-51-F7-DC-68-74-13-39-5E-98-B0-7D-2C-96-DA-21-8B-8C-60-F9-28-4D-64-0B-71-E0-F7-89-C1-FE-D6-1D-9D-E2-36-8F-50", "Tester", "emanuel" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 1, "Manager1", false, "92-A8-81-05-1A-0D-26-BA-0F-E4-A6-5C-B1-03-9C-10-E1-87-18-C6-85-91-EF-B6-AF-BF-88-3B-67-2A-32-8B-C8-BA-8C-13-FD-AA-90-EE-DC-01-8C-28-07-82-CB-BD-2A-84-2A-CB-D9-A5-F3-B8-96-50-12-A1-BA-48-92-34", "Manager", "Manager1" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Position", "UserName" },
                values: new object[] { 2, "Manager2", false, "DB-C5-5B-65-5D-E7-95-23-A9-F1-81-7A-9C-26-62-40-92-D9-2D-6F-42-C2-35-DD-9B-74-3F-34-9A-DC-4B-83-2E-1B-ED-4B-50-ED-B6-34-E5-2D-3A-97-93-24-B8-7E-DB-07-30-8F-93-B6-E4-0A-77-E8-9F-7A-0F-AA-59-CC", "Manager", "Manager2" });

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_UserName",
                table: "Administrators",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Email",
                table: "Clients",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Developers_UserName",
                table: "Developers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserName",
                table: "Managers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProjectId",
                table: "Orders",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamId",
                table: "Projects",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLeaders_UserName",
                table: "TeamLeaders",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_UserName",
                table: "TeamMembers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamLeaderId",
                table: "Teams",
                column: "TeamLeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "WorkTasks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "TeamLeaders");
        }
    }
}
