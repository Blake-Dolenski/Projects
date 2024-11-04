/*  AUTHOR: Team 12 (Jackson Wiese & Blake Dolenski)
 *  COURSE: ISTM 415.501
 *  FORM:   Appointment.cs
 *  PURPOSE: Represents the details of a dental appointment.
 *  INPUT:  Data from dentist and patient.
 *  PROCESS: Navigation properties
 *  OUTPUT: Appointment objects
 *  HONOR CODE: "On my honor, as an Aggie, I have neither
 *  given nor received unauthorized aid on this academic work."
 */

using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace DTCDentalProjectPhase1.Models
{
    public class DTCDentalContext : DbContext
    {

        public DTCDentalContext(DbContextOptions<DTCDentalContext> options)
            : base(options)
        { }

        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Dentist> Dentists { get; set; } = null!;
        public DbSet<AppointmentType> AppointmentTypes { get; set; } = null!;

        public DbSet<Visit> Visits { get; set; } = null!;

        public DbSet<Appointment> Appointments { get; set; } = null!;

        public DbSet<Service> Services { get; set; } = null!;

        public DbSet<CompletedService> CompletedServices { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Patient>(entity =>
            //{
            //    entity.HasKey(e => e.PatientID);

            //    // Self-referencing relationship for Head of Household
            //    entity.HasOne<Patient>()
            //        .WithMany()
            //        .HasForeignKey(e => e.PatientHOHID)
            //        .IsRequired(false);

            //    entity.Property(e => e.PatientFirstName).IsRequired();
            //    entity.Property(e => e.PatientLastName).IsRequired();
            //    entity.Property(e => e.PatientStreetAddress).IsRequired();
            //    entity.Property(e => e.PatientCity).IsRequired();
            //    entity.Property(e => e.PatientState).IsRequired();
            //    entity.Property(e => e.PatientZip).IsRequired();
            //    entity.Property(e => e.PatientPhone).IsRequired();
            //    entity.Property(e => e.PatientEmail);
            //    entity.Property(e => e.PatientSSN);
            //    entity.Property(e => e.PatientDOB);
            //    entity.Property(e => e.PatientMinor);
            //});

            //// Dentist Configuration
            //modelBuilder.Entity<Dentist>(entity =>
            //{
            //    entity.HasKey(e => e.DentistID);

            //    entity.Property(e => e.DentistFirstName).IsRequired();
            //    entity.Property(e => e.DentistLastName).IsRequired();
            //    entity.Property(e => e.HireDate).IsRequired();
            //});

            //// AppointmentType Configuration
            //modelBuilder.Entity<AppointmentType>(entity =>
            //{
            //    entity.HasKey(e => e.TypeID);

            //    entity.Property(e => e.AppointmentName).IsRequired();
            //    entity.Property(e => e.Description);
            //    entity.Property(e => e.Duration).IsRequired();
            //});

            //// Simple configurations can use separate methods for clarity

            //modelBuilder.Entity<Appointment>(entity =>
            //{
            //    entity.HasKey(e => e.AppointmentID);

            //    // Relationships from ERD
            //    entity.HasOne(a => a.Patient)
            //        .WithMany()
            //        .HasForeignKey(a => a.PatientID)
            //        .IsRequired();

            //    entity.HasOne(a => a.Dentist)
            //        .WithMany()
            //        .HasForeignKey(a => a.DentistID)
            //        .IsRequired();

            //    entity.HasOne(a => a.AppointmentType)
            //        .WithMany()
            //        .HasForeignKey(a => a.TypeID)
            //        .IsRequired();

            //    // Properties from ERD
            //    entity.Property(e => e.AppointmentDate).IsRequired();
            //    entity.Property(e => e.StartTime).IsRequired();
            //});

            //modelBuilder.Entity<Visit>(entity =>
            //{
            //    entity.HasKey(e => e.VisitID);

            //    // Relationships from ERD
            //    entity.HasOne(v => v.Patient)
            //        .WithMany()
            //        .HasForeignKey(v => v.PatientID)
            //        .IsRequired();

            //    entity.HasOne(v => v.Dentist)
            //        .WithMany()
            //        .HasForeignKey(v => v.DentistID)
            //        .IsRequired();

            //    // Properties from ERD
            //    entity.Property(e => e.VisitDate).IsRequired();
            //});

            //// Service Configuration
            //modelBuilder.Entity<Service>(entity =>
            //{
            //    entity.HasKey(e => e.ServiceID);

            //    // Properties from ERD
            //    entity.Property(e => e.ServiceDescription).IsRequired();
            //    entity.Property(e => e.ServiceCost).IsRequired();
            //});

            //modelBuilder.Entity<CompletedService>(entity =>
            //{
            //    // Composite Key from ERD
            //    entity.HasKey(e => new { e.ServiceID, e.VisitID });

            //    // Relationships from ERD
            //    entity.HasOne(cs => cs.Visit)
            //        .WithMany()
            //        .HasForeignKey(cs => cs.VisitID)
            //        .IsRequired();

            //    entity.HasOne(cs => cs.Service)
            //        .WithMany()
            //        .HasForeignKey(cs => cs.ServiceID)
            //        .IsRequired();
            //});

            //modelBuilder.Entity<CompletedService>(entity =>
            //{
            //    // Composite Key from ERD
            //    entity.HasKey(e => new { e.ServiceID, e.VisitID });

            //    // Relationships from ERD
            //    entity.HasOne(cs => cs.Visit)
            //        .WithMany()
            //        .HasForeignKey(cs => cs.VisitID)
            //        .IsRequired();

            //    entity.HasOne(cs => cs.Service)
            //        .WithMany()
            //        .HasForeignKey(cs => cs.ServiceID)
            //        .IsRequired();
            //});

            // Define primary keys
            modelBuilder.Entity<Patient>().HasKey(p => p.PatientID);
            modelBuilder.Entity<Dentist>().HasKey(d => d.DentistID);
            modelBuilder.Entity<AppointmentType>().HasKey(at => at.TypeID);
            modelBuilder.Entity<Visit>().HasKey(v => v.VisitID);
            modelBuilder.Entity<Appointment>().HasKey(a => a.AppointmentID);
            modelBuilder.Entity<Service>().HasKey(s => s.ServiceID);
            modelBuilder.Entity<CompletedService>().HasKey(cs => new { cs.ServiceID, cs.VisitID }); // Composite key

            // Relationships
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.PatientHOH)      // HeadOfHousehold navigation property
                .WithMany(p => p.Dependents)          // Dependents navigation property
                .HasForeignKey(p => p.PatientHOHID)   // Foreign key for self-reference
                .OnDelete(DeleteBehavior.Restrict);   // Prevent cascading deletes

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Dentist)
                .WithMany()
                .HasForeignKey(a => a.DentistID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.AppointmentType)
                .WithMany()
                .HasForeignKey(a => a.TypeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Visit>()
                .HasOne(v => v.Patient)
                .WithMany()
                .HasForeignKey(v => v.PatientID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Visit>()
                .HasOne(v => v.Dentist)
                .WithMany()
                .HasForeignKey(v => v.DentistID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CompletedService>()
                .HasOne(cs => cs.Visit)
                .WithMany()
                .HasForeignKey(cs => cs.VisitID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompletedService>()
                .HasOne(cs => cs.Service)
                .WithMany()
                .HasForeignKey(cs => cs.ServiceID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Service>()
                .Property(s => s.ServiceCost)
                .HasColumnType("decimal(18, 2)"); 


            // AppointmentTypes seed data
            modelBuilder.Entity<AppointmentType>().HasData(
            new AppointmentType
            {
                TypeID = 1,
                AppointmentName = "Cosmetic Consultation - Adult",
                Description = "Initial consultation with adult patient to discuss cosmetic dentistry options.",
                Duration = 30
            },
            new AppointmentType
            {
                TypeID = 2,
                AppointmentName = "Cosmetic Consultation - Child",
                Description = "Initial consultation with child patient to discuss cosmetic dentistry options.",
                Duration = 30
            },
            new AppointmentType
            {
                TypeID = 3,
                AppointmentName = "Cosmetic Consultation - Teen",
                Description = "Initial consultation with teen patient to discuss cosmetic dentistry options.",
                Duration = 30
            },
            new AppointmentType
            {
                TypeID = 4,
                AppointmentName = "Cosmetic Procedure - Adult",
                Description = "Cosmetic dentistry procedure for adult patient.",
                Duration = 120
            },
            new AppointmentType
            {
                TypeID = 5,
                AppointmentName = "Cosmetic Procedure - Child",
                Description = "Cosmetic dentistry procedure for child patient.",
                Duration = 120
            },
            new AppointmentType
            {
                TypeID = 6,
                AppointmentName = "Cosmetic Procedure - Teen",
                Description = "Cosmetic dentistry procedure for teen patient.",
                Duration = 120
            },
            new AppointmentType
            {
                TypeID = 7,
                AppointmentName = "Endodontic Procedure - Adult",
                Description = "Painless root canal therapy for adults.",
                Duration = 90
            },
            new AppointmentType
            {
                TypeID = 8,
                AppointmentName = "Endodontic Procedure - Child",
                Description = "Painless root canal therapy for children.",
                Duration = 90
            },
            new AppointmentType
            {
                TypeID = 9,
                AppointmentName = "Endodontic Procedure - Teen",
                Description = "Painless root canal therapy for teens.",
                Duration = 90
            },
            new AppointmentType
            {
                TypeID = 10,
                AppointmentName = "New Patient - Adult",
                Description = "Meet new patient, general dental check-up including x-rays and teeth cleaning.",
                Duration = 30
            },
            new AppointmentType
            {
                TypeID = 11,
                AppointmentName = "New Patient - Child",
                Description = "Meet new patient, general dental check-up including x-rays and teeth cleaning.",
                Duration = 30
            },
            new AppointmentType
            {
                TypeID = 12,
                AppointmentName = "New Patient - Teen",
                Description = "Meet new patient, general dental check-up including x-rays and teeth cleaning.",
                Duration = 30
            },
            new AppointmentType
            {
                TypeID = 13,
                AppointmentName = "Periodontal Treatment - Adult",
                Description = "Treatment (both preventative or restorative) for gum diseases.",
                Duration = 60
            },
            new AppointmentType
            {
                TypeID = 14,
                AppointmentName = "Periodontal Treatment - Child",
                Description = "Treatment (both preventative or restorative) for gum diseases.",
                Duration = 60
            },
            new AppointmentType
            {
                TypeID = 15,
                AppointmentName = "Periodontal Treatment - Teen",
                Description = "Treatment (both preventative or restorative) for gum diseases.",
                Duration = 60
            },
            new AppointmentType
            {
                TypeID = 16,
                AppointmentName = "Preventative Care - Adult",
                Description = "General preventative care for an adult patient. The appointment will include x-rays, teeth cleaning, and general oral hygiene advising.",
                Duration = 60
            },
            new AppointmentType
            {
                TypeID = 17,
                AppointmentName = "Preventative Care - Child",
                Description = "General preventative care for a child patient. The appointment will include x-rays, teeth cleaning, and general oral hygiene advising.",
                Duration = 60
            },
            new AppointmentType
            {
                TypeID = 18,
                AppointmentName = "Preventative Care - Teen",
                Description = "General preventative care for a teen patient. The appointment will include x-rays, teeth cleaning, and general oral hygiene advising.",
                Duration = 60
            },
            new AppointmentType
            {
                TypeID = 19,
                AppointmentName = "Prosthodontic Care - Adult",
                Description = "Restoration and/or replacement of missing or damaged teeth for adults.",
                Duration = 60
            },
            new AppointmentType
            {
                TypeID = 20,
                AppointmentName = "Prosthodontic Care - Child",
                Description = "Restoration and/or replacement of missing or damaged teeth for children.",
                Duration = 60
            },
            new AppointmentType
            {
                TypeID = 21,
                AppointmentName = "Prosthodontic Care - Teen",
                Description = "Restoration and/or replacement of missing or damaged teeth for teens.",
                Duration = 60
            }
        );

            // Seed Dentists
            
            modelBuilder.Entity<Dentist>().HasData(
                new Dentist
                {
                    DentistID = 1,
                    DentistFirstName = "John",
                    DentistLastName = "Smith",
                    HireDate = DateTime.Parse("2020-01-15")
                },
                new Dentist
                {
                    DentistID = 2,
                    DentistFirstName = "Sarah",
                    DentistLastName = "Johnson",
                    HireDate = DateTime.Parse("2021-03-01")
                },
                new Dentist
                {
                    DentistID = 3,
                    DentistFirstName = "Michael",
                    DentistLastName = "Chen",
                    HireDate = DateTime.Parse("2020-06-15")
                },
                new Dentist
                {
                    DentistID = 4,
                    DentistFirstName = "Emily",
                    DentistLastName = "Rodriguez",
                    HireDate = DateTime.Parse("2021-09-20")
                },
                new Dentist
                {
                    DentistID = 5,
                    DentistFirstName = "David",
                    DentistLastName = "Wilson",
                    HireDate = DateTime.Parse("2022-01-10")
                }
            );

            // Seed Patients (including a family with HOH relationship)
            modelBuilder.Entity<Patient>().HasData(
            // Existing Brown Family
            new Patient
            {
                PatientID = 1,
                PatientFirstName = "Michael",
                PatientLastName = "Brown",
                PatientStreetAddress = "123 Main St",
                PatientCity = "Seattle",
                PatientState = "WA",
                PatientZip = "98101",
                PatientPhone = "206-555-0101",
                PatientEmail = "michael.brown@gmail.com",
                PatientSSN = "123-45-6789",
                PatientDOB = DateTime.Parse("1980-06-15"),
                PatientMinor = false,
                PatientHOHID = -1
            },
            new Patient
            {
                PatientID = 2,
                PatientFirstName = "Emma",
                PatientLastName = "Brown",
                PatientStreetAddress = "123 Main St",
                PatientCity = "Seattle",
                PatientState = "WA",
                PatientZip = "98101",
                PatientPhone = "206-555-0102",
                PatientEmail = "emma.brown@gmail.com",
                PatientSSN = "123-45-6790",
                PatientDOB = DateTime.Parse("2015-08-20"),
                PatientMinor = true,
                PatientHOHID = 1
            },

            // Johnson Family
            new Patient
            {
                PatientID = 3,
                PatientFirstName = "Robert",
                PatientLastName = "Johnson",
                PatientStreetAddress = "456 Pine St",
                PatientCity = "Seattle",
                PatientState = "WA",
                PatientZip = "98102",
                PatientPhone = "206-555-0103",
                PatientEmail = "robert.johnson@gmail.com",
                PatientSSN = "123-45-6791",
                PatientDOB = DateTime.Parse("1975-03-22"),
                PatientMinor = false,
                PatientHOHID = -1
            },
            new Patient
            {
                PatientID = 4,
                PatientFirstName = "Lisa",
                PatientLastName = "Johnson",
                PatientStreetAddress = "456 Pine St",
                PatientCity = "Seattle",
                PatientState = "WA",
                PatientZip = "98102",
                PatientPhone = "206-555-0104",
                PatientEmail = "lisa.johnson@gmail.com",
                PatientSSN = "123-45-6792",
                PatientDOB = DateTime.Parse("2010-11-30"),
                PatientMinor = true,
                PatientHOHID = 3
            },

            // Wilson Family
            new Patient
            {
                PatientID = 5,
                PatientFirstName = "Sarah",
                PatientLastName = "Wilson",
                PatientStreetAddress = "789 Oak Dr",
                PatientCity = "Bellevue",
                PatientState = "WA",
                PatientZip = "98004",
                PatientPhone = "425-555-0105",
                PatientEmail = "sarah.wilson@gmail.com",
                PatientSSN = "123-45-6793",
                PatientDOB = DateTime.Parse("1982-09-15"),
                PatientMinor = false,
                PatientHOHID = -1
            },
            new Patient
            {
                PatientID = 6,
                PatientFirstName = "James",
                PatientLastName = "Wilson",
                PatientStreetAddress = "789 Oak Dr",
                PatientCity = "Bellevue",
                PatientState = "WA",
                PatientZip = "98004",
                PatientPhone = "425-555-0106",
                PatientEmail = "james.wilson@gmail.com",
                PatientSSN = "123-45-6794",
                PatientDOB = DateTime.Parse("2013-07-08"),
                PatientMinor = true,
                PatientHOHID = 5
            },

            // Individual Adult Patients
            new Patient
            {
                PatientID = 7,
                PatientFirstName = "David",
                PatientLastName = "Martinez",
                PatientStreetAddress = "321 Elm St",
                PatientCity = "Kirkland",
                PatientState = "WA",
                PatientZip = "98033",
                PatientPhone = "425-555-0107",
                PatientEmail = "david.martinez@gmail.com",
                PatientSSN = "123-45-6795",
                PatientDOB = DateTime.Parse("1990-12-03"),
                PatientMinor = false,
                PatientHOHID = -1
            },
            new Patient
            {
                PatientID = 8,
                PatientFirstName = "Jennifer",
                PatientLastName = "Taylor",
                PatientStreetAddress = "567 Cedar Ln",
                PatientCity = "Redmond",
                PatientState = "WA",
                PatientZip = "98052",
                PatientPhone = "425-555-0108",
                PatientEmail = "jennifer.taylor@gmail.com",
                PatientSSN = "123-45-6796",
                PatientDOB = DateTime.Parse("1988-04-25"),
                PatientMinor = false,
                PatientHOHID = null
            },

            // Garcia Family
            new Patient
            {
                PatientID = 9,
                PatientFirstName = "Carlos",
                PatientLastName = "Garcia",
                PatientStreetAddress = "890 Maple Ave",
                PatientCity = "Renton",
                PatientState = "WA",
                PatientZip = "98055",
                PatientPhone = "425-555-0109",
                PatientEmail = "carlos.garcia@gmail.com",
                PatientSSN = "123-45-6797",
                PatientDOB = DateTime.Parse("1979-08-17"),
                PatientMinor = false,
                PatientHOHID = -1
            },
            new Patient
            {
                PatientID = 10,
                PatientFirstName = "Maria",
                PatientLastName = "Garcia",
                PatientStreetAddress = "890 Maple Ave",
                PatientCity = "Renton",
                PatientState = "WA",
                PatientZip = "98055",
                PatientPhone = "425-555-0110",
                PatientEmail = "maria.garcia@gmail.com",
                PatientSSN = "123-45-6798",
                PatientDOB = DateTime.Parse("2008-01-12"),
                PatientMinor = true,
                PatientHOHID = 9
            },
            new Patient
            {
                PatientID = 11,
                PatientFirstName = "Luis",
                PatientLastName = "Garcia",
                PatientStreetAddress = "890 Maple Ave",
                PatientCity = "Renton",
                PatientState = "WA",
                PatientZip = "98055",
                PatientPhone = "425-555-0111",
                PatientEmail = "luis.garcia@gmail.com",
                PatientSSN = "123-45-6799",
                PatientDOB = DateTime.Parse("2012-06-30"),
                PatientMinor = true,
                PatientHOHID = 9
            },

            // Individual Teen Patient
            new Patient
            {
                PatientID = 12,
                PatientFirstName = "Emily",
                PatientLastName = "Chen",
                PatientStreetAddress = "234 Birch Rd",
                PatientCity = "Issaquah",
                PatientState = "WA",
                PatientZip = "98029",
                PatientPhone = "425-555-0112",
                PatientEmail = "emily.chen@gmail.com",
                PatientSSN = "123-45-6800",
                PatientDOB = DateTime.Parse("2007-11-05"),
                PatientMinor = true,
                PatientHOHID = null
            },

            // Lee Family
            new Patient
            {
                PatientID = 13,
                PatientFirstName = "William",
                PatientLastName = "Lee",
                PatientStreetAddress = "345 Spruce Way",
                PatientCity = "Sammamish",
                PatientState = "WA",
                PatientZip = "98074",
                PatientPhone = "425-555-0113",
                PatientEmail = "william.lee@gmail.com",
                PatientSSN = "123-45-6801",
                PatientDOB = DateTime.Parse("1983-02-28"),
                PatientMinor = false,
                PatientHOHID = -1
            },
            new Patient
            {
                PatientID = 14,
                PatientFirstName = "Sophie",
                PatientLastName = "Lee",
                PatientStreetAddress = "345 Spruce Way",
                PatientCity = "Sammamish",
                PatientState = "WA",
                PatientZip = "98074",
                PatientPhone = "425-555-0114",
                PatientEmail = "sophie.lee@gmail.com",
                PatientSSN = "123-45-6802",
                PatientDOB = DateTime.Parse("2014-09-14"),
                PatientMinor = true,
                PatientHOHID = 13
            },
            new Patient
            {
                PatientID = 15,
                PatientFirstName = "Oliver",
                PatientLastName = "Lee",
                PatientStreetAddress = "345 Spruce Way",
                PatientCity = "Sammamish",
                PatientState = "WA",
                PatientZip = "98074",
                PatientPhone = "425-555-0115",
                PatientEmail = "oliver.lee@gmail.com",
                PatientSSN = "123-45-6803",
                PatientDOB = DateTime.Parse("2016-04-20"),
                PatientMinor = true,
                PatientHOHID = 13
            }
        );

            modelBuilder.Entity<Service>().HasData(
            new Service
            {
                ServiceID = 1,
                ServiceDescription = "Basic Cleaning",
                ServiceCost = 75.00M
            },
            new Service
            {
                ServiceID = 2,
                ServiceDescription = "X-Ray",
                ServiceCost = 125.00M
            },
            new Service
            {
                ServiceID = 3,
                ServiceDescription = "Cavity Filling",
                ServiceCost = 200.00M
            },
            new Service
            {
                ServiceID = 4,
                ServiceDescription = "Root Canal",
                ServiceCost = 800.00M
            },
            new Service
            {
                ServiceID = 5,
                ServiceDescription = "Teeth Whitening",
                ServiceCost = 350.00M
            },
            new Service
            {
                ServiceID = 6,
                ServiceDescription = "Dental Crown",
                ServiceCost = 1200.00M
            },
            new Service
            {
                ServiceID = 7,
                ServiceDescription = "Dental Bridge",
                ServiceCost = 2500.00M
            },
            new Service
            {
                ServiceID = 8,
                ServiceDescription = "Tooth Extraction",
                ServiceCost = 150.00M
            },
            new Service
            {
                ServiceID = 9,
                ServiceDescription = "Deep Cleaning",
                ServiceCost = 200.00M
            },
            new Service
            {
                ServiceID = 10,
                ServiceDescription = "Fluoride Treatment",
                ServiceCost = 35.00M
            },
            new Service
            {
                ServiceID = 11,
                ServiceDescription = "Dental Sealants",
                ServiceCost = 45.00M
            },
            new Service
            {
                ServiceID = 12,
                ServiceDescription = "Dental Implant",
                ServiceCost = 3000.00M
            },
            new Service
            {
                ServiceID = 13,
                ServiceDescription = "Wisdom Tooth Removal",
                ServiceCost = 450.00M
            },
            new Service
            {
                ServiceID = 14,
                ServiceDescription = "Dental Consultation",
                ServiceCost = 50.00M
            },
            new Service
            {
                ServiceID = 15,
                ServiceDescription = "Emergency Dental Care",
                ServiceCost = 250.00M
            }
        );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    AppointmentID = 1,
                    DentistID = 1,
                    PatientID = 1,
                    TypeID = 1,
                    AppointmentDate = DateTime.Parse("2024-11-15"),
                    StartTime = DateTime.Parse("2024-11-15 09:00:00")
                },
                new Appointment
                {
                    AppointmentID = 2,
                    DentistID = 2,
                    PatientID = 2,
                    TypeID = 1,
                    AppointmentDate = DateTime.Parse("2024-11-15"),
                    StartTime = DateTime.Parse("2024-11-15 10:00:00")
                },
                new Appointment
                {
                    AppointmentID = 3,
                    DentistID = 1,
                    PatientID = 3,
                    TypeID = 16, // Preventative Care - Adult
                    AppointmentDate = DateTime.Parse("2024-11-16"),
                    StartTime = DateTime.Parse("2024-11-16 09:00:00")
                },
                new Appointment
                {
                    AppointmentID = 4,
                    DentistID = 2,
                    PatientID = 4,
                    TypeID = 17, // Preventative Care - Child
                    AppointmentDate = DateTime.Parse("2024-11-16"),
                    StartTime = DateTime.Parse("2024-11-16 10:30:00")
                },
                new Appointment
                {
                    AppointmentID = 5,
                    DentistID = 1,
                    PatientID = 7,
                    TypeID = 7, // Endodontic Procedure - Adult
                    AppointmentDate = DateTime.Parse("2024-11-17"),
                    StartTime = DateTime.Parse("2024-11-17 13:00:00")
                },
                new Appointment
                {
                    AppointmentID = 6,
                    DentistID = 2,
                    PatientID = 10,
                    TypeID = 11, // New Patient - Child
                    AppointmentDate = DateTime.Parse("2024-11-18"),
                    StartTime = DateTime.Parse("2024-11-18 09:00:00")
                },
                new Appointment
                {
                    AppointmentID = 7,
                    DentistID = 1,
                    PatientID = 12,
                    TypeID = 18, // Preventative Care - Teen
                    AppointmentDate = DateTime.Parse("2024-11-18"),
                    StartTime = DateTime.Parse("2024-11-18 14:00:00")
                },
                new Appointment
                {
                    AppointmentID = 8,
                    DentistID = 2,
                    PatientID = 5,
                    TypeID = 13, // Periodontal Treatment - Adult
                    AppointmentDate = DateTime.Parse("2024-11-19"),
                    StartTime = DateTime.Parse("2024-11-19 11:00:00")
                },
                new Appointment
                {
                    AppointmentID = 9,
                    DentistID = 1,
                    PatientID = 14,
                    TypeID = 5, // Cosmetic Procedure - Child
                    AppointmentDate = DateTime.Parse("2024-11-20"),
                    StartTime = DateTime.Parse("2024-11-20 09:00:00")
                },
                new Appointment
                {
                    AppointmentID = 10,
                    DentistID = 2,
                    PatientID = 8,
                    TypeID = 19, // Prosthodontic Care - Adult
                    AppointmentDate = DateTime.Parse("2024-11-20"),
                    StartTime = DateTime.Parse("2024-11-20 13:30:00")
                }
            );

            // Seed Visits (past appointments that occurred)
            modelBuilder.Entity<Visit>().HasData(
                new Visit
                {
                    VisitID = 1,
                    DentistID = 1,
                    PatientID = 1,
                    VisitDate = DateTime.Parse("2024-05-15")
                },
                new Visit
                {
                    VisitID = 2,
                    DentistID = 2,
                    PatientID = 2,
                    VisitDate = DateTime.Parse("2024-05-15")
                },
                new Visit
                {
                    VisitID = 3,
                    DentistID = 3,
                    PatientID = 3,
                    VisitDate = DateTime.Parse("2024-05-16")
                },
                new Visit
                {
                    VisitID = 4,
                    DentistID = 1,
                    PatientID = 4,
                    VisitDate = DateTime.Parse("2024-05-16")
                },
                new Visit
                {
                    VisitID = 5,
                    DentistID = 2,
                    PatientID = 5,
                    VisitDate = DateTime.Parse("2024-05-17")
                },
                new Visit
                {
                    VisitID = 6,
                    DentistID = 4,
                    PatientID = 6,
                    VisitDate = DateTime.Parse("2024-05-17")
                },
                new Visit
                {
                    VisitID = 7,
                    DentistID = 5,
                    PatientID = 7,
                    VisitDate = DateTime.Parse("2024-05-20")
                },
                new Visit
                {
                    VisitID = 8,
                    DentistID = 3,
                    PatientID = 8,
                    VisitDate = DateTime.Parse("2024-05-20")
                },
                new Visit
                {
                    VisitID = 9,
                    DentistID = 4,
                    PatientID = 9,
                    VisitDate = DateTime.Parse("2024-05-21")
                },
                new Visit
                {
                    VisitID = 10,
                    DentistID = 5,
                    PatientID = 10,
                    VisitDate = DateTime.Parse("2024-05-21")
                }
            );

            // Seed CompletedServices
            modelBuilder.Entity<CompletedService>().HasData(
                new CompletedService
                {
                    ServiceID = 1,
                    VisitID = 1
                },
                new CompletedService
                {
                    ServiceID = 2,
                    VisitID = 1
                },
                new CompletedService
                {
                    ServiceID = 1,
                    VisitID = 2
                },
                new CompletedService
                {
                    ServiceID = 3,
                    VisitID = 3
                },
                new CompletedService
                {
                    ServiceID = 2,
                    VisitID = 4
                },
                new CompletedService
                {
                    ServiceID = 1,
                    VisitID = 5
                },
                new CompletedService
                {
                    ServiceID = 3,
                    VisitID = 6
                },
                new CompletedService
                {
                    ServiceID = 2,
                    VisitID = 7
                },
                new CompletedService
                {
                    ServiceID = 1,
                    VisitID = 8
                },
                new CompletedService
                {
                    ServiceID = 3,
                    VisitID = 9
                }
            );
        }
    }
}