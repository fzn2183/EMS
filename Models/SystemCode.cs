using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Models
{
    public class SystemCode:UserActivity
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Descrption { get; set; }
    }
}
