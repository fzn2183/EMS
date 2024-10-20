﻿//using EmployeeMasnagment.Data.Migrations;   
using EmployeeManagment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EmployeeManagment.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
     {
        }

    public  DbSet<Employee >Employees { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Designation> Designations { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<LeaveApplication>LeaveApplications { get; set; }   
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<SystemCode> SystemCodes { get; set; }  
    public DbSet<SystemCodeDetail> SystemCodeDetails { get; set; }  
    public DbSet<LeaveType> LeaveTypes { get; set; }    
    public DbSet<City> Cities{ get; set; } 
    public DbSet<LeaveAdjustmentEntry> LeaveAdjustmentEntries { get; set; }

    public DbSet<Audit> AuditLogs { get; set; }   
    public DbSet<RoleProfile> RoleProfiles { get; set; }    

    public DbSet<Holiday> Holidays { get; set; }
    public DbSet<SystemProfile>SystemProfiles { get; set; }
    //public DbSet<LeaveApplication> LeaveApplications { get; set; }   
  
        //Method for Entry changes in Audit 
        public virtual async Task<int> SaveChangesAsync(string userId = null)
        {
            OnBeforeSavingChanges(userId);
            var result = await base.SaveChangesAsync();
            return result;

            
        }
        private void OnBeforeSavingChanges(string userId)
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged) continue;

                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Entity.GetType().Name;
                auditEntry.UserID = userId;
                auditEntries.Add(auditEntry);
                
                foreach( var property in entry.Properties)
                {
                    string  propertyName= property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue; 
                    }
                    switch (entry.State) {

                        case EntityState.Added:
                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete; ;
                            auditEntry.OldValues[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangeColumns.Add(propertyName);
                                auditEntry.AuditType = AuditType.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;

                    }

                }





            }

            foreach(var auditentry in auditEntries)
            {
                AuditLogs.Add(auditentry.ToAudit());
            }

        }

    }
}
