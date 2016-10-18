using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

/*
Husk at rette namespace
Du kan saette et default URL ved at replace [DEFAULT URL] med dit url

Husk at rette klassens property (højreklik i Solution Explorer på klassen og vælg "Properties") fra "None" til "Build"
*/
namespace MokEksam.Common
{
    public class ApiClient<T>
{
    private string baseUrl = "";
    private string requestUrl = "";

    private bool useDefaultCredentials = false;

    public ApiClient(string requestUrl, string baseUrl)
    {
        this.requestUrl = requestUrl;
        this.baseUrl = baseUrl;

    }
    public ApiClient(string requestUrl) : this(requestUrl, "[DEFAULT URL]")
    { }

    public void UseDefaultCredentials()
    {
        useDefaultCredentials = true;
    }


    private HttpClientHandler GetHandler()
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.UseDefaultCredentials = useDefaultCredentials;

        return clientHandler;
    }

    public async Task<IEnumerable<T>> Get()
    {
        using (HttpClient client = new HttpClient(GetHandler()))
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var result = client.GetAsync(requestUrl).Result;
                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadAsAsync<IEnumerable<T>>();
                }

                throw new UnSuccesfulRequest(result.StatusCode.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
    public async Task<T> Get(Object id)
    {
        using (HttpClient client = new HttpClient(GetHandler()))
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var result = client.GetAsync(requestUrl + "/" + id).Result;
                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadAsAsync<T>();
                }

                throw new UnSuccesfulRequest(result.StatusCode.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
    public async Task<T> Post(T Obj)
    {
        using (HttpClient client = new HttpClient(GetHandler()))
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var result = client.PostAsJsonAsync(requestUrl, Obj).Result;
                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadAsAsync<T>();
                }
                throw new UnSuccesfulRequest(result.StatusCode.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
    public async Task<T> Update(Object updateId, T Obj)
    {
        using (HttpClient client = new HttpClient(GetHandler()))
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var result = client.PutAsJsonAsync(requestUrl + "/" + updateId, Obj).Result;

                if (result.IsSuccessStatusCode)
                {
                    return Obj;

                }
                throw new UnSuccesfulRequest(result.StatusCode.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }

    public async Task<bool> Delete(Object updateId)
    {
        using (HttpClient client = new HttpClient(GetHandler()))
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var result = client.DeleteAsync(requestUrl + "/" + updateId).Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                throw new UnSuccesfulRequest(result.StatusCode.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

}

public class UnSuccesfulRequest : Exception
{
    public UnSuccesfulRequest()
    {
    }

    public UnSuccesfulRequest(string message) : base(message)
    {
    }

    public UnSuccesfulRequest(string message, Exception innerException) : base(message, innerException)
    {
    }
}
}