using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Work.Web;

[Dependency(ReplaceServices = true)]
public class WorkBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Work";
}
