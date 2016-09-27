using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MokEksam.Model;

namespace MokEksam.ViewModel
{
    class CreateEndUserValidation
    {
        private EndUser _endUser;

        public bool CheckUsername(string username)
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
                         client.GetAsync("Api/USER" + _endUser.Username).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return false;
                    }
                    if (result.StatusCode == HttpStatusCode.NotFound)
                    {
                        return true;
                    }
                    throw new ArgumentException("Something went wrong along the way... Try another day");
                }
            }
            catch (Exception e)
            {
                //TODO: Implement an appropiate exceptionhandling code.
                throw new NotImplementedException();
            }

        } 
    }
}
