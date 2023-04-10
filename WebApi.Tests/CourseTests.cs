using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using WebApi.Models;

namespace WebApi.Tests;

public class CourseTests
{
    protected readonly WebApplicationFactory<Program> _factory;

    public CourseTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    private readonly Course _courseToPost = new Course()
    {
        Id = 2,
        Name = "name",

    };

    private readonly Course _courseToPut = new Course()
    {
        Id = 1,
        Name = "name",
    };
    [Fact]
    public async Task TestGetAllCoursesAsync()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("api/Course");
        Assert.NotNull(response);
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task TestGetCourseSucceedAsync()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("api/Course/2");
        Assert.NotNull(response);
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task TestPostCourseSucceedAsync()
    {
        var client = _factory.CreateClient();
        var response = await client.PostAsJsonAsync("api/Course", _courseToPost);
        Assert.NotNull(response);
        response.EnsureSuccessStatusCode();
    }


    [Fact]
    public async Task TestPutCourseSucceedAsync()
    {
        var client = _factory.CreateClient();
        var response = await client.PutAsJsonAsync("api/Course", _courseToPut);
        Assert.NotNull(response);
        response.EnsureSuccessStatusCode();
    }



    [Fact]
    public async Task TestDeleteCourseSucceedAsync()
    {
        var client = _factory.CreateClient();
        var response = await client.DeleteAsync("api/Course/2");
        Assert.NotNull(response);
        response.EnsureSuccessStatusCode();

    }
}