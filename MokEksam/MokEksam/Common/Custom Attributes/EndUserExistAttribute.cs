using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using MokEksam.Persistency;

namespace MokEksam.Common.Custom_Attributes
{
    /// <summary>
    /// Klassen arver fra den abstrakte klasse ValidationAttribute for at få at adgang til IsValid()
    /// Attributen bruges til at validere en property i EndUserViewModel kaldet "Username"
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    class EndUserExistAttribute : ValidationAttribute
    {
        // Oprettelse af et objekt for at se om brugernavn er optaget.
        readonly ConnectEndUserDbService _connectEndUserDbService = new ConnectEndUserDbService();
        /// <summary>
        /// Metoden tjekker først om de første valideringer af "Username" er gennemført, 
        /// før den åbner en forbindelse til database for at finde en muligvis eksisterende bruger.
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
            // Hvis længde på input ikke er længere end fire karakterer, 
            // så er der ingen grund til belaste netværket med en forespørgelse for at se om en bruger eksisterer!
            if (valueAsString != null && valueAsString.Length < 4)
            {
                return true;
            }
            // Hvis indholdet af input ikke overholder kravene, 
            // så er der ingen grund til belaste netværket med en forespørgelse for at se om en bruger eksisterer!
            if (!Regex.IsMatch(valueAsString, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            // Med omvendt fortegn - hvis de er ens, så eksisterer bruger, hvis ikke, så er brugernavn ledigt.
            if (Regex.IsMatch(valueAsString, @"^[a-zA-Z]+$"))
            {
                return !string.Equals(valueAsString, _connectEndUserDbService.GetEndUserByNameAsync(valueAsString));
            }
            else
            {
                return false;
            }
        }
    }
}
