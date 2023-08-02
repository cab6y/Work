using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Work.Extras
{
    public interface IExtraRepository : IRepository<Extra, Guid>
    {
        Task<List<Extra>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
