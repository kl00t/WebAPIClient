using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIClient.ConsoleApp.Models;

namespace WebAPIClient.ConsoleApp.Clients
{
    public interface IRepositoryClient
    {
        Task<List<Repository>> GetRepositories();
    }
}