using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE501_Blazor_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAE501_Blazor_API.Models.EntityFramework;
using Moq;
using SAE501_Blazor_API.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SAE501_Blazor_API.Controllers.Tests
{
    [TestClass()]
    public class BuildingControllerTests
    {
        private static Building testBuilding = new Building()
        {
            Id = 1,
            Name = "Informatique",
            Letter = "D"
        };

        private List<Building> buildingsListTests = new List<Building>() { testBuilding };

        [TestMethod()]
        public void GetBuildingsTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IDataRepository<Building>>();
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(buildingsListTests);
            BuildingController _controller = new BuildingController(mockRepository.Object);

            Assert.IsNotNull(_controller.GetBuildings().Result);
            Assert.IsNotNull(_controller.GetBuildings().Result.Value);
            Assert.AreEqual<IEnumerable<Building>>(buildingsListTests, _controller.GetBuildings().Result.Value as List<Building>);
        }

        [TestMethod()]
        public void GetBuildingTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IDataRepository<Building>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testBuilding);
            BuildingController _controller = new BuildingController(mockRepository.Object);

            Assert.IsNotNull(_controller.GetBuilding(1).Result);
            Assert.IsNotNull(_controller.GetBuilding(1).Result.Value);
            Assert.AreEqual<Building>(testBuilding, _controller.GetBuilding(1).Result.Value as Building);
        }

        [TestMethod()]
        public void GetBuildingTest_NotFound()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IDataRepository<Building>>();
            BuildingController _controller = new BuildingController(mockRepository.Object);

            Assert.IsInstanceOfType(_controller.GetBuilding(-1).Result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PutBuildingTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IDataRepository<Building>>();
            BuildingController _controller = new BuildingController(mockRepository.Object);
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testBuilding);

            Building testPutBuilding = new Building()
            {
                Id = 1,
                Name = "Infos",
                Letter = "U"
            };

            var result = _controller.PutBuilding(1, testPutBuilding);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NoContentResult>(result.Result);
        }

        [TestMethod]
        public void PutBuildingTest_BadRequest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IDataRepository<Building>>();
            BuildingController _controller = new BuildingController(mockRepository.Object);

            var result = _controller.PutBuilding(2, testBuilding);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<BadRequestResult>(result.Result);
        }

        [TestMethod]
        public void PutBuildingTest_NotFound()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IDataRepository<Building>>();
            BuildingController _controller = new BuildingController(mockRepository.Object);

            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testBuilding);

            Building testPutBuilding = new Building()
            {
                Id = 2,
                Name = "Infos",
                Letter = "U"
            };

            var result = _controller.PutBuilding(2, testPutBuilding);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);
        }

        [TestMethod()]
        public void PostBuildingTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IDataRepository<Building>>();
            BuildingController _controller = new BuildingController(mockRepository.Object);

            var taskResult = _controller.PostBuilding(testBuilding);
            Assert.IsNotNull(taskResult);
            Assert.IsInstanceOfType<CreatedAtActionResult>(taskResult.Result.Result);
            var actionresult = taskResult.Result.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType((Building)actionresult.Value, typeof(Building));
            Assert.AreEqual(testBuilding, (Building)actionresult.Value);
        }

        [TestMethod()]
        public void PostBuildingTest_BadRequest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IDataRepository<Building>>();
            BuildingController _controller = new BuildingController(mockRepository.Object);
            _controller.ModelState.AddModelError("ModelError", "Building can't be empty");

            var result = _controller.PostBuilding(new Building());
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<BadRequestObjectResult>(result.Result.Result);
        }

        [TestMethod]
        public void DeleteBuildingTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IDataRepository<Building>>();
            BuildingController _controller = new BuildingController(mockRepository.Object);

            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testBuilding);

            var result = _controller.DeleteBuilding(1);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NoContentResult>(result.Result);

        }

        [TestMethod]
        public void DeleteBuildingTest_NotFound()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IDataRepository<Building>>();
            BuildingController _controller = new BuildingController(mockRepository.Object);

            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testBuilding);

            var result = _controller.DeleteBuilding(2);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);
        }
    }
}