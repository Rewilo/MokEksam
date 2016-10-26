using System;
using System.ComponentModel.DataAnnotations;
using MokEksam.Handler;

namespace MokEksam.Common.Custom_Attributes
{
    /// <summary>
    /// Klassen arver fra den abstrakte klasse ValidationAttribute for at få at adgang til IsValid()
    /// Attributen bruges til at validere en property i EndUserViewModel kaldet "ConfirmPassword"
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    class ConfirmPasswordAttribute : ValidationAttribute
    {
        /// <summary>
        /// Metoden sammenligner en property i EndUserViewModel kaldet "Password" og en anden kaldet "ConfirmPassword".
        /// Hvis de er ens returnerer metoden sand.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            string pw = CreateEndUserHandler.PasswordToConfirm;
            string valueAsString = value as string;
            if (string.Equals(pw, valueAsString))
            {
                return true;
            }
            return false;
        }
    }
}
