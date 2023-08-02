using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Work.Files
{
    public interface IExtraFileRepository : IRepository<ExtraFile, Guid>
    {
    }
}
