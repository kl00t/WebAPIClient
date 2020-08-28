using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WebAPIClient.ConsoleApp.Clients;
using WebAPIClient.ConsoleApp.Services;

namespace WebAPIClient.ConsoleApp
{
    class Program
    {
        static async Task Main()
        {
            var serviceProvider = new ServiceCollection();
            serviceProvider.AddHttpClient<IRepositoryClient, RepositoryClient>(client =>
            {
                client.BaseAddress = new Uri("https://api.github.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            });

            serviceProvider.AddTransient<IRepositoryService, RepositoryService>();

            var services = serviceProvider.BuildServiceProvider();

            var repositoryService = services.GetService<IRepositoryService>();

            var repositories = await repositoryService.Get();

            foreach (var repo in repositories)
            {
                Console.WriteLine(repo.Output);
                Console.WriteLine();
            }
        }
    }
}
