using System.Threading.Tasks;
using Work.Localization;
using Work.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Work.Permissions;

namespace Work.Web.Menus;

public class WorkMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
       
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<WorkResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                WorkMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );
        var bookStoreMenu = new ApplicationMenuItem(
                "Extras",
                l["Figuran"],
                icon: "fa fa-book"
            );
        context.Menu.AddItem(bookStoreMenu);

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
           
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            

        }
        if (await context.IsGrantedAsync(WorkPermissions.ExtrasManagement.Default))
        {
            var bookStoreMenu1 = new ApplicationMenuItem(
                "ExtrasManagement",
                l["Figuran Yönetimi"],
                icon: "fa fa-book"
            );
            context.Menu.AddItem(bookStoreMenu1);
            bookStoreMenu1.AddItem(new ApplicationMenuItem(
           "ExtrasManagement",
           l["Figuran Yönetimi"],
           url: "/AdminArea/ExtrasManagement"

        ));

        }
           
        if (await context.IsGrantedAsync(WorkPermissions.Extras.Default))
        {
            bookStoreMenu.AddItem(new ApplicationMenuItem(
              "Extras",
              l["Kişisel Bilgilerim"],
              url: "/Extras/Index"


           ));
            bookStoreMenu.AddItem(new ApplicationMenuItem(
              "Extras",
              l["Hakkımda"],
              url: "/Extras/About"


           ));
            bookStoreMenu.AddItem(new ApplicationMenuItem(
             "Extras",
             l["Dosyalarım"],
             url: "/Extras/Files"


          ));
        }
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
    }
   
}
