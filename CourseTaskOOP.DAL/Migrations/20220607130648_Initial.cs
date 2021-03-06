using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseTaskOOP.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
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
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    IsLogged = table.Column<bool>(type: "INTEGER", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 1, "Mr. Ralph Kris I", false, "BC-1A-4C-B5-88-77-DA-14-02-91-85-36-0C-59-CF-6F-56-FF-18-EA-0B-F2-93-1A-86-C9-5A-86-43-6C-16-91-BA-6E-13-3C-C6-8E-B5-73-33-F1-7C-B4-3B-66-6F-37-EC-78-A5-DD-54-1F-E3-31-E3-E2-9D-16-A6-51-D7-3C", "Client", "gerda" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 2, "Shannon Cassin", false, "A3-54-E0-6B-97-8D-C6-8C-BC-93-B8-FC-52-D7-13-56-46-D9-AA-89-0B-4F-DD-59-75-2C-BD-6F-B7-51-19-31-1F-88-33-AE-7D-79-01-BB-7F-56-D7-61-44-7F-E5-B8-5F-A0-90-4A-D7-82-0E-CC-BE-53-38-39-48-92-BC-C4", "Client", "dorian_doyle" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 3, "Kristina Wunsch", false, "60-42-2A-D7-AC-A8-D3-C5-0D-AB-47-5A-FE-68-C6-12-79-CB-FF-20-E0-AD-89-52-E5-AD-60-7B-C0-1C-23-38-F8-24-8B-87-44-23-68-0D-CF-69-5E-A3-A7-DB-80-12-D9-A6-EE-6C-4A-7D-DB-50-0B-B5-B0-47-0A-84-E3-3E", "Client", "jesse.bashirian" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 4, "Hayden Feil", false, "E7-95-A4-14-C4-FF-31-EB-55-89-D0-CB-9B-24-63-17-CE-53-D4-AB-AD-9B-50-44-BB-2E-1B-8D-67-8D-19-44-42-B7-F8-5E-89-C7-D8-E3-6D-8C-A5-09-D2-6A-A4-CC-8C-EB-D9-8E-EF-F5-7F-BF-AF-2C-4B-5B-EE-11-11-A2", "Client", "ryleigh.lesch" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 5, "Emory Walsh", false, "D3-50-70-F4-F2-E1-32-39-0B-B7-83-85-13-11-05-F6-98-BE-D0-ED-F4-49-8F-E4-52-D8-E7-99-D9-5D-55-74-E2-17-CB-58-13-EA-74-A8-49-4F-36-1F-EC-B8-FF-7D-78-08-CD-C0-43-3A-94-A2-F8-89-D5-A1-53-C6-47-1C", "Client", "ahmed_renner" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 6, "Laury Braun", false, "7D-59-50-17-BE-A2-BA-BC-DB-E0-51-1F-76-C4-54-25-BF-97-CF-C4-A6-C3-85-B3-BB-50-10-D2-E9-5F-B0-5C-CE-AB-B0-FA-B4-2B-D6-09-FA-E9-8F-B1-CB-5D-C9-1E-BC-74-8E-1C-2B-66-EA-E7-B3-77-D9-1C-6A-DC-3A-2A", "Client", "ollie" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 7, "Mr. Drew Krajcik", false, "E2-81-1D-A7-05-E3-66-41-79-0B-A7-37-88-D5-91-C7-4C-35-2E-48-A5-0F-9A-94-91-48-F9-4A-94-F8-BD-AE-2D-B7-43-3B-39-AE-80-DF-F5-42-8B-B1-C8-2E-42-49-01-30-FE-BC-AC-42-10-F0-BF-78-88-AE-82-78-4A-20", "Client", "cathy_stanton" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 8, "Prof. Valentine Hannah Wilkinson", false, "C5-B5-6F-FE-54-7D-96-E2-A8-CC-6E-4F-83-9F-5A-D2-B9-B8-22-2C-6D-6D-3D-DE-89-9A-64-75-5D-70-E2-EB-EE-F6-38-E1-A0-B2-39-9C-06-9C-AF-98-6C-12-72-91-42-3D-AB-ED-D4-A0-1B-27-F7-9D-E6-A3-BF-D1-22-22", "Client", "golda_jaskolski" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 9, "Freda Kuhic", false, "0F-D5-D8-BB-95-A2-67-8C-3A-72-2B-98-51-40-F0-24-17-C7-0A-FC-79-1A-CB-2A-7D-EB-1C-04-9E-E2-D1-CF-6D-85-46-60-D6-6C-6A-EB-07-D2-EF-0C-67-FD-CF-81-81-83-B5-DA-77-AB-4E-2F-7F-77-60-76-1D-C8-93-B8", "Client", "jeffry_daugherty" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 10, "Madilyn Soledad Schuster II", false, "8C-48-70-BB-96-8D-93-F4-DE-1E-2C-AA-1D-02-CD-99-39-C4-25-A3-61-24-FD-77-5A-B2-45-24-89-C9-95-3E-D5-9B-15-01-67-17-66-57-D8-2E-DC-98-B0-83-72-8F-0C-B6-6A-51-BB-8B-07-0C-8D-9C-C4-50-1D-3C-5C-A7", "Client", "romaine" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 11, "Yasmin Fadel", false, "4E-C1-7D-8F-15-41-28-DF-2C-5E-E9-5E-28-13-9C-16-E7-27-86-CE-6F-85-6D-52-ED-21-13-1B-3A-D9-15-A5-42-5B-53-10-EB-DF-DB-F3-E8-F5-0D-BB-D1-D4-BD-73-C1-8D-4B-0A-41-1C-A4-45-AD-EE-E1-12-AA-60-75-71", "Client", "rocky_hodkiewicz" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 12, "Deontae Wisozk", false, "25-51-B1-2F-AA-B9-15-17-F4-B6-DA-9E-E6-28-45-9B-87-8F-8A-D3-FF-77-55-27-84-AD-32-41-D4-F1-3C-2E-AB-2D-E9-F8-66-AD-58-80-F5-A1-D0-A2-1F-D4-0F-9E-05-F9-31-12-78-04-3E-2B-77-CC-DB-66-8D-1D-F7-55", "Client", "justen" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 13, "Isom Adams", false, "DD-86-8D-38-15-CF-92-71-47-F1-10-69-0E-AC-37-47-D0-A8-E4-8F-6D-6E-06-17-EF-B3-26-CC-5E-8C-04-9E-4D-FC-88-B0-C2-18-FB-3C-0B-FA-3A-CB-10-C0-85-76-BF-7B-E5-21-11-5E-51-67-D1-75-C1-00-C9-06-08-26", "Client", "roma" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 14, "Layne Jewess", false, "39-D0-9F-DD-CD-71-4A-F0-DC-C5-35-34-DB-53-64-98-A6-AE-D9-29-D7-5D-32-61-82-66-EE-82-DA-97-24-86-D5-2F-C1-97-42-4D-6F-E0-E8-B8-6F-3D-A5-EE-A0-60-E6-B5-FC-13-83-59-C3-23-E4-78-33-15-E7-E1-3E-50", "Client", "elmira_champlin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 15, "Damian Ratke", false, "E0-AE-E0-4B-85-BA-5A-97-9F-E8-1F-C8-9E-5B-CF-1A-99-66-8F-76-28-3B-52-E3-80-F7-6A-41-D6-D8-A3-56-F6-70-2E-E3-37-AE-2E-11-19-20-61-E6-91-EE-89-91-3D-BC-B0-FD-DE-50-AD-5B-DA-46-87-18-77-BE-A1-31", "Client", "emanuel" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 16, "Kamryn Chaya Johnston II", false, "0E-89-38-DD-A1-4B-BD-21-05-B1-08-57-96-3E-A5-FF-A4-54-C1-88-2C-90-5D-8C-0B-73-11-D3-5C-9B-E8-4C-0D-43-6E-BB-2A-85-D4-25-5A-FC-58-FB-23-CE-9A-8D-13-5F-FE-DC-D6-A7-73-82-07-6A-E6-8C-A0-FB-00-50", "Client", "brigitte_gerlach" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 17, "Collin Dietrich", false, "3B-6C-9D-B9-BD-DC-F2-6A-77-F0-2C-D0-12-5B-44-F3-72-92-3C-40-76-2D-13-C2-2E-94-3A-AE-FD-50-39-94-67-F9-7D-C9-3A-B0-5E-7E-DE-4B-6A-B6-EB-54-31-07-68-1F-E3-AF-E2-7D-54-97-A8-3C-1F-79-05-E7-B6-95", "Client", "rusty.crist" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 18, "Delores O'Keefe II", false, "BA-8F-C7-32-A9-37-10-E5-8E-F1-1A-24-A4-E8-AF-EB-8D-E8-68-35-F7-E7-93-EA-90-85-BE-3F-59-A8-B8-8E-7A-F2-B8-49-D0-36-C3-B1-07-FF-90-6F-C8-6D-25-CF-C9-9D-44-89-AA-82-68-B5-30-F8-F4-CF-94-78-B9-33", "Client", "dylan_howell" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 19, "Camron Kenna Ernser V", false, "B1-A1-4D-4E-91-61-91-F3-6E-82-ED-21-95-EF-82-CC-1B-06-CE-09-43-E3-42-D1-A9-F2-6B-68-37-07-11-31-A5-65-C5-A6-7D-7F-EE-EE-2C-29-D0-58-1A-C6-D9-D3-F9-02-3A-1B-29-04-36-48-E8-0D-6B-C5-C5-02-1F-ED", "Client", "andre" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 20, "Armand Stiedemann", false, "9E-FB-CC-E0-CF-9D-9E-4F-52-2D-A8-85-1C-CC-2E-2D-A1-CA-5A-89-EB-1D-80-B4-D4-A1-67-D0-04-EA-97-59-98-9A-E8-9E-10-49-1E-68-BA-6B-9D-A6-7E-CC-7A-87-C5-D6-59-6B-9F-06-AB-CF-A3-F6-EB-31-BC-8F-AA-05", "Client", "amya" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 21, "Enid Carroll", false, "AE-69-7A-58-7E-BE-D4-F7-E5-6C-55-E4-7F-19-6C-72-7E-D7-3B-C4-57-75-2B-52-EA-D0-DC-32-EE-AB-A6-69-2D-4F-19-CF-23-B7-59-C9-19-90-25-C3-41-31-4F-CC-AA-94-D8-B6-E7-6F-D0-E6-62-18-B2-D3-71-38-E8-34", "Client", "kaylie" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 22, "Jermey Hoppe", false, "0E-17-67-00-1F-DF-E5-51-6B-83-82-12-82-63-4F-1D-33-9C-33-52-3F-43-78-50-DD-E1-E9-62-E2-23-62-55-B5-F0-59-A2-8C-A1-5B-4A-AA-B0-61-17-C2-8D-0F-53-1C-74-DE-CD-94-6E-D9-48-0B-0C-3B-E2-16-8B-F2-CC", "Client", "cale.stark" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 23, "Ruthe Spencer", false, "83-AD-F2-9E-95-82-DD-BF-87-BE-11-2A-69-2D-C2-E6-9C-A1-62-E4-2C-CA-23-F7-22-CE-A1-B7-E4-38-BF-03-E9-60-9D-E1-7B-89-3B-22-01-59-48-73-F5-AB-91-7D-B8-B3-88-A7-0C-2B-1C-76-DE-C9-8A-89-20-EE-C8-8F", "Client", "victor.bahringer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 24, "Cassidy Daniel", false, "45-A5-CF-A6-0A-D4-7B-7F-65-F9-7B-B9-74-57-53-E7-BA-B3-4D-E4-8A-83-20-C6-A3-1E-B5-18-1E-B9-8A-55-32-CE-80-A9-7C-D1-E8-4E-FD-E1-98-76-49-51-07-C4-C5-18-6A-25-6A-9A-EE-8E-21-59-F3-B3-E2-CA-E7-4F", "Client", "sheridan.gutmann" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 25, "Sim Casper", false, "C6-8F-A6-F8-8F-D0-64-C5-40-F4-80-1C-49-42-A9-85-0A-47-C2-2D-1E-BC-65-DC-C6-E7-F7-EB-9F-D7-A2-3E-10-CC-72-DF-7C-3C-C2-F6-2F-9A-05-4B-16-81-2C-B8-5F-07-F1-9B-1C-74-C8-40-34-98-C6-7A-43-CE-ED-6B", "Client", "sarai.cronin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 26, "Mr. Rosendo Ruecker", false, "F5-32-B5-50-2E-08-C1-D3-6A-B8-96-32-2A-A3-FD-E9-2C-4E-47-A3-CD-1E-1A-C0-E5-CE-63-88-2D-D2-FD-2F-D5-37-C6-27-74-FA-FE-3B-D0-D6-A5-2C-7E-BF-8C-87-AC-61-E7-0F-74-87-D0-1A-B3-3E-7D-F0-6F-2D-8F-2D", "Client", "johnpaul" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 27, "Leopoldo Feil III", false, "DD-88-C5-D5-F8-8B-BE-93-4C-66-D5-5D-39-23-B8-69-14-3E-DB-40-E8-8C-F1-DB-78-3C-95-86-BB-F9-8D-8A-DA-9E-76-C3-61-1C-60-C6-72-CB-B1-16-34-52-03-C3-24-52-91-24-73-00-F8-02-39-66-66-90-DE-E4-40-C1", "Client", "kaleigh" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 28, "Hector Luettgen", false, "29-0E-A0-E8-9B-01-5E-5B-B9-E6-74-E0-8C-5F-7B-F6-57-AB-E7-93-B5-33-82-52-47-8C-EB-B5-03-9F-E0-F7-14-6E-00-14-74-28-76-BF-DC-E5-23-22-26-19-A5-39-E1-F0-F4-58-A9-5D-00-42-03-2A-74-24-53-D7-6D-5E", "Client", "marguerite.bashirian" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 29, "Jeanne Brakus PhD", false, "65-B3-EF-BE-C8-01-DB-21-66-7C-6D-15-23-CF-A9-C8-CE-6B-A6-43-7C-A7-3C-F3-68-86-AC-97-F4-90-B1-F8-19-0B-88-BA-2A-7F-BA-85-94-07-34-B1-35-32-7C-55-C0-24-69-58-28-0F-C3-24-27-EC-FE-99-B2-D7-41-9F", "Client", "demetris_johnson" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 30, "Ivah O'Kon", false, "78-26-37-72-0B-3B-FD-05-C0-64-20-F3-C7-7F-36-98-A0-54-91-6C-24-C4-6D-6B-E4-F0-73-4C-BC-AC-6D-8C-89-F1-8D-2D-9B-F0-2B-AE-69-CD-67-64-CB-C7-24-FC-5C-BB-3E-07-47-4D-BF-6B-02-46-49-B1-4D-9A-8B-23", "Client", "brent" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 31, "Vickie Roberts", false, "E1-F3-55-9F-02-10-C9-A5-6C-6F-D5-48-0C-F2-C2-7F-AD-2C-24-B7-D3-5A-4D-4E-EE-FE-3B-3D-90-97-B5-3D-1F-EB-FC-74-93-CC-2D-6E-44-95-4A-2D-34-20-AF-EE-A7-CF-AD-66-0E-67-AF-CC-5D-C7-CE-65-23-33-8F-2F", "Developer", "terrence.crooks" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 32, "Stone Gleichner", false, "C5-2B-CC-4F-9F-2D-4E-FA-4E-F1-EB-88-14-4D-0F-DF-AD-85-77-DA-8A-C7-B3-65-F4-9D-31-02-AC-06-FA-C3-5A-BD-58-14-E8-CA-99-6F-C1-3F-1C-02-EF-1F-45-5C-85-DA-EA-ED-1A-AB-5A-9A-81-2D-9A-5B-69-A8-01-33", "Developer", "rosamond.barrows" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 33, "Oral Watsica", false, "96-A6-ED-ED-D2-30-CB-1C-38-B3-17-EC-B4-0B-47-94-51-27-9E-17-BA-AA-97-34-FB-D2-32-D4-1F-74-8C-82-0B-C1-0B-5B-45-8E-03-2B-D1-6D-36-00-97-93-54-35-B2-31-FE-49-44-69-E6-5D-05-1C-41-47-5A-5B-89-5F", "Developer", "justus.murray" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 34, "Isai Barton", false, "F1-3D-A4-0D-C5-39-E6-D3-9A-DD-F7-E1-A3-5F-51-E0-F6-A9-10-C5-BB-BB-C0-4B-26-F8-5A-48-58-4D-C2-F8-86-D0-F0-7A-17-F0-C6-AF-9A-39-1E-39-97-4D-D0-8F-F8-59-5E-E6-83-4D-D0-01-AB-D6-DE-30-C5-DB-55-C8", "Developer", "jacky" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 35, "Ewell Daniel", false, "99-E9-D5-C1-6D-AE-FF-58-4B-46-41-42-A4-23-57-0E-81-FC-57-1A-EB-7D-BE-BC-DC-03-AB-FC-3A-9B-51-7A-0A-09-CE-E8-E0-E0-B9-81-C4-4D-28-F6-22-39-29-24-89-D1-EA-F3-9C-C9-82-AD-90-98-04-B1-B3-AB-2E-46", "Developer", "darrion.ruecker" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 36, "Taylor Wisoky", false, "7D-FE-77-AB-2A-52-F2-DF-56-E3-23-2D-13-10-8A-95-6C-54-5B-36-81-3A-59-88-42-00-BB-61-12-13-84-2B-20-DD-A6-19-E5-46-69-7A-5F-F5-BB-0B-9B-DA-74-99-52-7A-81-46-04-F9-66-C2-34-E5-AE-A7-8F-51-02-21", "Developer", "kaycee.bartell" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 37, "Alysson Schoen", false, "A5-0E-2C-CE-9B-66-AF-F5-0B-A6-7B-6E-BA-1D-C4-E1-BC-7F-99-7B-AA-7F-0C-A2-E0-CE-4A-12-68-71-0A-44-70-5B-18-B5-51-22-95-EE-3D-ED-36-45-2A-18-6E-9E-6A-AA-CC-C8-76-76-00-96-DD-68-C4-E7-CB-3A-61-6C", "Developer", "lukas_jenkins" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 38, "Ewald Pfannerstill", false, "8E-96-A0-30-14-E4-0A-99-1B-C9-36-85-E2-36-51-43-DC-43-F6-C9-A3-71-8D-07-46-ED-5E-F2-3E-D4-D9-74-D9-5C-D1-51-56-BC-40-59-72-4D-0D-15-A6-D1-57-1E-71-29-B9-A9-E9-B5-6B-DD-74-AB-21-CD-D7-63-8D-68", "Developer", "frederik" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 39, "Cecilia Williamson", false, "A6-01-C1-CE-80-ED-F0-C4-CF-50-66-54-A6-9D-FC-DA-56-6E-D9-76-CE-E9-F2-BC-76-E3-22-EF-41-F8-60-6E-3B-DF-07-2A-4C-CA-E8-A1-FB-CC-FB-07-9C-AC-6B-02-DD-8F-DF-6E-DB-CA-3A-35-C4-9D-92-64-8A-23-76-D9", "Developer", "britney" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 40, "Dorothy Moore", false, "84-EA-93-5B-3B-61-93-DA-2A-36-82-FB-BA-E7-9C-FE-28-C4-C3-EF-C7-E4-6D-1C-84-AF-A9-29-5D-08-C4-87-2C-77-3A-2C-3C-4C-DE-33-B0-D4-C3-7F-E9-9B-59-C4-26-83-64-04-3B-71-8F-B6-D3-2D-6B-6C-CD-5F-22-A0", "Developer", "gage.becker" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 41, "Itzel Reynolds", false, "4D-BF-31-F3-E8-7E-7C-7D-41-7D-64-8D-4C-C9-79-69-A4-58-E0-F6-72-B1-65-89-1C-81-84-FE-32-85-88-C5-B7-CF-1E-A5-BB-2A-48-2F-4B-12-05-00-6A-97-5C-5C-3F-CF-82-7A-0B-59-CF-DB-FF-72-BA-44-90-6E-ED-10", "Developer", "shawn" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 42, "Baylee Nitzsche", false, "AA-79-78-A4-6C-5C-E0-0A-3D-F6-1C-E1-79-2A-23-E6-C6-B0-D6-F5-B5-3D-AD-73-22-75-90-B4-EC-D7-A9-8C-E7-21-2A-AB-E6-43-87-88-17-53-D0-5F-56-AF-4C-93-C8-A8-81-DE-F6-A7-5F-60-85-61-7B-85-6E-90-68-BC", "Developer", "eriberto.goldner" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 43, "Julian Klocko", false, "FB-83-8F-EC-8C-40-9A-F8-33-CE-B9-58-9F-1A-2D-14-5A-BD-C7-74-4F-2F-78-AF-84-75-60-F2-10-26-A0-BD-E8-AC-5E-C5-FB-8B-2D-D4-E9-14-F6-FD-F9-C8-48-F5-E4-3D-3C-2B-2F-C4-0A-F0-50-D0-94-4B-8B-52-A0-57", "Developer", "henry" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 44, "Cecelia Kub", false, "DB-BC-46-9D-EB-B2-E4-B7-88-12-56-C3-AE-4E-E8-77-A2-4A-67-8F-65-FC-75-91-C2-59-9F-E8-A5-5C-07-E5-14-30-ED-CE-FD-A6-6B-F5-40-27-EF-93-FA-18-48-53-01-34-E9-07-77-55-57-A1-8B-26-9C-EF-44-C7-E2-CC", "Developer", "jordane_treutel" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 45, "Shanny Spinka", false, "9B-5A-36-18-8D-18-3E-7A-55-90-6B-0A-87-B0-8E-5D-C3-43-E2-39-E2-4D-E7-64-B0-45-12-D9-EC-77-BE-8E-82-F9-A6-A7-33-E7-E4-36-06-A0-3D-95-C8-ED-A6-8E-5E-98-86-F4-16-28-FA-E0-6C-AF-6B-79-FC-92-92-4C", "Developer", "scottie" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 46, "Aniyah Kohler", false, "7B-24-B3-24-41-36-14-90-F6-CB-D6-74-7D-C4-5C-8F-75-22-A9-3B-1F-D3-9D-41-18-41-5E-33-2C-71-1B-CB-15-81-39-F6-25-89-75-AF-71-10-40-09-40-4A-68-D0-0A-83-1C-03-B6-54-45-D9-59-F2-90-FD-B4-13-99-00", "Developer", "madonna" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 47, "Demetrius Eichmann", false, "0A-28-10-23-6D-83-BE-A8-0C-7D-75-AA-44-72-B1-E5-54-4A-AF-5C-01-89-3F-61-CD-07-48-A7-DE-E4-77-87-9D-14-E9-F5-FA-2D-26-EF-F7-C3-EE-B9-C6-56-C3-83-13-E2-92-6F-E0-BF-FE-3F-EC-64-75-CB-89-B1-98-66", "Developer", "leonor" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 48, "Layla Hickle", false, "A5-CE-C6-3B-4E-9C-AB-2F-83-EA-BD-B0-C9-B3-DA-CF-AF-5E-B7-F1-55-7D-3C-29-0E-64-22-12-69-F0-19-DC-1F-D6-40-77-A2-56-98-14-FD-81-E1-FD-5D-E2-19-40-B9-E8-AC-0B-EB-1B-57-B8-46-5B-88-4E-C1-98-58-1D", "Developer", "ezequiel" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 49, "Emily Waelchi", false, "CE-05-42-54-A5-AE-C3-82-5F-2F-F7-D3-3F-B5-1D-25-E1-06-E0-DD-64-58-D4-72-44-41-EF-BE-75-A3-7A-91-26-70-6D-79-3D-1A-F2-6C-8D-45-3C-8D-C6-A6-AC-F9-29-98-B7-77-D4-CD-1A-CC-D9-C6-A0-16-93-B7-31-23", "Developer", "kaley" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 50, "Bette Hegmann", false, "E4-6C-48-83-1F-E0-06-D7-ED-FC-AA-D4-93-E1-3F-52-0A-C0-17-9D-DA-0C-07-C0-B7-B2-CB-0D-4A-7F-61-1A-6D-99-9C-B4-2F-5B-46-E0-1A-62-5A-91-4B-39-C2-67-9B-EA-38-3A-7E-06-26-54-43-EE-9D-A2-72-4D-40-55", "Developer", "carmen" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 51, "Arely Gutkowski", false, "EF-94-25-76-53-9E-1C-C2-0E-50-DB-13-41-38-11-C8-BF-AD-E7-12-06-C7-CE-86-48-08-E3-EB-2B-28-38-2E-DE-65-64-C3-77-49-F4-5A-A7-A8-1B-6E-0B-3B-B0-13-BB-BF-E9-64-0F-B0-39-9E-28-03-7B-A4-3F-57-80-40", "Developer", "dahlia.hyatt" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 52, "Dalton Mosciski", false, "6E-B5-A2-B8-61-8A-46-27-FC-EF-DE-D6-EB-60-B1-49-1B-87-57-A2-1C-DF-33-D1-9E-D5-A7-50-9B-6A-72-B3-D3-FC-10-B3-90-59-14-B9-6D-04-DB-80-AE-1F-AF-9D-12-CA-91-1A-27-1A-F4-87-09-5C-8A-B4-2C-D8-43-7E", "Developer", "nathanial" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 53, "Patricia Sanford", false, "8F-93-D7-80-EB-36-4B-48-61-5F-36-C3-4F-CE-A7-A3-87-4A-D2-81-F6-40-88-C2-9E-75-B9-2F-2F-21-8E-7C-66-57-B3-72-E3-29-21-9B-53-C4-C6-C6-BA-2A-28-FA-53-9B-73-18-6A-43-30-8C-8E-0A-3A-11-E5-D2-5B-7E", "Developer", "dillan" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 54, "Kale Walter", false, "37-69-E2-44-07-42-86-59-45-87-2B-A3-13-C3-71-AD-53-53-0A-BA-86-AC-C3-40-32-A5-D4-20-91-4C-A1-32-F6-33-1E-55-C9-64-85-AB-8E-5D-F4-20-3C-F6-71-F0-E3-14-26-19-EA-F8-BC-42-B3-26-31-4F-F7-F5-FE-45", "Developer", "demetrius" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 55, "Juvenal Morar", false, "ED-B0-AD-AB-F2-BF-81-25-21-C0-75-BF-22-84-AC-63-90-53-60-1C-6A-BE-04-33-36-10-9F-96-0C-26-AD-43-38-21-0A-2B-91-85-D2-70-16-8F-53-20-D5-E1-74-30-80-0E-8A-49-E1-45-13-4C-B4-8D-CE-D5-FC-C9-77-58", "Developer", "alvera.okeefe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 56, "Elvera Lindgren", false, "EA-4E-0A-2B-BB-2B-E3-A1-A4-3E-B2-89-16-44-FC-DA-E2-F2-C2-08-1F-2F-5E-55-A6-96-0D-FA-7E-6B-70-1B-90-CB-E0-0A-9D-4B-B2-2F-E5-59-19-56-F2-F7-D3-1A-29-44-49-06-0A-C9-A1-D6-27-62-ED-CD-44-E1-84-BB", "Developer", "levi" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 57, "Ray Hauck", false, "67-12-6E-DF-01-10-DC-18-50-3D-09-77-99-CA-27-DE-F8-0B-A1-26-82-34-8D-06-9A-44-28-52-AE-5E-E5-F1-77-03-FC-9F-CB-5A-4E-94-40-01-D1-FB-35-AC-BE-7E-DD-AA-11-D1-76-04-1F-73-54-CC-12-26-A1-98-42-A5", "Developer", "breanne_gutkowski" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 58, "Noble Kris", false, "6D-38-BE-A9-FC-DE-E4-85-40-16-9E-E1-17-BD-4F-8F-D3-89-8F-94-C4-8C-12-A4-2A-2D-67-EE-7E-CC-3F-30-31-2B-F0-EA-BD-77-63-AC-C8-8D-14-23-7B-10-BB-6D-37-BC-66-37-5A-8E-A0-6D-44-F7-85-4C-1C-3A-10-FB", "Developer", "linnea" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 59, "Sylvia Volkman", false, "8F-0F-7C-32-9F-A0-C1-4A-64-8C-58-C4-0F-30-6D-09-9A-13-0E-A1-98-38-D4-93-9E-04-2C-D9-2F-75-C3-B5-41-8F-88-7F-76-B3-C8-DE-76-60-4F-62-0A-55-75-6E-13-D8-AC-B3-1B-DA-79-92-C4-BC-7F-5E-22-B1-86-7C", "Developer", "jeremy" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 60, "Enrique Bayer", false, "E0-D8-BA-AB-D4-CD-61-9D-47-29-33-87-18-BC-BB-85-52-96-83-BF-83-07-0E-73-E9-15-2A-F5-FF-04-F8-16-41-51-85-CB-6B-74-AF-DD-EC-FA-C1-A4-1F-6E-1C-A6-D5-34-00-E5-D1-92-5D-B8-26-81-6B-C1-A9-CB-AA-D1", "Developer", "araceli" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 61, "Administrator", false, "CF-83-5D-E3-D4-EA-01-36-7C-45-E4-12-E7-A9-39-3A-85-A4-E4-0A-F1-49-ED-8C-3E-D6-C3-7C-05-B6-7B-27-81-3D-7F-F8-07-2C-10-35-CE-DD-19-41-5A-DF-17-12-8D-63-18-6F-05-F0-D6-56-00-2B-0C-A1-C3-4F-44-A0", "Administrator", "Administrator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 62, "Admin", false, "C7-AD-44-CB-AD-76-2A-5D-A0-A4-52-F9-E8-54-FD-C1-E0-E7-A5-2A-38-01-5F-23-F3-EA-B1-D8-0B-93-1D-D4-72-63-4D-FA-C7-1C-D3-4E-BC-35-D1-6A-B7-FB-8A-90-C8-1F-97-51-13-D6-C7-53-8D-C6-9D-D8-DE-90-77-EC", "Administrator", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 63, "Manager1", false, "92-A8-81-05-1A-0D-26-BA-0F-E4-A6-5C-B1-03-9C-10-E1-87-18-C6-85-91-EF-B6-AF-BF-88-3B-67-2A-32-8B-C8-BA-8C-13-FD-AA-90-EE-DC-01-8C-28-07-82-CB-BD-2A-84-2A-CB-D9-A5-F3-B8-96-50-12-A1-BA-48-92-34", "Manager", "Manager1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsLogged", "PasswordHash", "Role", "UserName" },
                values: new object[] { 64, "Manager2", false, "DB-C5-5B-65-5D-E7-95-23-A9-F1-81-7A-9C-26-62-40-92-D9-2D-6F-42-C2-35-DD-9B-74-3F-34-9A-DC-4B-83-2E-1B-ED-4B-50-ED-B6-34-E5-2D-3A-97-93-24-B8-7E-DB-07-30-8F-93-B6-E4-0A-77-E8-9F-7A-0F-AA-59-CC", "Manager", "Manager2" });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_UserId",
                table: "TeamMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "WorkTasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}