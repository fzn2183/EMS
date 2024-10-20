namespace EmployeeManagment.Models
{
    public class LeaveApplication
    {
        public int Id { get; set; }

        public int Employeeno { get;set; }

        public Employee Employee { get;set; }
        public int NoofDays { get; set; }
        public int DurationId { get; set; }
        public string Description { get; set; }
        public SystemCodeDetail Duration { get; set; }
        public int leavetypeID { get; set; }
        public LeaveType Leavetype { get; set; }
        public string Attachement { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }   



    }
}
