namespace OnlineShop.Application.Security.Permissions
{
    public static partial class AssignableToRolePermissions
    {
        public const string UserAccess = "0";
        public static readonly PermissionModel UserPermission = new PermissionModel
        {
            Name = UserAccess,
            Description = "دسترسی به کاربران",
        };
    }
}
