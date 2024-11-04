using Microsoft.AspNetCore.Identity;

namespace UniPlatform.DB.Entities
{
    public class User : IdentityUser<int>
    {
        public User() { }

        //public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public StatusEnum UserStatus { get; set; }
        public Role Role { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }

        public void UpdateProfile(
            string email,
            string phoneNumber,
            string firstName,
            string lastName
        )
        {
            Email = email;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            LastUpdated = DateTime.Now;
        }
    }
}
