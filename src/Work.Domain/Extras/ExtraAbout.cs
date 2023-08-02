using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Work.Extras
{
    public class ExtraAbout : FullAuditedAggregateRoot<Guid>
    {
        public string Instagram { get; set; }
        public string Details { get; set; }
        public string Info { get; set; }
        public bool IsProffesionalTrained { get; set; }
        public Int64 InterviewNumber { get; set; }
        public int puan { get; set; }
        public bool PlaysAdultRoles { get; set; }
    }
}
