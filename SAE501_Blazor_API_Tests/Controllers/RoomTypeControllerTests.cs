using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SAE501_Blazor_API.Controllers;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE501_Blazor_API.Controllers.Tests
{
    [TestClass()]
    public class RoomTypeControllerTests
    {
        private static RoomType testRoomType = new RoomType()
        {
            Id = 1,
            Name = "Informatique",
        };

        private List<RoomType> roomTypesListTests = new List<RoomType>() { testRoomType };

        [TestMethod()]
        public void GetRoomTypesTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomTypeRepository>();
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(roomTypesListTests);
            RoomTypeController _controller = new RoomTypeController(mockRepository.Object);

            Assert.IsNotNull(_controller.GetRoomTypes().Result);
            Assert.IsNotNull(_controller.GetRoomTypes().Result.Value);
            Assert.AreEqual<IEnumerable<RoomType>>(roomTypesListTests, _controller.GetRoomTypes().Result.Value as List<RoomType>);
        }

        [TestMethod()]
        public void GetRoomTypeTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomTypeRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testRoomType);
            RoomTypeController _controller = new RoomTypeController(mockRepository.Object);

            Assert.IsNotNull(_controller.GetRoomType(1).Result);
            Assert.IsNotNull(_controller.GetRoomType(1).Result.Value);
            Assert.AreEqual<RoomType>(testRoomType, _controller.GetRoomType(1).Result.Value as RoomType);
        }

        [TestMethod()]
        public void GetRoomTypeTest_NotFound()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomTypeRepository>();
            RoomTypeController _controller = new RoomTypeController(mockRepository.Object);

            Assert.IsInstanceOfType(_controller.GetRoomType(-1).Result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PutRoomTypeTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomTypeRepository>();
            RoomTypeController _controller = new RoomTypeController(mockRepository.Object);
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testRoomType);

            RoomType testPutRoomType = new RoomType()
            {
                Id = 1,
                Name = "Infos",
            };

            var result = _controller.PutRoomType(1, testPutRoomType);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NoContentResult>(result.Result);
        }

        [TestMethod]
        public void PutRoomTypeTest_BadRequest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomTypeRepository>();
            RoomTypeController _controller = new RoomTypeController(mockRepository.Object);

            var result = _controller.PutRoomType(2, testRoomType);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<BadRequestResult>(result.Result);
        }

        [TestMethod]
        public void PutRoomTypeTest_NotFound()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomTypeRepository>();
            RoomTypeController _controller = new RoomTypeController(mockRepository.Object);

            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testRoomType);

            RoomType testPutRoomType = new RoomType()
            {
                Id = 2,
                Name = "Infos",
            };

            var result = _controller.PutRoomType(2, testPutRoomType);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);
        }

        [TestMethod()]
        public void PostRoomTypeTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomTypeRepository>();
            RoomTypeController _controller = new RoomTypeController(mockRepository.Object);

            var taskResult = _controller.PostRoomType(testRoomType);
            Assert.IsNotNull(taskResult);
            Assert.IsInstanceOfType<CreatedAtActionResult>(taskResult.Result.Result);
            var actionresult = taskResult.Result.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType((RoomType)actionresult.Value, typeof(RoomType));
            Assert.AreEqual(testRoomType, (RoomType)actionresult.Value);
        }

        [TestMethod()]
        public void PostRoomTypeTest_BadRequest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomTypeRepository>();
            RoomTypeController _controller = new RoomTypeController(mockRepository.Object);
            _controller.ModelState.AddModelError("ModelError", "RoomType can't be empty");

            var result = _controller.PostRoomType(new RoomType());
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<BadRequestObjectResult>(result.Result.Result);
        }

        [TestMethod]
        public void DeleteRoomTypeTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomTypeRepository>();
            RoomTypeController _controller = new RoomTypeController(mockRepository.Object);

            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testRoomType);

            var result = _controller.DeleteRoomType(1);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NoContentResult>(result.Result);

        }

        [TestMethod]
        public void DeleteRoomTypeTest_NotFound()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomTypeRepository>();
            RoomTypeController _controller = new RoomTypeController(mockRepository.Object);

            var result = _controller.DeleteRoomType(-1);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);

        }
    }
}