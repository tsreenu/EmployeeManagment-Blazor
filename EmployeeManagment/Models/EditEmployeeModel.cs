using EmployeeManagment.Models.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [EmailDomainValidator(AllowedDomain = "gmail.com", ErrorMessage = "Only gmail.com domainis allowed.")]
        public string Email { get; set; }
        [Compare("Email",ErrorMessage ="Email and Confirm Email is missmacthed.")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }
    }
}
