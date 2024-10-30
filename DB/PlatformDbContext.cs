using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniPlatform.DB.Entities;
using UniPlatform.Models;

namespace UniPlatform.DB
{
    public class PlatformDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public PlatformDbContext(DbContextOptions<PlatformDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<CourseGroup> CourseGroups { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }

        public DbSet<StudentGroup> StudentGroups { get; set; }

        public DbSet<TestCategory> TestCategories { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<TestOption> TestOptions { get; set; }

        public DbSet<TestAssignment> TestAssignments { get; set; }
        public DbSet<TestAttempt> TestAttempts { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //ConfigureRolesSystem(modelBuilder);
            ConfigureTestingSystem(modelBuilder);


        }

        //private void ConfigureRolesSystem(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Assistant>()
        //      .HasOne(a => a.Lecturer)
        //      .WithMany(l => l.Assistants)
        //      .HasForeignKey(a => a.LecturerId)
        //      .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<Assistant>()
        //        .HasOne(a => a.Department)
        //        .WithMany(d => d.Assistants)
        //        .HasForeignKey(a => a.DepartmentId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<Lecturer>()
        //        .HasOne(l => l.Department)
        //        .WithMany(d => d.Lecturers)
        //        .HasForeignKey(l => l.DepartmentId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<Student>()
        //        .HasOne(s => s.Department)
        //        .WithMany(d => d.Students)
        //        .HasForeignKey(s => s.DepartmentId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<Course>()
        //        .HasMany(c => c.Lecturers)
        //        .WithMany(l => l.AssignedCourses)
        //        .UsingEntity(j => j.ToTable("CourseLecturer"));

        //    modelBuilder.Entity<Course>()
        //        .HasMany(c => c.Students)
        //        .WithMany(s => s.Courses)
        //        .UsingEntity(j => j.ToTable("CourseStudent"));

        //    modelBuilder.Entity<StudentGroup>()
        //        .HasKey(sg => new { sg.StudentId, sg.GroupId });

        //    modelBuilder.Entity<StudentGroup>()
        //        .HasOne(sg => sg.Student)
        //        .WithMany(s => s.StudentGroups)
        //        .HasForeignKey(sg => sg.StudentId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    modelBuilder.Entity<StudentGroup>()
        //        .HasOne(sg => sg.Group)
        //        .WithMany(g => g.StudentGroups)
        //        .HasForeignKey(sg => sg.GroupId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    //modelBuilder.Entity<Grade>()
        //    //    .HasOne(g => g.Student)
        //    //    .WithMany(s => s.Grades)
        //    //    .HasForeignKey(g => g.StudentId)
        //    //    .OnDelete(DeleteBehavior.Cascade);

        //    //modelBuilder.Entity<Grade>()
        //    //    .HasOne(g => g.Course)
        //    //    .WithMany()
        //    //    .HasForeignKey(g => g.CourseId)
        //    //    .OnDelete(DeleteBehavior.Cascade);

        //    //modelBuilder.Entity<Stream>()
        //    //    .HasKey(s => s.Id);

        //    // Зберігання enum UserRoleEnum як рядка
        //    modelBuilder.Entity<User>()
        //        .Property(u => u.Role)
        //        .HasConversion(
        //            v => v.ToString(),
        //            v => (Role)Enum.Parse(typeof(Role), v)
        //        );

        //    // Зберігання enum EducationLevelEnum як рядка
        //    modelBuilder.Entity<Student>()
        //        .Property(s => s.EducationLevel)
        //        .HasConversion(
        //            v => v.ToString(),
        //            v => (EducationLevelEnum)Enum.Parse(typeof(EducationLevelEnum), v)
        //        );

        //    modelBuilder.Entity<Student>()
        //        .Property(s => s.FirstName)
        //        .IsRequired()
        //        .HasMaxLength(100);

        //    modelBuilder.Entity<Student>()
        //        .Property(s => s.LastName)
        //        .IsRequired()
        //        .HasMaxLength(100);

        //    modelBuilder.Entity<User>()
        //        .Property(u => u.Email)
        //        .IsRequired()
        //        .HasMaxLength(256);

        //    modelBuilder.Entity<User>()
        //        .HasIndex(u => u.Email)
        //        .IsUnique();
        //}
        private void ConfigureTestingSystem(ModelBuilder modelBuilder)
        {
            //    // TestQuestion - TestOption relationship
            //    modelBuilder.Entity<TestQuestion>()
            //        .HasMany(q => q.Options)
            //        .WithOne(o => o.Question)
            //        .HasForeignKey(o => o.QuestionId)
            //        .OnDelete(DeleteBehavior.Cascade);

            //    // TestAssignment - TestQuestion many-to-many relationship
            //modelBuilder.Entity<TestAssignment>()
            //    .HasMany(t => t.Questions)
            //    .WithMany(q => q.TestAssignments)
            //    .UsingEntity(j => j.ToTable("TestAssignmentQuestions"));

            ////    // StudentAnswer - TestOption many-to-many relationship
            //modelBuilder.Entity<StudentAnswer>()
            //        .HasMany(sa => sa.SelectedOptions)
            //        .WithMany()
            //        .UsingEntity(j => j.ToTable("StudentAnswerOptions"));

            //    // GradingScheme unique constraint
            //    modelBuilder.Entity<GradingScheme>()
            //        .HasIndex(gs => new { gs.CourseId, gs.CategoryId, gs.Difficulty })
            //        .IsUnique();

            //    // TestAssignment constraints
            //    modelBuilder.Entity<TestAssignment>()
            //        .Property(ta => ta.MaxPoints)
            //        .HasPrecision(6, 2);


            //    // StudentAnswer constraints
            //    modelBuilder.Entity<StudentAnswer>()
            //        .Property(sa => sa.Points)
            //        .HasPrecision(6, 2);
            //}
        }
    }
}
