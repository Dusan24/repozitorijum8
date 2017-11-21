using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static CredentialStoreProject.RolesConfig;

namespace CredentialStoreProject
{
    public class CustomPrincipal : IPrincipal
    {

        public List<string> roles = new List<string>();
        public List<string> permissions = new List<string>();


        public CustomPrincipal(WindowsIdentity wi)
        {
            foreach (var g in wi.Groups)
            {
                var s = GetValue(g.Value);

                if(s.Count()!=0)
                {
                    roles.Add(g.Value);
                    foreach(var s1 in s)
                    {
                        permissions.Add(s1);
                    }
                }
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
