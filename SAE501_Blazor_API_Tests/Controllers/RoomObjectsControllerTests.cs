using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SAE501_Blazor_API.Controllers;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;
using SAE501_Blazor_API.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE501_Blazor_API.Controllers.Tests
{
    [TestClass()]
    public class RoomObjectsControllerTests
    {
        private static RoomObject testRoomObject = new Door()
        {
            Id = 1,
            CustomName= "UnePorte",
            PosX = 0,
            PosY = 1,
            PosZ = 0,
        };

        private List<RoomObject> roomObjectsListTests = new List<RoomObject>() { testRoomObject };

        [TestMethod()]
        public void GetRoomObjectsTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomObjectRepository>();
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(roomObjectsListTests);
            RoomObjectsController _controller = new RoomObjectsController(mockRepository.Object);

            Assert.IsNotNull(_controller.GetRoomObjects().Result);
            Assert.IsNotNull(_controller.GetRoomObjects().Result.Value);
            Assert.AreEqual<IEnumerable<RoomObject>>(roomObjectsListTests, _controller.GetRoomObjects().Result.Value as List<RoomObject>);
        }

        [TestMethod()]
        public void GetRoomObjectTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomObjectRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testRoomObject);
            RoomObjectsController _controller = new RoomObjectsController(mockRepository.Object);

            Assert.IsNotNull(_controller.GetRoomObject(1).Result);
            Assert.IsNotNull(_controller.GetRoomObject(1).Result.Value);
            Assert.AreEqual<RoomObject>(testRoomObject, _controller.GetRoomObject(1).Result.Value as RoomObject);
        }

        [TestMethod()]
        public void GetRoomObjectTest_NotFound()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomObjectRepository>();
            RoomObjectsController _controller = new RoomObjectsController(mockRepository.Object);

            Assert.IsInstanceOfType(_controller.GetRoomObject(-1).Result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PutRoomObjectTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomObjectRepository>();
            RoomObjectsController _controller = new RoomObjectsController(mockRepository.Object);
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testRoomObject);

            RoomObject testPutRoomObject = new Door()
            {
                Id = 1,
                CustomName = "UnePorte",
                PosX = 1,
                PosY = 2,
                PosZ = 3,
            };

            var result = _controller.PutRoomObjects(1, testPutRoomObject);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NoContentResult>(result.Result);
        }

        [TestMethod]
        public void PutRoomObjectTest_BadRequest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomObjectRepository>();
            RoomObjectsController _controller = new RoomObjectsController(mockRepository.Object);

            var result = _controller.PutRoomObjects(2, testRoomObject);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<BadRequestResult>(result.Result);
        }

        [TestMethod]
        public void PutRoomObjectTest_NotFound()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomObjectRepository>();
            RoomObjectsController _controller = new RoomObjectsController(mockRepository.Object);

            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testRoomObject);

            RoomObject testPutRoomObject = new Door()
            {
                Id = 2,
                CustomName = "UnePorte",
                PosX = 0,
                PosY = 1,
                PosZ = 0,
            };

            var result = _controller.PutRoomObjects(2, testPutRoomObject);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);
        }

        [TestMethod()]
        public void PostRoomObjectTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomObjectRepository>();
            RoomObjectsController _controller = new RoomObjectsController(mockRepository.Object);

            var taskResult = _controller.PostRoomObjects(testRoomObject);
            Assert.IsNotNull(taskResult);
            Assert.IsInstanceOfType<CreatedAtActionResult>(taskResult.Result.Result);
            var actionresult = taskResult.Result.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType((RoomObject)actionresult.Value, typeof(RoomObject));
            Assert.AreEqual(testRoomObject, (RoomObject)actionresult.Value);
        }

        [TestMethod()]
        public void PostRoomObjectTest_BadRequest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomObjectRepository>();
            RoomObjectsController _controller = new RoomObjectsController(mockRepository.Object);
            _controller.ModelState.AddModelError("ModelError", "RoomObject can't be empty");

            var result = _controller.PostRoomObjects(new Door());
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<BadRequestObjectResult>(result.Result.Result);
        }

        [TestMethod]
        public void DeleteRoomObjectTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomObjectRepository>();
            RoomObjectsController _controller = new RoomObjectsController(mockRepository.Object);

            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testRoomObject);

            var result = _controller.DeleteRoomObjects(1);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NoContentResult>(result.Result);

        }

        [TestMethod]
        public void DeleteRoomObjectTest_NotFound()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomObjectRepository>();
            RoomObjectsController _controller = new RoomObjectsController(mockRepository.Object);

            var result = _controller.DeleteRoomObjects(-1);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);

        }
    }
}