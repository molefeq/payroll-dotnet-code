using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePayroll.ServiceBusinessRules.Tests.TestData
{
    public class RoleTestData
    {
        public static List<Role> InitialRoles()
        {
            return new List<Role>
            {
                GetAdminRole(),
                GetSuperAdminRole()
            };
        }

        public static Role GetAdminRole()
        {
            return new Role { Id = 2, Code = "Admin", Name = "Admin" };
        }

        public static Role GetEmptyRole()
        {
            return new Role();
        }

        public static Role GetNullRole()
        {
            return null;
        }

        public static Role GetSuperAdminRole()
        {
            return new Role { Id = 3, Code = "Super_Admin", Name = "Super Admin" };
        }

        public static Role GetUserRole()
        {
            return new Role { Name = "User", Code = "USER" };
        }

        public static RoleModel GetUserRoleModel()
        {
            return new RoleModel { Name = "User", Code = "USER" };
        }

        public static RoleModel GetUpdateUserRoleModel()
        {
            return new RoleModel { Name = "User Update", Code = "USER_UP" };
        }
    }
}
