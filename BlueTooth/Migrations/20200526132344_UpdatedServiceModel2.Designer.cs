﻿// <auto-generated />
using System;
using BlueTooth.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlueTooth.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200526132344_UpdatedServiceModel2")]
    partial class UpdatedServiceModel2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlueTooth.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasMaxLength(50);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BlueTooth.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("BlueTooth.Models.DentalCheckUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("DentalChecks");
                });

            modelBuilder.Entity("BlueTooth.Models.DentalCheck_Worker", b =>
                {
                    b.Property<int>("DentalCheckUpId")
                        .HasColumnType("int");

                    b.Property<string>("WorkerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DentalCheckUpId", "WorkerId");

                    b.HasIndex("WorkerId");

                    b.ToTable("DentalCheck_Workers");
                });

            modelBuilder.Entity("BlueTooth.Models.Diagnose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("BlueTooth.Models.EstablishedDiagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DentalCheckUpId")
                        .HasColumnType("int");

                    b.Property<int>("DiagnoseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DentalCheckUpId");

                    b.HasIndex("DiagnoseId");

                    b.ToTable("EstablishedDiagnosis");
                });

            modelBuilder.Entity("BlueTooth.Models.Firma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Firme");
                });

            modelBuilder.Entity("BlueTooth.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("BlueTooth.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jednopovršinska plomba",
                            Price = 30f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dvopovršinska plomba",
                            Price = 40f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Višepovršinska plomba",
                            Price = 50f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Liječenje jednokorjenog zuba",
                            Price = 70f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 5,
                            Name = "Liječenje višekorjenog zuba",
                            Price = 120f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 6,
                            Name = "Extrakcija (vađenje zuba)",
                            Price = 30f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 7,
                            Name = "Extrakcija zuba sa šivanjem",
                            Price = 50f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 8,
                            Name = "Extrakcija mliječnog zuba",
                            Price = 20f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 9,
                            Name = "Zalivanje fisura",
                            Price = 20f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 10,
                            Name = "Čišćenje zubnog kamenca",
                            Price = 40f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 11,
                            Name = "Bijeljenje zuba",
                            Price = 350f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 12,
                            Name = "Bijeljenje liječenog zuba",
                            Price = 80f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 13,
                            Name = "Metalokeramička kruna",
                            Price = 160f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 14,
                            Name = "Bezmetalna (cirkonij) kruna",
                            Price = 400f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 15,
                            Name = "Totalna proteza",
                            Price = 300f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 16,
                            Name = "Parcijalna proteza",
                            Price = 300f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 17,
                            Name = "Parcijalna (wisil) proteza",
                            Price = 650f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 18,
                            Name = "Ugradnja implanta (straumann)",
                            Price = 1500f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 19,
                            Name = "Ugradnja implanta (mis)",
                            Price = 1200f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 20,
                            Name = "Ugradnja implanta (direct)",
                            Price = 1000f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 21,
                            Name = "Hirurško vađenje umnjaka",
                            Price = 160f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 22,
                            Name = "Hirurško vađenje zuba",
                            Price = 100f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 23,
                            Name = "Apikotomija (uklanjanje vrha korjena zuba)",
                            Price = 160f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 24,
                            Name = "Incizija",
                            Price = 70f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 25,
                            Name = "Ortodontski mobilni aparat",
                            Price = 350f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 26,
                            Name = "Ortodontski fiksni aparat (metalne bravice)",
                            Price = 1200f,
                            UserId = 0
                        },
                        new
                        {
                            Id = 27,
                            Name = "Ortodontski fiksni aparat (estetske bravice)",
                            Price = 1200f,
                            UserId = 0
                        });
                });

            modelBuilder.Entity("BlueTooth.Models.Worker", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BlueTooth.Models.Appointment", b =>
                {
                    b.HasOne("BlueTooth.Models.ApplicationUser", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("BlueTooth.Models.DentalCheckUp", b =>
                {
                    b.HasOne("BlueTooth.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlueTooth.Models.DentalCheck_Worker", b =>
                {
                    b.HasOne("BlueTooth.Models.DentalCheckUp", "DentalCheckUp")
                        .WithMany()
                        .HasForeignKey("DentalCheckUpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlueTooth.Models.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlueTooth.Models.EstablishedDiagnosis", b =>
                {
                    b.HasOne("BlueTooth.Models.DentalCheckUp", "DentalCheckUp")
                        .WithMany()
                        .HasForeignKey("DentalCheckUpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlueTooth.Models.Diagnose", "Diagnose")
                        .WithMany()
                        .HasForeignKey("DiagnoseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlueTooth.Models.Rating", b =>
                {
                    b.HasOne("BlueTooth.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("BlueTooth.Models.Service", b =>
                {
                    b.HasOne("BlueTooth.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("BlueTooth.Models.Worker", b =>
                {
                    b.HasOne("BlueTooth.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BlueTooth.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BlueTooth.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlueTooth.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BlueTooth.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
