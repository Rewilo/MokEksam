using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokEksam.ViewModel
{
    class EndUser
    {
        public string user_name { get; set; }

        public string user_password { get; set; }

        public string user_email { get; set; }

        public EndUser(string userName, string userPassword, string userEmail)
        {
            user_name = userName;
            user_password = userPassword;
            user_email = userEmail;
        }
    }
}
