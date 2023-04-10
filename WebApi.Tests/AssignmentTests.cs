using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using WebApi.Models;

namespace WebApi.Tests;

public class AssignmentTests
{
    protected readonly WebApplicationFactory<Program> _factory;

    public AssignmentTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    private readonly Assignment _assignmentToPost = new Assignment()
    {
        Id = 3,
        Name = "name",
        Grade = 50,
        DueDate = DateTime.Now,
        ModuleId = 1,
    };

    private readonly Assignment _assignmentToPut = new Assignment()
    {
        Id = 2,
        Name = "name",
        Grade = 50,
        DueDate = DateTime.Now,
        ModuleId = 1,
    };
    [Fact]
    public async Task TestGetAllAssignmentsAsync()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("api/Assignment");
        Assert.NotNull(response);
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task TestGetAssignmentSucceedAsync()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("api/Assignment/2");
        Assert.NotNull(response);
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task TestPostAssignmentSucceedAsync()
    {
        var client = _factory.CreateClient();
        var response = await client.PostAsJsonAsync("api/Assignment", _assignmentToPost);
        Assert.NotNull(response);
        response.EnsureSuccessStatusCode();
    }


    [Fact]
    public async Task TestPutAssignmentSucceedAsync()
    {
        var client = _factory.CreateClient();
        var response = await client.PutAsJsonAsync("api/Assignment", _assignmentToPut);
        Assert.NotNull(response);
        response.EnsureSuccessStatusCode();
    }



    [Fact]
    public async Task TestDeleteAssignmentSucceedAsync()
    {
        var client = _factory.CreateClient();
        var response = await client.DeleteAsync("api/Assignment/2");
        Assert.NotNull(response);
        response.EnsureSuccessStatusCode();

    }
}