namespace OnlineShop.Application.Security.Permissions
{
    public static partial class AssignableToRolePermissions
    {
        #region Fields
        private static readonly Lazy<IEnumerable<PermissionModel>> _permissionsLazy = new Lazy<IEnumerable<PermissionModel>>(GetPermision, LazyThreadSafetyMode.ExecutionAndPublication);
        #endregion

        #region GetAsSelectedList

        public static IEnumerable<PermissionModel> GetAsSelectListItems()
        {
            return Permissions.ToList();
        }

        #endregion

        #region Properties
        public static IEnumerable<PermissionModel> Permissions
        {
            get
            {
                return _permissionsLazy.Value;
            }
        }

        #endregion

        #region GetAllPermisions
        public static IEnumerable<PermissionModel> GetPermision()
        {
            List<PermissionModel> parentPermissions = typeof(AssignableToRolePermissions)
                .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                .Where(f => f.FieldType == typeof(PermissionModel))
                .Select(c => (PermissionModel)c.GetValue(null)!)
                .Where(x => x != null && !x.Name.Contains("-"))
                .ToList();

            //Set Child permissions
            foreach (var item in parentPermissions)
            {
                var childs = typeof(AssignableToRolePermissions)
                    .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                    .Where(f => f.FieldType == typeof(PermissionModel))
                    .Select(c => (PermissionModel)c.GetValue(null)!)
                    .Where(c => c != null && c.Name.IndexOf(item.Name + "-") == 0)
                    .ToList();

                item.ChildPermissions = new List<PermissionModel>()
                {
                    new PermissionModel()
                    {
                        Description = item.Description,
                        Name = item.Name,
                    }
                };

                //Add Childs to parent
                foreach (var childPermission in childs.Where(childPermission =>
                    !item.ChildPermissions.Any(c => c.Name == childPermission.Name)))
                {
                    item.ChildPermissions.Add(childPermission);
                }
            }

            return parentPermissions;
        }
        #endregion
    }

    public class PermissionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PermissionModel> ChildPermissions { get; set; }
    }
}
