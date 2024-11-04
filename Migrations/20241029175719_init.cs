using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UniPlatform.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    Name = table.Column<string>(
                        type: "character varying(256)",
                        maxLength: 256,
                        nullable: true
                    ),
                    NormalizedName = table.Column<string>(
                        type: "character varying(256)",
                        maxLength: 256,
                        nullable: true
                    ),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    Name = table.Column<string>(type: "text", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(
                        type: "character varying(256)",
                        maxLength: 256,
                        nullable: false
                    ),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserStatus = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    LastUpdated = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    Discriminator = table.Column<string>(
                        type: "character varying(13)",
                        maxLength: 13,
                        nullable: false
                    ),
                    LecturerId = table.Column<int>(type: "integer", nullable: true),
                    Assistant_DepartmentId = table.Column<int>(type: "integer", nullable: true),
                    Lecturer_DepartmentId = table.Column<int>(type: "integer", nullable: true),
                    EducationLevel = table.Column<int>(type: "integer", nullable: true),
                    DepartmentId = table.Column<int>(type: "integer", nullable: true),
                    UserName = table.Column<string>(
                        type: "character varying(256)",
                        maxLength: 256,
                        nullable: true
                    ),
                    NormalizedUserName = table.Column<string>(
                        type: "character varying(256)",
                        maxLength: 256,
                        nullable: true
                    ),
                    NormalizedEmail = table.Column<string>(
                        type: "character varying(256)",
                        maxLength: 256,
                        nullable: true
                    ),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_Assistant_DepartmentId",
                        column: x => x.Assistant_DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_Lecturer_DepartmentId",
                        column: x => x.Lecturer_DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CourseNumber = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<string>(type: "text", nullable: false),
                    DepartmentId1 = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Departments_DepartmentId1",
                        column: x => x.DepartmentId1,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_AspNetUserLogins",
                        x => new { x.LoginProvider, x.ProviderKey }
                    );
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_AspNetUserTokens",
                        x => new
                        {
                            x.UserId,
                            x.LoginProvider,
                            x.Name,
                        }
                    );
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Credits = table.Column<int>(type: "integer", nullable: false),
                    LecturerId = table.Column<int>(type: "integer", nullable: false),
                    AssistantId = table.Column<int>(type: "integer", nullable: true),
                    DepartmentId = table.Column<int>(type: "integer", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_AssistantId",
                        column: x => x.AssistantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "StudentGroups",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    GroupId1 = table.Column<string>(type: "text", nullable: false),
                    JoinDate = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentGroups_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_StudentGroups_Groups_GroupId1",
                        column: x => x.GroupId1,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "CourseGroups",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    GroupId1 = table.Column<string>(type: "text", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseGroups_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_CourseGroups_Groups_GroupId1",
                        column: x => x.GroupId1,
                        principalTable: "Groups",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "CourseStudents",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseStudents_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_CourseStudents_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "TestCategories",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCategories_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "TestAssignments",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    EndTime = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    TimeLimit = table.Column<int>(type: "integer", nullable: false),
                    MaxPoints = table.Column<decimal>(type: "numeric", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    NumberOfQuestions = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestAssignments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_TestAssignments_TestCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TestCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "TestQuestions",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Difficulty = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestQuestions_TestCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TestCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "TestAttempts",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    TestAssignmentId = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    EndTime = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                    Score = table.Column<decimal>(type: "numeric", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestAttempts_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_TestAttempts_TestAssignments_TestAssignmentId",
                        column: x => x.TestAssignmentId,
                        principalTable: "TestAssignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "TestAssignmentQuestions",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "integer", nullable: false),
                    TestAssignmentsId = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_TestAssignmentQuestions",
                        x => new { x.QuestionsId, x.TestAssignmentsId }
                    );
                    table.ForeignKey(
                        name: "FK_TestAssignmentQuestions_TestAssignments_TestAssignmentsId",
                        column: x => x.TestAssignmentsId,
                        principalTable: "TestAssignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_TestAssignmentQuestions_TestQuestions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "TestQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "TestOptions",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    OptionText = table.Column<string>(type: "text", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    CorrectOrder = table.Column<int>(type: "integer", nullable: true),
                    MatchingPair = table.Column<string>(type: "text", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestOptions_TestQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "TestQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "StudentAnswers",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    TestAttemptId = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    TextAnswer = table.Column<string>(type: "text", nullable: true),
                    Points = table.Column<decimal>(type: "numeric", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAnswers_TestAttempts_TestAttemptId",
                        column: x => x.TestAttemptId,
                        principalTable: "TestAttempts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_StudentAnswers_TestQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "TestQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "StudentAnswerOptions",
                columns: table => new
                {
                    SelectedOptionsId = table.Column<int>(type: "integer", nullable: false),
                    StudentAnswerId = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_StudentAnswerOptions",
                        x => new { x.SelectedOptionsId, x.StudentAnswerId }
                    );
                    table.ForeignKey(
                        name: "FK_StudentAnswerOptions_StudentAnswers_StudentAnswerId",
                        column: x => x.StudentAnswerId,
                        principalTable: "StudentAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_StudentAnswerOptions_TestOptions_SelectedOptionsId",
                        column: x => x.SelectedOptionsId,
                        principalTable: "TestOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId"
            );

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId"
            );

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail"
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Assistant_DepartmentId",
                table: "AspNetUsers",
                column: "Assistant_DepartmentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Lecturer_DepartmentId",
                table: "AspNetUsers",
                column: "Lecturer_DepartmentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LecturerId",
                table: "AspNetUsers",
                column: "LecturerId"
            );

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroups_CourseId",
                table: "CourseGroups",
                column: "CourseId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroups_GroupId1",
                table: "CourseGroups",
                column: "GroupId1"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AssistantId",
                table: "Courses",
                column: "AssistantId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LecturerId",
                table: "Courses",
                column: "LecturerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_CourseId",
                table: "CourseStudents",
                column: "CourseId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_StudentId",
                table: "CourseStudents",
                column: "StudentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Groups_DepartmentId1",
                table: "Groups",
                column: "DepartmentId1"
            );

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswerOptions_StudentAnswerId",
                table: "StudentAnswerOptions",
                column: "StudentAnswerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_QuestionId",
                table: "StudentAnswers",
                column: "QuestionId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_TestAttemptId",
                table: "StudentAnswers",
                column: "TestAttemptId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroups_GroupId1",
                table: "StudentGroups",
                column: "GroupId1"
            );

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroups_StudentId",
                table: "StudentGroups",
                column: "StudentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TestAssignmentQuestions_TestAssignmentsId",
                table: "TestAssignmentQuestions",
                column: "TestAssignmentsId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TestAssignments_CategoryId",
                table: "TestAssignments",
                column: "CategoryId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TestAssignments_CourseId",
                table: "TestAssignments",
                column: "CourseId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TestAttempts_StudentId",
                table: "TestAttempts",
                column: "StudentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TestAttempts_TestAssignmentId",
                table: "TestAttempts",
                column: "TestAssignmentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TestCategories_CourseId",
                table: "TestCategories",
                column: "CourseId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TestOptions_QuestionId",
                table: "TestOptions",
                column: "QuestionId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_CategoryId",
                table: "TestQuestions",
                column: "CategoryId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "AspNetRoleClaims");

            migrationBuilder.DropTable(name: "AspNetUserClaims");

            migrationBuilder.DropTable(name: "AspNetUserLogins");

            migrationBuilder.DropTable(name: "AspNetUserRoles");

            migrationBuilder.DropTable(name: "AspNetUserTokens");

            migrationBuilder.DropTable(name: "CourseGroups");

            migrationBuilder.DropTable(name: "CourseStudents");

            migrationBuilder.DropTable(name: "StudentAnswerOptions");

            migrationBuilder.DropTable(name: "StudentGroups");

            migrationBuilder.DropTable(name: "TestAssignmentQuestions");

            migrationBuilder.DropTable(name: "AspNetRoles");

            migrationBuilder.DropTable(name: "StudentAnswers");

            migrationBuilder.DropTable(name: "TestOptions");

            migrationBuilder.DropTable(name: "Groups");

            migrationBuilder.DropTable(name: "TestAttempts");

            migrationBuilder.DropTable(name: "TestQuestions");

            migrationBuilder.DropTable(name: "TestAssignments");

            migrationBuilder.DropTable(name: "TestCategories");

            migrationBuilder.DropTable(name: "Courses");

            migrationBuilder.DropTable(name: "AspNetUsers");

            migrationBuilder.DropTable(name: "Departments");
        }
    }
}
