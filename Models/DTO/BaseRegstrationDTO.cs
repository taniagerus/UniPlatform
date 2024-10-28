// DTOs for Registration
using System.ComponentModel.DataAnnotations;
using UniPlatform.DB.Entities;

namespace UniPlatform.Models.DTO
{
    public class BaseRegistrationDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

    }

    public class StudentRegistrationDTO : BaseRegistrationDTO
    {
        [Required]
        public string StudentId { get; set; }
        [Required]
        public EducationLevelEnum EducationLevel { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }

    public class LecturerRegistrationDTO : BaseRegistrationDTO
    {
        [Required]
        public int DepartmentId { get; set; }
        // Додаткові поля специфічні для викладача
        public string AcademicDegree { get; set; }
    }

    public class AssistantRegistrationDTO : BaseRegistrationDTO
    {
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int LecturerId { get; set; }
    }

    public class AdminRegistrationDTO : BaseRegistrationDTO
    {
        // Специфічні поля для адміністратора, якщо потрібні
    }

   
}