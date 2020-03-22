using RestSharp;
using System.Threading.Tasks;

namespace CollegeFootballAPI
{
    public class Client
    {
        public RestClient _client { get; private set; }

        public Client(string baseLink)
        {
            _client = new RestClient(baseLink);
        }

        public async Task<string> GetResponseAsync(string path)
        {
            var request = new RestRequest(path, DataFormat.Json);
            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
