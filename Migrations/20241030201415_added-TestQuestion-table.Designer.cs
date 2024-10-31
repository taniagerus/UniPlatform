﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UniPlatform.DB;

#nullable disable

namespace UniPlatform.Migrations
{
    [DbContext(typeof(PlatformDbContext))]
    [Migration("20241030201415_added-TestQuestion-table")]
    partial class addedTestQuestiontable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssistantId")
                        .HasColumnType("integer");

                    b.Property<int>("Credits")
                        .HasColumnType("integer");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<int>("LecturerId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AssistantId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("LecturerId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.CourseGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<string>("GroupId1")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("GroupId1");

                    b.ToTable("CourseGroups");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.CourseStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudents");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Options")
                        .HasColumnType("text");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TestAssignmentId")
                        .HasColumnType("integer");

                    b.Property<int?>("TestCategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TestAssignmentId");

                    b.HasIndex("TestCategoryId");

                    b.ToTable("TestQuestions");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.StudentAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Points")
                        .HasColumnType("numeric");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("TestAttemptId")
                        .HasColumnType("integer");

                    b.Property<string>("TextAnswer")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("TestAttemptId");

                    b.ToTable("StudentAnswers");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.StudentGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<string>("GroupId1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GroupId1");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentGroups");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.TestAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("MaxPoints")
                        .HasColumnType("numeric");

                    b.Property<int>("NumberOfQuestions")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.Property<int>("TimeLimit")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TestAssignments");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.TestAttempt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("Score")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.Property<int>("TestAssignmentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TestAssignmentId");

                    b.ToTable("TestAttempts");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.TestCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("TestCategories");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.TestOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CorrectOrder")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<string>("MatchingPair")
                        .HasColumnType("text");

                    b.Property<string>("OptionText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<int?>("StudentAnswerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("StudentAnswerId");

                    b.ToTable("TestOptions");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("UserStatus")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("UniPlatform.Models.Group", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("CourseNumber")
                        .HasColumnType("integer");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DepartmentId1")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId1");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Assistant", b =>
                {
                    b.HasBaseType("UniPlatform.DB.Entities.User");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<int>("LecturerId")
                        .HasColumnType("integer");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("LecturerId");

                    b.ToTable("AspNetUsers", t =>
                        {
                            t.Property("DepartmentId")
                                .HasColumnName("Assistant_DepartmentId");
                        });

                    b.HasDiscriminator().HasValue("Assistant");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Lecturer", b =>
                {
                    b.HasBaseType("UniPlatform.DB.Entities.User");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.HasIndex("DepartmentId");

                    b.ToTable("AspNetUsers", t =>
                        {
                            t.Property("DepartmentId")
                                .HasColumnName("Lecturer_DepartmentId");
                        });

                    b.HasDiscriminator().HasValue("Lecturer");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Student", b =>
                {
                    b.HasBaseType("UniPlatform.DB.Entities.User");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<int>("EducationLevel")
                        .HasColumnType("integer");

                    b.HasIndex("DepartmentId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("UniPlatform.DB.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("UniPlatform.DB.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniPlatform.DB.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("UniPlatform.DB.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Course", b =>
                {
                    b.HasOne("UniPlatform.DB.Entities.Assistant", null)
                        .WithMany("AssistingCourses")
                        .HasForeignKey("AssistantId");

                    b.HasOne("UniPlatform.DB.Entities.Department", null)
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("UniPlatform.DB.Entities.Lecturer", "Lecturer")
                        .WithMany("AssignedCourses")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.CourseGroup", b =>
                {
                    b.HasOne("UniPlatform.DB.Entities.Course", "Course")
                        .WithMany("CourseGroups")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniPlatform.Models.Group", "Group")
                        .WithMany("CourseGroup")
                        .HasForeignKey("GroupId1");

                    b.Navigation("Course");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.CourseStudent", b =>
                {
                    b.HasOne("UniPlatform.DB.Entities.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniPlatform.DB.Entities.Student", "Student")
                        .WithMany("CourseStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Question", b =>
                {
                    b.HasOne("UniPlatform.DB.Entities.TestAssignment", null)
                        .WithMany("Questions")
                        .HasForeignKey("TestAssignmentId");

                    b.HasOne("UniPlatform.DB.Entities.TestCategory", null)
                        .WithMany("Questions")
                        .HasForeignKey("TestCategoryId");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.StudentAnswer", b =>
                {
                    b.HasOne("UniPlatform.DB.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniPlatform.DB.Entities.TestAttempt", "TestAttempt")
                        .WithMany("Answers")
                        .HasForeignKey("TestAttemptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("TestAttempt");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.StudentGroup", b =>
                {
                    b.HasOne("UniPlatform.Models.Group", "Group")
                        .WithMany("StudentGroups")
                        .HasForeignKey("GroupId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniPlatform.DB.Entities.Student", "Student")
                        .WithMany("StudentGroups")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.TestAttempt", b =>
                {
                    b.HasOne("UniPlatform.DB.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniPlatform.DB.Entities.TestAssignment", "TestAssignment")
                        .WithMany("Attempts")
                        .HasForeignKey("TestAssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("TestAssignment");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.TestCategory", b =>
                {
                    b.HasOne("UniPlatform.DB.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.TestOption", b =>
                {
                    b.HasOne("UniPlatform.DB.Entities.Question", "Question")
                        .WithMany("TestOptions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniPlatform.DB.Entities.StudentAnswer", null)
                        .WithMany("SelectedOptions")
                        .HasForeignKey("StudentAnswerId");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("UniPlatform.Models.Group", b =>
                {
                    b.HasOne("UniPlatform.DB.Entities.Department", "Department")
                        .WithMany("Groups")
                        .HasForeignKey("DepartmentId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Assistant", b =>
                {
                    b.HasOne("UniPlatform.DB.Entities.Department", "Department")
                        .WithMany("Assistants")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniPlatform.DB.Entities.Lecturer", "Lecturer")
                        .WithMany("Assistants")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Lecturer", b =>
                {
                    b.HasOne("UniPlatform.DB.Entities.Department", "Department")
                        .WithMany("Lecturers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Student", b =>
                {
                    b.HasOne("UniPlatform.DB.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Course", b =>
                {
                    b.Navigation("CourseGroups");

                    b.Navigation("CourseStudents");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Department", b =>
                {
                    b.Navigation("Assistants");

                    b.Navigation("Courses");

                    b.Navigation("Groups");

                    b.Navigation("Lecturers");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Question", b =>
                {
                    b.Navigation("TestOptions");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.StudentAnswer", b =>
                {
                    b.Navigation("SelectedOptions");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.TestAssignment", b =>
                {
                    b.Navigation("Attempts");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.TestAttempt", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.TestCategory", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("UniPlatform.Models.Group", b =>
                {
                    b.Navigation("CourseGroup");

                    b.Navigation("StudentGroups");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Assistant", b =>
                {
                    b.Navigation("AssistingCourses");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Lecturer", b =>
                {
                    b.Navigation("AssignedCourses");

                    b.Navigation("Assistants");
                });

            modelBuilder.Entity("UniPlatform.DB.Entities.Student", b =>
                {
                    b.Navigation("CourseStudents");

                    b.Navigation("StudentGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
