using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CredentialStoreProject
{
   
        public enum Permissions { CreateAccount = 0, DeleteAccount, LockAccount, EnableAccount,DisableAccount }
        public enum Roles { User = 0, Admin }
        public class RolesConfig
        {
            private static ResourceManager resourceManager = null;
            private static ResourceSet resourceSet = null;
            private static object resourceLock = new object();

            private static ResourceManager ResourceManager
            {
                get
                {
                    lock (resourceLock)
                    {
                        if (ResourceManager == null)
                        {
                            resourceManager = new ResourceManager(typeof(Resource).FullName, System.Reflection.Assembly.GetExecutingAssembly());
                        }

                        return resourceManager;
                    }
                }
            }

            private static ResourceSet ResourceSet
            {
                get
                {
                    lock (resourceLock)
                    {
                        if (resourceSet == null)
                        {
                            resourceSet = ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, true);
                        }

                        return resourceSet;
                    }
                }
            }

            public static string[] GetValue(string rolename)
            {
                var resource = resourceManager.GetString(rolename);
                var retVal = resource.Split(',');
                return retVal;
            }
        }
    }

