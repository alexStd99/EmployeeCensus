using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeCensus.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Floor = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EditDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EditDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastActionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EditDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EditDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProgrammingLanguageId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EditDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiences_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "EditDate", "Floor", "Name" },
                values: new object[,]
                {
                    { new Guid("0400eafe-0ef9-4355-9a29-a323cc61949c"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8126), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8126), 2, "IT" },
                    { new Guid("24cadc20-3b2a-4e24-a37b-f1f04ad893ac"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8227), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8227), 9, "Logistics" },
                    { new Guid("27ba6676-d274-4929-92e7-81ccc23b7e5b"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8229), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8229), 10, "Legal" },
                    { new Guid("9ef0cda4-e5d1-4975-a555-b83f4078dc42"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8216), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8217), 6, "Support" },
                    { new Guid("a0208518-f27a-4f53-bfa9-a160a2e26608"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8225), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8225), 8, "Operations" },
                    { new Guid("a21f0e7e-500e-4555-9590-c91db20d4ee0"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8122), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8123), 1, "HR" },
                    { new Guid("b85bcbea-59bc-43ee-841e-6f7f3dcf223e"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8128), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8128), 3, "Finance" },
                    { new Guid("c0b5ab59-77f1-43cd-b1fa-1419f597e755"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8211), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8211), 4, "Marketing" },
                    { new Guid("ddd18d2b-ffdf-4621-b16f-4bd4fcad3110"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8214), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8215), 5, "Sales" },
                    { new Guid("eb55d434-536e-40f4-ab58-558726597975"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8222), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8223), 7, "R&D" }
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "CreatedDate", "EditDate", "Name" },
                values: new object[,]
                {
                    { new Guid("15027bab-e1ef-4d1e-8a07-842a25255a4b"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8579), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8580), "Go" },
                    { new Guid("434faa2f-8af1-49c3-a8e8-c1a17ca25747"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8567), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8568), "Java" },
                    { new Guid("457a7ecc-ca5a-4b22-b427-ce175fcc7508"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8586), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8586), "PHP" },
                    { new Guid("5a87939a-87e4-47a9-a8c0-cab80df04da0"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8577), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8578), "Ruby" },
                    { new Guid("679c344a-e358-44de-b6b5-67da341e3430"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8572), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8573), "JavaScript" },
                    { new Guid("6d7920fd-e06d-4b2f-aa82-cd0e941759d4"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8565), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8565), "C#" },
                    { new Guid("71b8a6cf-93f2-4a0b-82f5-511a95c25180"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8584), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8584), "Kotlin" },
                    { new Guid("8caa562d-d065-496c-993c-e55cfb5ff370"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8569), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8570), "Python" },
                    { new Guid("a1089b7b-d38e-453d-a9e0-3172dbfcec6d"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8588), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8588), "Rust" },
                    { new Guid("f9b30bdf-b608-4d2f-9749-feb1bd1da6df"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8582), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8582), "Swift" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "EditDate", "LastActionTime", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("14237462-25ec-4e67-ac17-efe0d48d02d0"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8753), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8754), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8753), "password2", "user2" },
                    { new Guid("3f1d0083-5613-40da-9160-712095cd75c4"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8759), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8759), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8758), "password3", "user3" },
                    { new Guid("99077225-2cd4-4711-8466-bbf87c498d94"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8776), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8776), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8775), "password8", "user8" },
                    { new Guid("a53b24b1-1f6a-427a-963f-6efafeab24da"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8764), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8765), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8764), "password5", "user5" },
                    { new Guid("bcfcd80a-7026-41ec-b7e1-972031d4c3f9"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8761), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8762), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8761), "password4", "user4" },
                    { new Guid("c61e626d-0511-4399-9a5b-ba37fefac7ad"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8767), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8768), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8767), "password6", "user6" },
                    { new Guid("c8bd2dad-e9c4-4e0e-8a2c-a9450b3367a8"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8750), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8750), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8749), "password1", "user1" },
                    { new Guid("d44897bb-a7e3-47ef-8021-35b5cf2c9e59"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8773), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8773), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8772), "password7", "user7" },
                    { new Guid("e338cbcb-7910-4d4d-ae86-467d3da07b23"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8778), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8779), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8778), "password9", "user9" },
                    { new Guid("f247a176-1c4a-4372-b337-80506f7438ca"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8781), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8782), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8781), "password10", "user10" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CreatedDate", "DepartmentId", "EditDate", "FirstName", "Gender", "IsDeleted", "LastName" },
                values: new object[,]
                {
                    { new Guid("0b5fc5c8-561c-431c-b4e3-b1b25b56bb94"), 28, new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8617), new Guid("0400eafe-0ef9-4355-9a29-a323cc61949c"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8617), "Jane", 2, false, "Doe" },
                    { new Guid("2ca22dc5-6bc1-4c56-99ec-52873f599a5a"), 32, new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8624), new Guid("c0b5ab59-77f1-43cd-b1fa-1419f597e755"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8625), "Emily", 2, false, "Johnson" },
                    { new Guid("30d9fc98-924b-47e8-a38d-f80c7578cd9a"), 30, new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8614), new Guid("a21f0e7e-500e-4555-9590-c91db20d4ee0"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8615), "John", 1, false, "Doe" },
                    { new Guid("4859792f-cf9c-4e0b-b13a-994b8a32b6dd"), 34, new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8634), new Guid("a0208518-f27a-4f53-bfa9-a160a2e26608"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8635), "Laura", 2, false, "Wilson" },
                    { new Guid("54e012a8-e3fc-40f6-9b68-a2c341c43f11"), 40, new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8627), new Guid("ddd18d2b-ffdf-4621-b16f-4bd4fcad3110"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8627), "Chris", 1, false, "Brown" },
                    { new Guid("60b68e05-6e59-40d5-bbca-fdc03c9d4423"), 50, new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8637), new Guid("24cadc20-3b2a-4e24-a37b-f1f04ad893ac"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8637), "David", 1, false, "Moore" },
                    { new Guid("8867ed9c-470c-47ee-9e64-5c5dd854cd4b"), 45, new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8632), new Guid("eb55d434-536e-40f4-ab58-558726597975"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8632), "James", 1, false, "Miller" },
                    { new Guid("8cae1ee4-a4fb-4e9d-a7b9-2f67ad4a9428"), 27, new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8666), new Guid("27ba6676-d274-4929-92e7-81ccc23b7e5b"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8666), "Sophia", 2, false, "Taylor" },
                    { new Guid("b4324bbc-ce3c-469f-9eb9-c90adf118adc"), 29, new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8629), new Guid("9ef0cda4-e5d1-4975-a555-b83f4078dc42"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8629), "Anna", 2, false, "Davis" },
                    { new Guid("f32b0219-d537-47e9-b0bd-4465ebd8079a"), 35, new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8622), new Guid("b85bcbea-59bc-43ee-841e-6f7f3dcf223e"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8622), "Mike", 1, false, "Smith" }
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "CreatedDate", "EditDate", "EmployeeId", "ProgrammingLanguageId" },
                values: new object[,]
                {
                    { new Guid("0a3f7d97-6710-48b5-8351-cffe9d87adcc"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8714), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8714), new Guid("b4324bbc-ce3c-469f-9eb9-c90adf118adc"), new Guid("15027bab-e1ef-4d1e-8a07-842a25255a4b") },
                    { new Guid("473c220e-d12a-4730-a6ff-51dbce96ca56"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8701), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8701), new Guid("0b5fc5c8-561c-431c-b4e3-b1b25b56bb94"), new Guid("434faa2f-8af1-49c3-a8e8-c1a17ca25747") },
                    { new Guid("7c652ff8-a8b2-46cc-934a-a3ae307d2069"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8717), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8717), new Guid("8867ed9c-470c-47ee-9e64-5c5dd854cd4b"), new Guid("f9b30bdf-b608-4d2f-9749-feb1bd1da6df") },
                    { new Guid("7cd874d8-947a-4ba5-a75c-10c3fdbf9ed5"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8704), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8704), new Guid("f32b0219-d537-47e9-b0bd-4465ebd8079a"), new Guid("8caa562d-d065-496c-993c-e55cfb5ff370") },
                    { new Guid("bbe68ab8-3675-4c37-8d21-7897b8960289"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8724), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8724), new Guid("60b68e05-6e59-40d5-bbca-fdc03c9d4423"), new Guid("457a7ecc-ca5a-4b22-b427-ce175fcc7508") },
                    { new Guid("c0b9ec0b-92f0-49c7-906a-eb824a186c7d"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8706), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8707), new Guid("2ca22dc5-6bc1-4c56-99ec-52873f599a5a"), new Guid("679c344a-e358-44de-b6b5-67da341e3430") },
                    { new Guid("c20510c5-33d9-410c-9c63-9772882a9465"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8697), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8698), new Guid("30d9fc98-924b-47e8-a38d-f80c7578cd9a"), new Guid("6d7920fd-e06d-4b2f-aa82-cd0e941759d4") },
                    { new Guid("daa70592-0683-4546-a2b4-478e726c3a94"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8711), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8712), new Guid("54e012a8-e3fc-40f6-9b68-a2c341c43f11"), new Guid("5a87939a-87e4-47a9-a8c0-cab80df04da0") },
                    { new Guid("e61edaf4-ca6f-4302-ace9-9d7c1c7cb83f"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8726), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8727), new Guid("8cae1ee4-a4fb-4e9d-a7b9-2f67ad4a9428"), new Guid("a1089b7b-d38e-453d-a9e0-3172dbfcec6d") },
                    { new Guid("fad0ae4a-013a-41ce-bd0c-9b8b17a7ad01"), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8719), new DateTime(2024, 7, 4, 12, 50, 58, 38, DateTimeKind.Utc).AddTicks(8720), new Guid("4859792f-cf9c-4e0b-b13a-994b8a32b6dd"), new Guid("71b8a6cf-93f2-4a0b-82f5-511a95c25180") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_EmployeeId",
                table: "Experiences",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ProgrammingLanguageId",
                table: "Experiences",
                column: "ProgrammingLanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
