using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Work.Extras
{
    public class GetExtraListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
