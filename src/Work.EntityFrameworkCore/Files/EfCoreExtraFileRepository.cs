using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Work.EntityFrameworkCore;

namespace Work.Files
{
    public class EfCoreExtraFileRepository : EfCoreRepository<WorkDbContext, ExtraFile, Guid>,
            IExtraFileRepository
    {
        public EfCoreExtraFileRepository(
         IDbContextProvider<WorkDbContext> dbContextProvider)
         : base(dbContextProvider)
        {
        }

        
    }
}
