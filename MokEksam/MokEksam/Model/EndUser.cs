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
                if (!_validation.CheckUsername(value))
                {
                    throw new ArgumentException("Username is already taken");
                }
                _username = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (value.Length < 8)
                {
                    throw new ArgumentException("Invalid Password");
                }
                if (!CheckPassword(value))
                {
                    throw new ArgumentException("Invalid Password");
                }
                _password = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (value.Length < 6)
                {
                    throw new ArgumentException("Invalid Email");
                }
                if (!value.Contains("@"))
                {
                    throw new ArgumentException("Invalid Email");

                }
                _email = value;
            }
        }

        private CreateEndUserValidation _validation;

        /// <summary>
        /// Suspect it to be false positive.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool CheckPassword(string input)
        {
            bool capitalLetterIndicator = Regex.IsMatch(input, @"^[\65-\90]+$");
            bool symbolIndicator = Regex.IsMatch(input, @"^[\32-\64]+$");
            if (symbolIndicator && capitalLetterIndicator)
            {
                return true;
            }
            return false;

            
        }
    }
}

