using Volo.Abp.Modularity;

namespace Work;

[DependsOn(
    typeof(WorkApplicationModule),
    typeof(WorkDomainTestModule)
    )]
public class WorkApplicationTestModule : AbpModule
{

}
