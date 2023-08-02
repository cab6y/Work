using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Work.Files
{
    public interface IExtraFileAppService : IApplicationService
    {
        Task<bool> CreateAsync(CreateUpdateExtraFile input);
        Task<bool> UpdateAsync(Guid Id,CreateUpdateExtraFile input);
        Task<bool> DeleteAsync(Guid Id);
        Task<PagedResultDto<ExtraFileDto>> GetListAsync(GetExtraFileListDto input);
    }
}
