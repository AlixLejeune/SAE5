using Microsoft.AspNetCore.Mvc;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;
using SAE501_Blazor_API.Models.Repositories;

namespace SAE501_Blazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomObjectsController : ControllerBase
    {
        private readonly IRoomObjectRepository dataRepository;

        public RoomObjectsController(IRoomObjectRepository dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/RoomObjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomObject>>> GetRoomObjectss()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/RoomObjects/getbyid/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RoomObject>> GetRoomObjects(int id)
        {
            var roomObjects = await dataRepository.GetByIdAsync(id);

            if (roomObjects == null)
            {
                return NotFound();
            }

            return roomObjects;
        }


        // PUT: api/RoomObjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutRoomObjects(int id, RoomObject b)
        {
            if (id != b.Id)
            {
                return BadRequest();
            }

            var bUpdate = await dataRepository.GetByIdAsync(id);

            if (bUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(bUpdate.Value, b);
                return NoContent();
            }
        }

        // POST: api/RoomObjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RoomObject>> PostRoomObjects(RoomObject b)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(b);

            return CreatedAtAction("GetById", new { id = b.Id }, b);
        }

        // DELETE: api/RoomObjects/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRoomObjects(int id)
        {
            var roomObjects = await dataRepository.GetByIdAsync(id);
            if (roomObjects == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(roomObjects.Value);
            return NoContent();
        }
        
    }
}
