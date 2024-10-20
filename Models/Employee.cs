using Microsoft.CodeAnalysis.Elfie.Model.Strings;
using System.ComponentModel;

namespace EmployeeManagment.Models
{
    public class Employee : UserActivity
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName}{MiddleName}";
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Address { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? DesignationId { get; set; }
        public Designation Designation { get; set; }
        public int? GenderId { get; set; }
        public SystemCodeDetail Gender { get; set;}
      
        public string? Photo { get; set; }

        public DateTime? EmploymentDate { get; set; }
        public int? StatusId { get; set; }
         
        public SystemCodeDetail Status { get; set; }

        public DateTime? InactiveDate { get; set; }

        public int? CauseofInactivityId { get; set; }

        public SystemCodeDetail CauseofInactivity { get; set; }

         public DateTime? TerminationDate { get; set; }
         
        public int? ReasonforterminationId { get; set; }

        public SystemCodeDetail Reasonfortermination { get; set; }
        
        public int? BankId { get; set; }

        public Bank Bank { get; set; }

        public string? BankAccountNo { get; set; }

        public string? NHIF { get; set; }

        public string? CompanyEmail { get; set; }
        
        [DisplayName("Allocated Leave Balance")]
        public Decimal? AllocatedLeaveDays { get; set; }
        [DisplayName("Leave Outstanding Balance")]
        public Decimal? LeaveOuStandingBalance { get; set; }


    }
}
