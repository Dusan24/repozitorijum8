using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   

        public enum Permissions
        {
            Login = 0,
            Logout = 1,
            CreateAccount = 2,
            DeleteAccount = 4,
            LockAccount = 5,
            EnableAccount = 6,
            DisableAccount = 7
        }

        public enum Roles
        {
            User = 0,
            Admin = 1
            
        }

        public class RolesConfig
        {
            static string[] UsersPermissions = new string[] { Permissions.Login.ToString(), Permissions.Logout.ToString() };
            static string[] AdminsPermissions = new string[] { Permissions.CreateAccount.ToString(), Permissions.DeleteAccount.ToString(),Permissions.LockAccount.ToString(),Permissions.EnableAccount.ToString(),Permissions.DisableAccount.ToString() };
            
            static string[] Empty = new string[] { };

            public static string[] GetPermissions(string role)
            {

                switch (role)
                {
                    case "AccountUsers": return UsersPermissions;
                    case "AccountAdmins": return AdminsPermissions;
                    
                    default: return Empty;
                }
            }
        }
}
