using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MokEksam.Common.Custom_Attributes
{
    /// <summary>
    /// Klassen arver fra den abstrakte klasse ValidationAttribute for at få at adgang til IsValid()
    /// Attributen bruges til at validere en property i EndUserViewModel kaldet "Password"
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class PasswordAttribute : ValidationAttribute
    {
        /// <summary>
        /// Metoden returnerer kun sand, hvis kodeord indholder mindst et stort bogstav, et tal
        /// eller et "tegn" (dog ikke alle tegn er mulige...).
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            string valueAsString;
            if (value != null)
            {
                 valueAsString = value as string;
            }
            else
            {
                return false;
            }
            

            string symbols = @"!#¤%&/()=?`";
            string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVYZXÆØÅ";
            string numbers = "1234567890";

            bool hasSymbol = false;
            bool hasCapitalLetter = false;
            bool hasNumber = false;

            // Lad disse to komentarer være!
            // ReSharper disable once PossibleNullReferenceException
            foreach (char letter in valueAsString)
            {
                if (symbols.Contains(letter))
                {
                    hasSymbol = true;
                }
                if (capitalLetters.Contains(letter))
                {
                    hasCapitalLetter = true;
                }
                if (numbers.Contains(letter))
                {
                    hasNumber = true;
                }
            }
            return hasSymbol && hasCapitalLetter && hasNumber;
        }
    }
}
