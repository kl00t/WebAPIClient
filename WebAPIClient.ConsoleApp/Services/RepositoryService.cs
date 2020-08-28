using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIClient.ConsoleApp.Clients;
using WebAPIClient.ConsoleApp.Models;

namespace WebAPIClient.ConsoleApp.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IRepositoryClient _repositoryClient;

        public RepositoryService(IRepositoryClient repositoryClient)
        {
            _repositoryClient = repositoryClient;
        }

        public async Task<List<OutputModel>> Get()
        {
            return (from repository in await _repositoryClient.GetRepositories() 
                select new OutputModel
                {
                    Output = $"Repository: '{repository.Name}' last pushed at '{repository.LastPush}'"
                }).ToList();
        }
    }
}
