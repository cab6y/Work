using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Work.Extras
{
    public interface IExtraAboutAppService : IApplicationService
    {
        Task<bool> CreateAsync(CreateUpdateExtraAbout input);
        Task<bool> UpdateAsync(Guid id, CreateUpdateExtraAbout input);
        Task<bool> DeleteAsync(Guid id);
        Task<ExtraAboutDto> GetAsync(Guid id);
        Task<ExtraAboutDto> GetOnCurrenUserAsync();
    }
}
