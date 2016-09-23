using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MokEksam.ViewModel;

namespace MokEksam.Model
{
    class EndUser
    {
        private string _username;
        private string _password;
        private string _email;

        public string Username
        {
            get { return _username; }
            set
            {
                if (value.Length < 4 || value.Length > 25)
                {
                    throw new ArgumentException("Invalid Username");
                }
                if (Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    throw new ArgumentException("Invalid Username");
                }
                if (_validation.CheckUsername(value))
                {
                    
                }
                _username = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private CreateEndUserValidation _validation;
    }
}
