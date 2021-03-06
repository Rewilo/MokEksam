﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using MokEksam.Handler;
using MokEksam.ViewModel;

namespace MokEksam.Model
{
    public class EndUserModel
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
                if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                    {
                    throw new ArgumentException("Username must consist of only letters, not numbers");
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
                if (value[value.Length - 4].Equals('.') | value[value.Length - 3].Equals('.'))
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Email");
                }
                _email = value;
            }
        }

        
        
        /// <summary>
        /// Suspect it to be false positive.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool CheckPassword(string input)
        {
            string symbols = @"!#¤%&/()=?`";
            string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVYZXÆØÅ";
            string numbers = "1234567890";

            bool hasSymbol = false;
            bool hasCapitalLetter = false;
            bool hasNumber = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (symbols.Contains(input[i]))
                {
                    hasSymbol = true;
                }
                if (capitalLetters.Contains(input[i]))
                {
                    hasCapitalLetter = true;
                }
                if (numbers.Contains(input[i]))
                {
                    hasNumber = true;
                }
            }
            return hasSymbol && hasCapitalLetter && hasNumber;
        }

        public EndUserModel(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
            
        }

        public override string ToString()
        {
            return $"Username: {Username}, Password: {Password}, Email: {Email}";
        }
    }
}

