using System.Collections.Generic;
using Moq;
using WebAPIClient.ConsoleApp.Clients;
using WebAPIClient.ConsoleApp.Models;
using WebAPIClient.ConsoleApp.Services;
using Xunit;

namespace WebAPIClient.Tests
{
    public class RepositoryServiceTests
    {
        [Fact]
        public void Assert_That_Repositories_Not_Null()
        {
            // Arrange
            var mockRepositoryClient = new Mock<IRepositoryClient>();
            var mockRepositories = new List<Repository>();
            mockRepositoryClient.Setup(x => x.GetRepositories()).ReturnsAsync(mockRepositories);
            var repositoryService = new RepositoryService(mockRepositoryClient.Object);
            
            // Act
            var repositories = repositoryService.Get();
            
            // Assert
            Assert.NotNull(repositories);
        }
    }
}
