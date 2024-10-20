using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [DisplayName("FirstName")]
        public string FirstName { get; set; }
        [DisplayName("MiddleName")]
        public string MiddleName { get; set; }
        [DisplayName("LastName")]
        public string LastName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 15 digits.")]
        public string PhoneNumber { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        [DisplayName("UserName")]
        public string UserName { get; set; }
        [DisplayName("NationalId")]
        public string? NationalId { get; set; }
        
        public string? FullName => $"{FirstName} {MiddleName} {LastName}";
        [DisplayName("User Role")]
        public string? RoleId { get; set; } 

   



    }
}
