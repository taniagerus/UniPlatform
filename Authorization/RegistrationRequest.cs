﻿using UniPlatform.DB.Entities;
using System.ComponentModel.DataAnnotations;

namespace UniPlatform.Authorization
{
    public class RegistrationRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required]
        public string Password { get; set; }
        public string UserName { get; set; }

        public Role Role { get; set; }
    }
}
