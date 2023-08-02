using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Work.Data;

/* This is used if database provider does't define
 * IWorkDbSchemaMigrator implementation.
 */
public class NullWorkDbSchemaMigrator : IWorkDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
