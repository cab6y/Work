using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Work.Extras
{
    public interface IExtraAppService : IApplicationService
    {
        Task<bool> CreateAsync(CreateUpdateExtra input);
        Task<bool> UpdateAsync(Guid id, CreateUpdateExtra input);
        Task<bool> DeleteAsync(Guid id);
        Task<ExtraDto> GetAsync(Guid id);
        Task<List<string>> GetAllVideos(Guid id);
        Task<ExtraDto> GetOnCurrenUserAsync();
        Task<PagedResultDto<ExtraDto>> GetListAsync(GetExtraListDto input);
    }
}
