using Work.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Work.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(WorkEntityFrameworkCoreModule),
    typeof(WorkApplicationContractsModule)
    )]
public class WorkDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
