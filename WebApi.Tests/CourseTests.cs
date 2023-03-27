using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Tests;

public class CourseTests
{
    private readonly Course _assignmentToPost = new Course()
    {
        Id = 2,
        Name = "name",

    };

    private readonly Course _assignmentToPut = new Course()
    {
        Id = 1,
        Name = "name",
    };
    [Fact]
    public void TestGetAllAssignments()
    {
        var controller = new CourseController();
        var result = controller.GetCourses();
        var resultList = result.Value.ToList();
        Assert.NotNull(result);
        Assert.Equal(resultList[0].Name, "Nate's Amazing Class");
    }

    [Fact]
    public void TestGetAssignmentSucceed()
    {
        var controller = new CourseController();
        var result = controller.GetCourse(1);
        Assert.NotNull(result);
        Assert.Equal(1, result.Value.Id);
    }

    [Fact]
    public void TestPostAssignmentSucceed()
    {
        var controller = new CourseController();
        var result = controller.PostCourse(_assignmentToPost);
        Assert.NotNull(result);
        Assert.IsType<OkResult>(result);
    }


    [Fact]
    public void TestPutAssignmentSucceed()
    {
        var controller = new CourseController();
        var result = controller.PutCourse(_assignmentToPut);
        Assert.NotNull(result);
        Assert.IsType<OkResult>(result);
    }



    [Fact]
    public void TestDeleteAssignmentSucceed()
    {
        var controller = new CourseController();
        var result = controller.DeleteCourse(1);
        Assert.NotNull(result);
        Assert.IsType<OkResult>(result);

    }
}