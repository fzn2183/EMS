﻿namespace EmployeeManagment.Models
{
    public class SystemProfile:UserActivity
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public int? profileId { get; set; }

        public SystemProfile Profile { get; set; }

        public ICollection<SystemProfile> Children {  get; set; }    
        public int? Order {  get; set; }    

         

    }
}
