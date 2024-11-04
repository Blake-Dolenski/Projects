using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTCDentalProjectPhase1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentTypes",
                columns: table => new
                {
                    TypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTypes", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Dentists",
                columns: table => new
                {
                    DentistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DentistFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DentistLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentists", x => x.DentistID);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientStreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientZip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientSSN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientMinor = table.Column<bool>(type: "bit", nullable: false),
                    PatientHOHID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patients_Patients_PatientHOHID",
                        column: x => x.PatientHOHID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DentistID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    TypeID = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentTypes_TypeID",
                        column: x => x.TypeID,
                        principalTable: "AppointmentTypes",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Dentists_DentistID",
                        column: x => x.DentistID,
                        principalTable: "Dentists",
                        principalColumn: "DentistID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DentistID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.VisitID);
                    table.ForeignKey(
                        name: "FK_Visits_Dentists_DentistID",
                        column: x => x.DentistID,
                        principalTable: "Dentists",
                        principalColumn: "DentistID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visits_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedServices",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    VisitID = table.Column<int>(type: "int", nullable: false),
                    CompletedServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedServices", x => new { x.ServiceID, x.VisitID });
                    table.ForeignKey(
                        name: "FK_CompletedServices_Services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Services",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompletedServices_Visits_VisitID",
                        column: x => x.VisitID,
                        principalTable: "Visits",
                        principalColumn: "VisitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppointmentTypes",
                columns: new[] { "TypeID", "AppointmentName", "Description", "Duration" },
                values: new object[,]
                {
                    { 1, "Cosmetic Consultation - Adult", "Initial consultation with adult patient to discuss cosmetic dentistry options.", 30 },
                    { 2, "Cosmetic Consultation - Child", "Initial consultation with child patient to discuss cosmetic dentistry options.", 30 },
                    { 3, "Cosmetic Consultation - Teen", "Initial consultation with teen patient to discuss cosmetic dentistry options.", 30 },
                    { 4, "Cosmetic Procedure - Adult", "Cosmetic dentistry procedure for adult patient.", 120 },
                    { 5, "Cosmetic Procedure - Child", "Cosmetic dentistry procedure for child patient.", 120 },
                    { 6, "Cosmetic Procedure - Teen", "Cosmetic dentistry procedure for teen patient.", 120 },
                    { 7, "Endodontic Procedure - Adult", "Painless root canal therapy for adults.", 90 },
                    { 8, "Endodontic Procedure - Child", "Painless root canal therapy for children.", 90 },
                    { 9, "Endodontic Procedure - Teen", "Painless root canal therapy for teens.", 90 },
                    { 10, "New Patient - Adult", "Meet new patient, general dental check-up including x-rays and teeth cleaning.", 30 },
                    { 11, "New Patient - Child", "Meet new patient, general dental check-up including x-rays and teeth cleaning.", 30 },
                    { 12, "New Patient - Teen", "Meet new patient, general dental check-up including x-rays and teeth cleaning.", 30 },
                    { 13, "Periodontal Treatment - Adult", "Treatment (both preventative or restorative) for gum diseases.", 60 },
                    { 14, "Periodontal Treatment - Child", "Treatment (both preventative or restorative) for gum diseases.", 60 },
                    { 15, "Periodontal Treatment - Teen", "Treatment (both preventative or restorative) for gum diseases.", 60 },
                    { 16, "Preventative Care - Adult", "General preventative care for an adult patient. The appointment will include x-rays, teeth cleaning, and general oral hygiene advising.", 60 },
                    { 17, "Preventative Care - Child", "General preventative care for a child patient. The appointment will include x-rays, teeth cleaning, and general oral hygiene advising.", 60 },
                    { 18, "Preventative Care - Teen", "General preventative care for a teen patient. The appointment will include x-rays, teeth cleaning, and general oral hygiene advising.", 60 },
                    { 19, "Prosthodontic Care - Adult", "Restoration and/or replacement of missing or damaged teeth for adults.", 60 },
                    { 20, "Prosthodontic Care - Child", "Restoration and/or replacement of missing or damaged teeth for children.", 60 },
                    { 21, "Prosthodontic Care - Teen", "Restoration and/or replacement of missing or damaged teeth for teens.", 60 }
                });

            migrationBuilder.InsertData(
                table: "Dentists",
                columns: new[] { "DentistID", "DentistFirstName", "DentistLastName", "HireDate" },
                values: new object[,]
                {
                    { 1, "John", "Smith", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Sarah", "Johnson", new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Michael", "Chen", new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Emily", "Rodriguez", new DateTime(2021, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "David", "Wilson", new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientID", "PatientCity", "PatientDOB", "PatientEmail", "PatientFirstName", "PatientHOHID", "PatientLastName", "PatientMinor", "PatientPhone", "PatientSSN", "PatientState", "PatientStreetAddress", "PatientZip" },
                values: new object[,]
                {
                    { 1, "Seattle", new DateTime(1980, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.brown@gmail.com", "Michael", -1, "Brown", false, "206-555-0101", "123-45-6789", "WA", "123 Main St", "98101" },
                    { 3, "Seattle", new DateTime(1975, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "robert.johnson@gmail.com", "Robert", -1, "Johnson", false, "206-555-0103", "123-45-6791", "WA", "456 Pine St", "98102" },
                    { 5, "Bellevue", new DateTime(1982, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah.wilson@gmail.com", "Sarah", -1, "Wilson", false, "425-555-0105", "123-45-6793", "WA", "789 Oak Dr", "98004" },
                    { 7, "Kirkland", new DateTime(1990, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.martinez@gmail.com", "David", -1, "Martinez", false, "425-555-0107", "123-45-6795", "WA", "321 Elm St", "98033" },
                    { 8, "Redmond", new DateTime(1988, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "jennifer.taylor@gmail.com", "Jennifer", null, "Taylor", false, "425-555-0108", "123-45-6796", "WA", "567 Cedar Ln", "98052" },
                    { 9, "Renton", new DateTime(1979, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "carlos.garcia@gmail.com", "Carlos", -1, "Garcia", false, "425-555-0109", "123-45-6797", "WA", "890 Maple Ave", "98055" },
                    { 12, "Issaquah", new DateTime(2007, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.chen@gmail.com", "Emily", null, "Chen", true, "425-555-0112", "123-45-6800", "WA", "234 Birch Rd", "98029" },
                    { 13, "Sammamish", new DateTime(1983, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "william.lee@gmail.com", "William", -1, "Lee", false, "425-555-0113", "123-45-6801", "WA", "345 Spruce Way", "98074" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceID", "ServiceCost", "ServiceDescription" },
                values: new object[,]
                {
                    { 1, 75.00m, "Basic Cleaning" },
                    { 2, 125.00m, "X-Ray" },
                    { 3, 200.00m, "Cavity Filling" },
                    { 4, 800.00m, "Root Canal" },
                    { 5, 350.00m, "Teeth Whitening" },
                    { 6, 1200.00m, "Dental Crown" },
                    { 7, 2500.00m, "Dental Bridge" },
                    { 8, 150.00m, "Tooth Extraction" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceID", "ServiceCost", "ServiceDescription" },
                values: new object[,]
                {
                    { 9, 200.00m, "Deep Cleaning" },
                    { 10, 35.00m, "Fluoride Treatment" },
                    { 11, 45.00m, "Dental Sealants" },
                    { 12, 3000.00m, "Dental Implant" },
                    { 13, 450.00m, "Wisdom Tooth Removal" },
                    { 14, 50.00m, "Dental Consultation" },
                    { 15, 250.00m, "Emergency Dental Care" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentID", "AppointmentDate", "DentistID", "PatientID", "StartTime", "TypeID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2024, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2024, 11, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 5, new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7, new DateTime(2024, 11, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 7, new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 12, new DateTime(2024, 11, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), 18 },
                    { 8, new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, new DateTime(2024, 11, 19, 11, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 10, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8, new DateTime(2024, 11, 20, 13, 30, 0, 0, DateTimeKind.Unspecified), 19 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientID", "PatientCity", "PatientDOB", "PatientEmail", "PatientFirstName", "PatientHOHID", "PatientLastName", "PatientMinor", "PatientPhone", "PatientSSN", "PatientState", "PatientStreetAddress", "PatientZip" },
                values: new object[,]
                {
                    { 2, "Seattle", new DateTime(2015, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "emma.brown@gmail.com", "Emma", 1, "Brown", true, "206-555-0102", "123-45-6790", "WA", "123 Main St", "98101" },
                    { 4, "Seattle", new DateTime(2010, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "lisa.johnson@gmail.com", "Lisa", 3, "Johnson", true, "206-555-0104", "123-45-6792", "WA", "456 Pine St", "98102" },
                    { 6, "Bellevue", new DateTime(2013, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "james.wilson@gmail.com", "James", 5, "Wilson", true, "425-555-0106", "123-45-6794", "WA", "789 Oak Dr", "98004" },
                    { 10, "Renton", new DateTime(2008, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria.garcia@gmail.com", "Maria", 9, "Garcia", true, "425-555-0110", "123-45-6798", "WA", "890 Maple Ave", "98055" },
                    { 11, "Renton", new DateTime(2012, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "luis.garcia@gmail.com", "Luis", 9, "Garcia", true, "425-555-0111", "123-45-6799", "WA", "890 Maple Ave", "98055" },
                    { 14, "Sammamish", new DateTime(2014, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophie.lee@gmail.com", "Sophie", 13, "Lee", true, "425-555-0114", "123-45-6802", "WA", "345 Spruce Way", "98074" },
                    { 15, "Sammamish", new DateTime(2016, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "oliver.lee@gmail.com", "Oliver", 13, "Lee", true, "425-555-0115", "123-45-6803", "WA", "345 Spruce Way", "98074" }
                });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "VisitID", "DentistID", "PatientID", "VisitDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 3, new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, 5, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 5, 7, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 3, 8, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 4, 9, new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentID", "AppointmentDate", "DentistID", "PatientID", "StartTime", "TypeID" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2024, 11, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, new DateTime(2024, 11, 16, 10, 30, 0, 0, DateTimeKind.Unspecified), 17 },
                    { 6, new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10, new DateTime(2024, 11, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 9, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 14, new DateTime(2024, 11, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.InsertData(
                table: "CompletedServices",
                columns: new[] { "ServiceID", "VisitID", "CompletedDate" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 1, 5, null },
                    { 1, 8, null },
                    { 2, 1, null },
                    { 2, 7, null },
                    { 3, 3, null },
                    { 3, 9, null }
                });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "VisitID", "DentistID", "PatientID", "VisitDate" },
                values: new object[,]
                {
                    { 2, 2, 2, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, 4, new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 4, 6, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 5, 10, new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CompletedServices",
                columns: new[] { "ServiceID", "VisitID", "CompletedDate" },
                values: new object[] { 1, 2, null });

            migrationBuilder.InsertData(
                table: "CompletedServices",
                columns: new[] { "ServiceID", "VisitID", "CompletedDate" },
                values: new object[] { 2, 4, null });

            migrationBuilder.InsertData(
                table: "CompletedServices",
                columns: new[] { "ServiceID", "VisitID", "CompletedDate" },
                values: new object[] { 3, 6, null });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DentistID",
                table: "Appointments",
                column: "DentistID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TypeID",
                table: "Appointments",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedServices_VisitID",
                table: "CompletedServices",
                column: "VisitID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PatientHOHID",
                table: "Patients",
                column: "PatientHOHID");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DentistID",
                table: "Visits",
                column: "DentistID");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientID",
                table: "Visits",
                column: "PatientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "CompletedServices");

            migrationBuilder.DropTable(
                name: "AppointmentTypes");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Dentists");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
