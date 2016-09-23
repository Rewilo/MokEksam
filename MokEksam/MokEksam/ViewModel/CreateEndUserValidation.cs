using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;
using Client.Common;
using MokEksam.Model;

namespace MokEksam.ViewModel
{
    class CreateEndUserValidation
    {
        private EndUser _endUser;

        public Task<bool> CheckUsername(string username)
        {

            /*try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.UseDefaultCredentials = true;

                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri(Config.ConnectionUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicantion/json"));


                    var result =
                        client.PutAsJsonAsync("Api/ordres/" + Ordre.ID + "?status=F",
                            new Object()).Result;
                    if (!result.IsSuccessStatusCode)
                    {
                        throw new UnSuccesfulMeddelseRequest(result.StatusCode.ToString());
                    }
                }
                ((Frame)Window.Current.Content).Navigate(typeof(V.Home));

            }
            catch (UnSuccesfulMeddelseRequest e)
            {
                var dialog = new MessageDialog("Der er sket en fejl på serveren, prøv igen? [Http error: " + e.Message + "]");
                dialog.Commands.Add(new UICommand() { Label = "Forsøg igen", Id = 0 });
                dialog.Commands.Add(new UICommand() { Label = "Nej", Id = 1 });
                var show = await dialog.ShowAsync();

                if ((int)show.Id == 0)
                {
                    goto retry;
                }
                {
                    ((Frame)Window.Current.Content).Navigate(typeof(V.Home));
                }
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog("Der er ingen forbindelse til internettet, prøv igen?");
                dialog.Commands.Add(new UICommand() { Label = "Forsøg igen", Id = 0 });
                dialog.Commands.Add(new UICommand() { Label = "Nej", Id = 1 });
                var show = await dialog.ShowAsync();

                if ((int)show.Id == 0)
                    goto retry;
                else
                    ((Frame)Window.Current.Content).Navigate(typeof(V.Home));
            }*/
            //TODO: Implement HTTP-requst to WebAPI to check if username already exist in Database.
            throw new NotImplementedException();
        } 
    }
}
