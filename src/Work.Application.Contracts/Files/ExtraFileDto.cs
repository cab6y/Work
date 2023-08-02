using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Work.Extras;

namespace Work.Files
{
    public class ExtraFileDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public FileEnum FileEnum { get; set; }
    }
}
