using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using System.Reflection;
using Module = WebApi.Models.Module;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace WebApi.Tests
{
    public class ModuleTests
    {
        protected readonly WebApplicationFactory<Program> _factory;

        public ModuleTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        private readonly Module _moduleToPost = new Module()
        {
            Id = 2,
            Name = "Foo",
            CourseId = 1,
        };

        private readonly Module _moduleToPut = new Module()
        {
            Id = 1,
            Name = "Foo",
            CourseId = 1,
        };
        [Fact]
        public async Task TestGetAllModuleAsync()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Module");
            Assert.NotNull(response);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetModuleSucceedAsync()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Module/2");
            Assert.NotNull(response);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostModuleSucceedAsync()
        {
            var client = _factory.CreateClient();
            var response = await client.PostAsJsonAsync("api/Module", _moduleToPost);
            Assert.NotNull(response);
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task TestPutModuleSucceedAsync()
        {
            var client = _factory.CreateClient();
            var response = await client.PutAsJsonAsync("api/Module", _moduleToPut);
            Assert.NotNull(response);
            response.EnsureSuccessStatusCode();
        }



        [Fact]
        public async Task TestDeleteModuleSucceedAsync()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync("api/Module/2");
            Assert.NotNull(response);
            response.EnsureSuccessStatusCode();

        }
    }
}
