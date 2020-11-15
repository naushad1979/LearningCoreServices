using System;

namespace Account.Api.Models
{
    public class UserRegistration
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
