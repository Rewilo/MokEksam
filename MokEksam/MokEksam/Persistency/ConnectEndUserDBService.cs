using MokEksam.EndUserDBService;

namespace MokEksam.Persistency
{
    /// <summary>
    /// Klassen tilbyder indtil videre en simpel service - forbindelse til databasen i Azure.
    /// Klassen har følgende metoder: GetEndUser og InsertEndUser
    /// </summary>
    class ConnectEndUserDbService
    {
        /// <summary>
        /// Metoden henter et navn fra databasen, hvis input stemmer overens med navnefeltet på en række i databasen.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetEndUserByNameAsync(string username)
        {
            using (EndUserDatabaseServiceClient client = new EndUserDatabaseServiceClient())
            {
                return client.GetEndUserAsync(username).Result;
            }
        }
    }
}
