using System.Threading.Tasks;

namespace Work.Data;

public interface IWorkDbSchemaMigrator
{
    Task MigrateAsync();
}
