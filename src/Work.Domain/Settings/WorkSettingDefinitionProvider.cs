using Volo.Abp.Settings;

namespace Work.Settings;

public class WorkSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(WorkSettings.MySetting1));
    }
}
