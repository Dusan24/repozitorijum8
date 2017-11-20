using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Common
{
    [Serializable]
    [DataContract]
    public class User
    {
        private string username = String.Empty;
        private string password;

        private bool enabled = false;
        private bool locked = false;
        private bool loged = false;

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = SecurePasswordHasher.Hash(password);
            Enabled = true;
            Locked = false;
        }
        [DataMember]
        public bool Loged
        {
            get
            {
                return loged;
            }

            set
            {
                loged = value;
            }
        }


        [DataMember]
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        [DataMember]
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        [DataMember]
        public bool Enabled
        {
            get
            {
                return enabled;
            }

            set
            {
                enabled = value;
            }
        }

        [DataMember]
        public bool Locked
        {
            get
            {
                return locked;
            }

            set
            {
                locked = value;
            }
        }
    }
}
