using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Work.Extras;

namespace Work.Files
{
    public class ExtraFile : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public FileEnum FileEnum { get; set; }
    }
}
