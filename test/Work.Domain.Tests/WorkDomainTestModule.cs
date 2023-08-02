using Work.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Work;

[DependsOn(
    typeof(WorkEntityFrameworkCoreTestModule)
    )]
public class WorkDomainTestModule : AbpModule
{

}
