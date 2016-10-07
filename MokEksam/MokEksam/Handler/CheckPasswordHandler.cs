using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using MokEksam.Common;

namespace MokEksam.Handler
{
    public class CheckPasswordHandler
    {

        public bool CheckPassword(string username, string password)
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.UseDefaultCredentials = true;

                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri(Config.ConnectionUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicantion/json"));


                    var result =
                        client.GetAsync("api/Password?endUserName=" + username + "&password=" + password).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    if (result.StatusCode == HttpStatusCode.NotFound)
                    {
                        return false;
                    }
                    throw new ArgumentException("Something went wrong along the way... Try another day");
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}