using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Tests;

public class AssignmentTests
{
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
    public void TestGetAllAssignments()
    {
        var controller = new AssignmentController();
        var result = controller.GetAssignments();
        var resultList = result.Value.ToList();
        Assert.NotNull(result);
        Assert.Equal(resultList[0].Name, "Assignment1ForModule1");
    }

    [Fact]
    public void TestGetAssignmentSucceed()
    {
        var controller = new AssignmentController();
        var result = controller.GetAssignment(1);
        Assert.NotNull(result);
        Assert.Equal(1,result.Value.Id);
    }

    [Fact]
    public void TestPostAssignmentSucceed()
    {
        var controller = new AssignmentController();
        var result = controller.PostAssignment(_assignmentToPost); 
        Assert.NotNull(result);
        Assert.IsType<OkResult>(result);
    }


    [Fact]
    public void TestPutAssignmentSucceed()
    {
        var controller = new AssignmentController();
        var result = controller.PutAssignment(_assignmentToPut);
        Assert.NotNull(result);
        Assert.IsType<OkResult>(result);
    }



    [Fact]
    public void TestDeleteAssignmentSucceed()
    {
        var controller = new AssignmentController();
        var result = controller.DeleteAssignment(1);
        Assert.NotNull(result);
        Assert.IsType<OkResult>(result);

    }
}