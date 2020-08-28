using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIClient.ConsoleApp.Models;

namespace WebAPIClient.ConsoleApp.Services
{
    public interface IRepositoryService
    {
        Task<List<OutputModel>> Get();
    }
}