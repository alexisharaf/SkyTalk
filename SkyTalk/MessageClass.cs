using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SkyTalk
{
    [Serializable()]
    class MessageClass
    {
        public string User;
        public string Password;
        public string Command;
        public string Data;

    }
}
