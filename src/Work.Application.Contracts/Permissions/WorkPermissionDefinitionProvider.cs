using Work.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Work.Permissions;

public class WorkPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(WorkPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(WorkPermissions.MyPermission1, L("Permission:MyPermission1"));

        var ExtrasPermission = myGroup.AddPermission(WorkPermissions.Extras.Default, L("Permission:Extras"));
        ExtrasPermission.AddChild(WorkPermissions.Extras.Create, L("Permission:Extras.Create"));

        var ExtrasManagementPermission = myGroup.AddPermission(WorkPermissions.ExtrasManagement.Default, L("Permission:ExtrasManagement"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<WorkResource>(name);
    }
}
