using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AngularDotnetCore.Services
{
    //TODO use api
    public class HttpClientService
    {
        private HttpClient client = new HttpClient();
        public async Task<string> GetPageFromWeb(string postId)
        {
            var post = "";
            try
            {
                post = await client.GetStringAsync(postId);
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("Exception " + e.Message);
            }
            return post;
        } 
    }
}