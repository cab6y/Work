using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Work.Extras
{
    public interface IExtraAboutRepository : IRepository<ExtraAbout, Guid>
    {
        Task<List<ExtraAbout>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
