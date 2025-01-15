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
    public class RoomControllerTests
    {
        private static Room testRoom = new Room()
        {
              Id = 1,
              Name = "testRoom",
              NorthOrientation = 0,
              Height = 2,
              Base = new List<Vector2D>()
              {
                  new Vector2D(0,2), new Vector2D(1,4), new Vector2D(3, 1)
              },
              IdBuilding = 1,
              IdRoomType = 1
        };

    private List<Room> roomsListTests = new List<Room>() { testRoom };

        [TestMethod()]
        public void GetRoomsTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomRepository>();
            mockRepository.Setup(x => x.GetAllAsync().Result).Returns(roomsListTests);
            RoomController _controller = new RoomController(mockRepository.Object);

            Assert.IsNotNull(_controller.GetRooms().Result);
            Assert.IsNotNull(_controller.GetRooms().Result.Value);
            Assert.AreEqual<IEnumerable<Room>>(roomsListTests, _controller.GetRooms().Result.Value as List<Room>);
        }

        [TestMethod()]
        public void GetRoomTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testRoom);
            RoomController _controller = new RoomController(mockRepository.Object);

            Assert.IsNotNull(_controller.GetRoom(1).Result);
            Assert.IsNotNull(_controller.GetRoom(1).Result.Value);
            Assert.AreEqual<Room>(testRoom, _controller.GetRoom(1).Result.Value as Room);
        }

        [TestMethod()]
        public void GetRoomTest_NotFound()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomRepository>();
            RoomController _controller = new RoomController(mockRepository.Object);

            Assert.IsInstanceOfType(_controller.GetRoom(-1).Result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PutRoomTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomRepository>();
            RoomController _controller = new RoomController(mockRepository.Object);
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testRoom);

            Room testPutRoom = new Room()
            {
                Id = 1,
                Name = "testRoom",
                NorthOrientation = 90,
                Height = 3,
                Base = new List<Vector2D>()
              {
                  new Vector2D(0,2), new Vector2D(1,4), new Vector2D(3, 1)
              },
                IdBuilding = 1,
                IdRoomType = 1
            };

            var result = _controller.PutRoom(1, testPutRoom);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NoContentResult>(result.Result);
        }

        [TestMethod]
        public void PutRoomTest_BadRequest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomRepository>();
            RoomController _controller = new RoomController(mockRepository.Object);

            var result = _controller.PutRoom(2, testRoom);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<BadRequestResult>(result.Result);
        }

        [TestMethod]
        public void PutRoomTest_NotFound()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomRepository>();
            RoomController _controller = new RoomController(mockRepository.Object);

            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testRoom);

            Room testPutRoom = new Room()
            {
                Id = 2,
                Name = "testRoom",
                NorthOrientation = 0,
                Height = 2,
                Base = new List<Vector2D>()
              {
                  new Vector2D(0,2), new Vector2D(1,4), new Vector2D(3, 1)
              },
                IdBuilding = 1,
                IdRoomType = 1
            };

            var result = _controller.PutRoom(2, testPutRoom);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);
        }

        [TestMethod()]
        public void PostRoomTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomRepository>();
            RoomController _controller = new RoomController(mockRepository.Object);

            var taskResult = _controller.PostRoom(testRoom);
            Assert.IsNotNull(taskResult);
            Assert.IsInstanceOfType<CreatedAtActionResult>(taskResult.Result.Result);
            var actionresult = taskResult.Result.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType((Room)actionresult.Value, typeof(Room));
            Assert.AreEqual(testRoom, (Room)actionresult.Value);
        }

        [TestMethod()]
        public void PostRoomTest_BadRequest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomRepository>();
            RoomController _controller = new RoomController(mockRepository.Object);
            _controller.ModelState.AddModelError("ModelError", "Room can't be empty");

            var result = _controller.PostRoom(new Room());
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<BadRequestObjectResult>(result.Result.Result);
        }

        [TestMethod]
        public void DeleteRoomTest()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomRepository>();
            RoomController _controller = new RoomController(mockRepository.Object);

            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(testRoom);

            var result = _controller.DeleteRoom(1);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NoContentResult>(result.Result);

        }

        [TestMethod]
        public void DeleteRoomTest_NotFound()
        {
            DataContext _context = new DataContext();
            var mockRepository = new Mock<IRoomRepository>();
            RoomController _controller = new RoomController(mockRepository.Object);

            var result = _controller.DeleteRoom(-1);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<NotFoundResult>(result.Result);

        }
    }
}