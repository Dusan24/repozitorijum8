using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Common
{
    [DataContract]
    public class User
    {
        private string username = String.Empty;
        private string password = String.Empty;

        private bool enabled = false;
        private bool locked = false;

        public Account(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            Enabled = true;
            Locked = false;
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
