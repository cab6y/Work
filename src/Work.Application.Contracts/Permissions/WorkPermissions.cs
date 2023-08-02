namespace Work.Permissions;

public static class WorkPermissions
{
    public const string GroupName = "Work";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class Extras
    {
        public const string Default = GroupName + ".Extras";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class ExtrasManagement
    {
        public const string Default = GroupName + ".ExtrasManagement";
    }
}
