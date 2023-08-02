using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Work.Extras
{
    public class ExtraAboutDto : EntityDto<Guid>
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
