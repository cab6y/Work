﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Work.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Work.Extras
{
    public class EfCoreExtraRepository : EfCoreRepository<WorkDbContext, Extra, Guid>,
            IExtraRepository
    {
        public EfCoreExtraRepository(
         IDbContextProvider<WorkDbContext> dbContextProvider)
         : base(dbContextProvider)
        {
        }


        public async Task<List<Extra>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    a => a.Id.ToString().Contains(filter)
                )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
