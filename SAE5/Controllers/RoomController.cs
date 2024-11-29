using Microsoft.AspNetCore.Mvc;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAE501_Blazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IDataRepository<Room> dataRepository;

        public RoomController(IDataRepository<Room> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Rooms/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var Room = await dataRepository.GetByIdAsync(id);

            if (Room == null)
            {
                return NotFound();
            }

            return Room;
        }


        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutRoom(int id, Room r)
        {
            if (id != r.Id)
            {
                return BadRequest();
            }

            var roomUpdate = await dataRepository.GetByIdAsync(id);

            if (roomUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(roomUpdate.Value, r);
                return NoContent();
            }
        }

        // POST: api/Room
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Room>> PostEtudiant(Room r)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(r);

            return CreatedAtAction("GetById", new { id = r.Id }, r);
        }

        // DELETE: api/Room/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await dataRepository.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(room.Value);
            return NoContent();
        }
    }
}
