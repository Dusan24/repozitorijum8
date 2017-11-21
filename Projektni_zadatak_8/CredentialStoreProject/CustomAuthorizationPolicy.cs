using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CredentialStoreProject
{
    public class CustomAuthorizationPolicy : IAuthorizationPolicy
    {

        private string id;
        private object locker = new object();

        public CustomAuthorizationPolicy()
        {
            this.id = Guid.NewGuid().ToString();
        }

        public string Id
        {
            get
            {
                return this.id;
            }
        }

        public ClaimSet Issuer
        {
            get
            {
                return ClaimSet.System;
            }
        }

        ClaimSet IAuthorizationPolicy.Issuer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            object list;

            if (!evaluationContext.Properties.TryGetValue("Identities", out list))
            {
                return false;
            }

            IList<IIdentity> identities = list as IList<IIdentity>;
            if (list == null || identities.Count <= 0)
            {
                return false;
            }

            evaluationContext.Properties["Principal"] = GetPrincipal(identities[0]);
            return true;
        }

        protected IPrincipal GetPrincipal(IIdentity identity)
        {
            lock (locker)
            {
                CustomPrincipal cPrincipal = null;
                cPrincipal = new CustomPrincipal((WindowsIdentity)identity);

                return cPrincipal;
            }
        }
    }
}
