using Work.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Work.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class WorkPageModel : AbpPageModel
{
    protected WorkPageModel()
    {
        LocalizationResourceType = typeof(WorkResource);
    }
}
