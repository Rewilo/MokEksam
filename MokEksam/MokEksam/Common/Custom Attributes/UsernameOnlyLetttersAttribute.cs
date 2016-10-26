using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MokEksam.Common.Custom_Attributes
{
    /// <summary>
    /// Klassen arver fra den abstrakte klasse ValidationAttribute for at få at adgang til IsValid()
    /// Attributen bruges til at validere en property i EndUserViewModel kaldet "Username"
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    class UsernameOnlyLetttersAttribute : ValidationAttribute
    {
        /// <summary>
        /// Metoden tjekker for om brugernavn kun indeholder bogstaver.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            string valueAsString = value as string;
            return Regex.IsMatch(valueAsString, @"^[a-zA-Z]+$");
        }
    }
}
