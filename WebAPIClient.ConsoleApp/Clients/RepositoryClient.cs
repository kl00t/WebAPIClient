using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPIClient.ConsoleApp.Models;

namespace WebAPIClient.ConsoleApp.Clients
{
    public class RepositoryClient : IRepositoryClient
    {
        private readonly HttpClient _httpClient;

        public RepositoryClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Repository>> GetRepositories()
        {
            var taskStream = await _httpClient.GetStreamAsync("orgs/dotnet/repos");
            return await JsonSerializer.DeserializeAsync<List<Repository>>(taskStream);
        }
    }
}
