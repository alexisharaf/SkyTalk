using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyTalk
{

    class UserTreadSettingsClass
    {

        public string username;

        public string ipadr;

        public int port;




        public UserTreadSettingsClass(string uname, string userip, int uport)
        {
            username = uname;
            ipadr = userip;
            port = uport;

        }

        public UserTreadSettingsClass()
        {

        }
    }
}
