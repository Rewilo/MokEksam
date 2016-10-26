using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MokEksam.Common.Custom_Attributes
{
    /// <summary>
    /// Klassen arver fra den abstrakte klasse ValidationAttribute for at få at adgang til IsValid()
    /// Attributen bruges til at validere en property i EndUserViewModel kaldet "Email"
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    class EmailAttribute : ValidationAttribute
    {
        // Oprettelse af et objekt af typen RegexUtilities for at bruge metoden IsValidEmail()
        private RegexUtilities RegexUtilities { get; } = new RegexUtilities();
        
        /// <summary>
        /// Metoden returnerer sand hvis IsValidEmail() returnerer sand. 
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

            return RegexUtilities.IsValidEmail(valueAsString);
        }
    }
    // Jeg fandt denne klasse online - Glemte at gemme webadressen...
    public class RegexUtilities
    {
        private bool _invalid;

        /// <summary>
        /// Metoden tager imod en streng, som den bedømmer værende en email eller ej.
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public bool IsValidEmail(string strIn)
        {
            _invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (_invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                _invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
    }
}
