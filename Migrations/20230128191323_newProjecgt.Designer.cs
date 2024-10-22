﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tahfezKhalid.Data;

#nullable disable

namespace tahfezKhalid.Migrations
{
    [DbContext(typeof(tahfezKhalidContext))]
    [Migration("20230128191323_newProjecgt")]
    partial class newProjecgt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1512fd48-56b8-407a-8547-271fea42ca72",
                            ConcurrencyStamp = "65fe761a-7d67-4753-a891-0795fd29a102",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "db614589-c68b-4633-a0a6-5d3518eda78e",
                            ConcurrencyStamp = "d8130867-1cdd-4e3d-b2d5-903e35ea5644",
                            Name = "memorizer",
                            NormalizedName = "MEMORIZER"
                        },
                        new
                        {
                            Id = "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                            ConcurrencyStamp = "d19168a5-c443-4a16-8220-fd771d02a77a",
                            Name = "parent",
                            NormalizedName = "PARENT"
                        },
                        new
                        {
                            Id = "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e",
                            ConcurrencyStamp = "bba4921b-024a-4ecd-a922-0699c37ce98d",
                            Name = "supervisor",
                            NormalizedName = "SUPERVISOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            RoleId = "1512fd48-56b8-407a-8547-271fea42ca72",
                            UserId = "1512fd48-56b8-407a-8547-271fea42ca72"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("tahfez.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("TypeUser")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1512fd48-56b8-407a-8547-271fea42ca72",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e39a4860-2c86-4a17-b996-74f2e4d6137a",
                            EmailConfirmed = false,
                            IdentificationNumber = "407069541",
                            LockoutEnabled = false,
                            Name = "حماده حسام العبادلة",
                            NormalizedUserName = "407069541",
                            PasswordHash = "AQAAAAEAACcQAAAAEPGuydkuxpLRYJUjILTfcrIeZqhlGnYvzyr02vrUrHtltNLt242i2iC4+SuZCtJG9A==",
                            PhoneNumber = "0595195186",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4180d4b7-70b6-43d1-ad74-27e776e79e1d",
                            TwoFactorEnabled = false,
                            TypeUser = 0,
                            UserName = "407069541"
                        });
                });

            modelBuilder.Entity("tahfezKhalid.Models.Absence", b =>
                {
                    b.Property<DateTime>("dateAbsence")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("TypeAbsence")
                        .HasColumnType("int");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.Property<int>("studentId1")
                        .HasColumnType("int");

                    b.Property<string>("studentIdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("dateAbsence", "Id");

                    b.HasIndex("studentIdentificationNumber", "studentId1");

                    b.ToTable("Absences");
                });

            modelBuilder.Entity("tahfezKhalid.Models.DailyReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateReport")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("MemorizerNew")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NumPagesReview")
                        .HasColumnType("float");

                    b.Property<double>("NumPagesSaved")
                        .HasColumnType("float");

                    b.Property<int>("SurahReviewFrom")
                        .HasColumnType("int");

                    b.Property<int>("SurahReviewTo")
                        .HasColumnType("int");

                    b.Property<int>("SurahSavedFrom")
                        .HasColumnType("int");

                    b.Property<int>("SurahSavedTo")
                        .HasColumnType("int");

                    b.Property<int>("VerseReviewFrom")
                        .HasColumnType("int");

                    b.Property<int>("VerseReviewTo")
                        .HasColumnType("int");

                    b.Property<int>("VerseSavedFrom")
                        .HasColumnType("int");

                    b.Property<int>("VerseSavedTo")
                        .HasColumnType("int");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdentificationNumber", "studentId");

                    b.ToTable("DailyReport");
                });

            modelBuilder.Entity("tahfezKhalid.Models.DeletedUser", b =>
                {
                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("userId");

                    b.ToTable("DeletedUsers");
                });

            modelBuilder.Entity("tahfezKhalid.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("NumberExams")
                        .HasColumnType("int");

                    b.Property<int>("NumberPages")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StayNumberExams")
                        .HasColumnType("int");

                    b.Property<int>("StudentsNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("tahfezKhalid.Models.Student", b =>
                {
                    b.Property<string>("IdentificationNumber")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("FinalExam")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("ParentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int>("Surah")
                        .HasColumnType("int");

                    b.Property<int>("Verse")
                        .HasColumnType("int");

                    b.HasKey("IdentificationNumber", "Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("SessionId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("tahfezKhalid.Models.UserSession", b =>
                {
                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("sessionId")
                        .HasColumnType("int");

                    b.HasKey("userId", "sessionId");

                    b.HasIndex("sessionId");

                    b.ToTable("UserSession");
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
                    b.HasOne("tahfez.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("tahfez.Models.User", null)
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

                    b.HasOne("tahfez.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("tahfez.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tahfezKhalid.Models.Absence", b =>
                {
                    b.HasOne("tahfezKhalid.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentIdentificationNumber", "studentId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");
                });

            modelBuilder.Entity("tahfezKhalid.Models.DailyReport", b =>
                {
                    b.HasOne("tahfezKhalid.Models.Student", "student")
                        .WithMany("DailyReports")
                        .HasForeignKey("IdentificationNumber", "studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");
                });

            modelBuilder.Entity("tahfezKhalid.Models.DeletedUser", b =>
                {
                    b.HasOne("tahfez.Models.User", "user")
                        .WithMany("DeletedUsers")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("tahfezKhalid.Models.Student", b =>
                {
                    b.HasOne("tahfez.Models.User", "Parent")
                        .WithMany("Students")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tahfezKhalid.Models.Session", "Session")
                        .WithMany("Students")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("tahfezKhalid.Models.UserSession", b =>
                {
                    b.HasOne("tahfezKhalid.Models.Session", "session")
                        .WithMany("UserSessions")
                        .HasForeignKey("sessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tahfez.Models.User", "user")
                        .WithMany("UserSessions")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("session");

                    b.Navigation("user");
                });

            modelBuilder.Entity("tahfez.Models.User", b =>
                {
                    b.Navigation("DeletedUsers");

                    b.Navigation("Students");

                    b.Navigation("UserSessions");
                });

            modelBuilder.Entity("tahfezKhalid.Models.Session", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("UserSessions");
                });

            modelBuilder.Entity("tahfezKhalid.Models.Student", b =>
                {
                    b.Navigation("DailyReports");
                });
#pragma warning restore 612, 618
        }
    }
}
