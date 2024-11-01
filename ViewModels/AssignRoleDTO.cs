﻿using System.ComponentModel.DataAnnotations;
using UniPlatform.DB.Entities;
namespace UniPlatform.DTO
{
    public class AssignRoleDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
