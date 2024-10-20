namespace EmployeeManagment.Models
{
    public class LeaveRequest:UserActivity
    {
        public int Id{ get; set; }
        public int EmployeeId { get; set; }
        public int NumofDays { get; set; }
       
     //   public Employee Employee { get; set; }
        public int LeaveTypeId { get; set; }

        public LeaveType LeaveType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    
        public string? Attachment { get; set; }

        public string Description { get; set; }

    }

}
