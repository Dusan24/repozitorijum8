using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace CredentialStoreProject
{
    public class CustomPrincipal : IPrincipal
    {

        //public List<string> roles = new List<string>();
        //public List<string> permissions = new List<string>();


        string[] AccountAdmins = new string[] {"CreateAccount", "DeleteAccount", "LockAccount", "EnableAccount", "DisableAccount" };
        //string[] UserPermissions = new string[] { "AccountUsers", "Login", "Logout" };
        string[] AccountUsers = new string[] { "Login", "Logout" };

        public Dictionary<string, string[]> admin = new Dictionary<string, string[]>();
        public Dictionary<string, string[]> user = new Dictionary<string, string[]>();

        
       
        public CustomPrincipal(WindowsIdentity wi)
        {
            foreach (var g in wi.Groups)
            {
                user.Add("AccountUsers", AccountUsers);
                admin.Add("AccountAdmins", AccountAdmins);

                var s = AccountAdmins;
                var sss = AccountUsers;
                   
                 
                
            }

        }


        public IIdentity Identity
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsInRole(string role)
        {
            
            if(permissions.Contains(role))
            {
                return true;

            }
            else
            {
                return false;
                    
            }

        }
    }
}
