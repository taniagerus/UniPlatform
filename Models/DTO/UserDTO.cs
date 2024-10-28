using System.ComponentModel.DataAnnotations;
using UniPlatform.DB.Entities;

namespace UniPlatform.Models.DTO
{
    public class UserDTO
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
        public string PhoneNumber { get; set; }
        public Role UserRole { get; set; }
        // Додаткові поля для різних ролей
        public string? StudentId { get; set; }
        public EducationLevelEnum? EducationLevel { get; set; }
        public int? DepartmentId { get; set; }
        public int? LecturerId { get; set; }
    }
    public class UpdateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class UpdateStatusDTO
    {
        [Required]
        public StatusEnum NewStatus { get; set; }
    }
}
