using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
namespace Work.Files
{
    public class GetExtraFileListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
