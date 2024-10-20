﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace EmployeeManagment.Models
{
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;

        }
        public EntityEntry Entry { get; set; }
        public string UserID { get; set; } 
        public string TableName { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string,object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string,object>();
        public Dictionary<string ,object> NewValues { get; } = new Dictionary<string,object>();
        public AuditType AuditType { get; set; }
        public List<string> ChangeColumns { get; } = new List<string>();
        public Audit ToAudit()
        {
            var audit = new Audit();
            audit.UserId = UserID;
            audit.AuditType = AuditType.ToString();
            audit.TableName = TableName;
            audit.DateTime = DateTime.Now;
            audit.PrimaryKey = JsonConvert.SerializeObject(KeyValues);
            audit.OldValues = OldValues.Count ==0 ?null:  JsonConvert.SerializeObject(OldValues);
            audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            audit.AffectedColumns = ChangeColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangeColumns);
            return audit;
        }   
     }
}
