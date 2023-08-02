using System;
using System.Collections.Generic;
using System.Text;
using Work.Localization;
using Volo.Abp.Application.Services;

namespace Work;

/* Inherit your application services from this class.
 */
public abstract class WorkAppService : ApplicationService
{
    protected WorkAppService()
    {
        LocalizationResource = typeof(WorkResource);
    }
}
