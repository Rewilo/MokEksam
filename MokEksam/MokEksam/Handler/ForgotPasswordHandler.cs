using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using MokEksam.Common;
using MokEksam.Model.DTO;
using MokEksam.ViewModel;

namespace MokEksam.Handler
{
    class ForgotPasswordHandler
    {
        public ForgotPasswordViewModel PasswordViewModel { get; set; }

        public EndUser ModifyEndUser { get; set; }

        public ForgotPasswordHandler(ForgotPasswordViewModel passwordViewModel)
        {
            PasswordViewModel = passwordViewModel;
        }

        public bool ValidateEmailAndUsername(string email, string username)
        {
            // TODO: Implement method correctly and test afterwards
            if (true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string EditPassword(string newPassword)
        {
            // TODO: Test method
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.UseDefaultCredentials = true;

                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri(Config.ConnectionUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicantion/json"));

                    var result =
                         client.PostAsJsonAsync("api/EndUsers/" + ModifyEndUser.user_email, newPassword).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        //TODO: Change this return
                        return "Password has been changed succesfully";
                    }
                    else
                    {
                        throw new ArgumentException("Something went wrong along the way... Try another day");
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Implement an appropiate exceptionhandling code.
                var displayExceptionMessage = new MessageDialog(ex.Message);
                var displayExceptionMessageResult = displayExceptionMessage.ShowAsync();
                // TODO: Change this return
                return "Password has not been changed"; ;
            }
        }
    }
}
