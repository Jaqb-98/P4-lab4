using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace lab4
{
    public class Website
    {
        public RestClient _client { get; private set; }

        public Website(string baseLink)
        {
            _client = new RestClient(baseLink);
        }

     
        public async Task<IRestResponse> DownloadAsync(string path)
        {
            var request = new RestRequest(path, Method.GET);
            var response = await _client.ExecuteAsync(request);
            return response;
        }
    }
}
