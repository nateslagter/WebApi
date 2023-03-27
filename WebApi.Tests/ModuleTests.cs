using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using System.Reflection;
using Module = WebApi.Models.Module;

namespace WebApi.Tests
{
    public class ModuleTests
    {
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
        public void TestGetAllModules()
        {
            var controller = new ModuleController();
            var result = controller.GetModules();
            var resultList = result.Value.ToList();
            Assert.NotNull(result);
            Assert.Equal(resultList[0].Name, "CS420Week1");
        }

        [Fact]
        public void TestGetModuleSucceed()
        {
            var controller = new ModuleController();
            var result = controller.GetModule(1);
            Assert.NotNull(result);
            Assert.Equal(1, result.Value.Id);
        }

        [Fact]
        public void TestPostModuleSucceed()
        {
            var controller = new ModuleController();
            var result = controller.PostModule(_moduleToPost);
            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
        }


        [Fact]
        public void TestPutModuleSucceed()
        {
            var controller = new ModuleController();
            var result = controller.PutModule(_moduleToPut);
            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
        }



        [Fact]
        public void TestDeleteModuleSucceed()
        {
            var controller = new ModuleController();
            var result = controller.DeleteModule(1);
            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
        }
    }
}
