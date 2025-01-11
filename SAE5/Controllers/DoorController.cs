using Microsoft.AspNetCore.Mvc;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;
using SAE501_Blazor_API.Models.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAE501_Blazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {
        private readonly IDataRepository<Door> dataRepository;

        public DoorController(IDataRepository<Door> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Door
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Door>>> GetDoors()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Door/getbyid/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Door>> GetDoor(int id)
        {
            var door = await dataRepository.GetByIdAsync(id);

            if (door == null)
            {
                return NotFound();
            }

            return door;
        }


        // PUT: api/Door/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutDoor(int id, Door d)
        {
            if (id != d.Id)
            {
                return BadRequest();
            }

            var doorUpdate = await dataRepository.GetByIdAsync(id);

            if (doorUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(doorUpdate.Value, d);
                return NoContent();
            }
        }

        // POST: api/Door
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Door>> PostDoor(Door d)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(d);

            return CreatedAtAction("GetById", new { id = d.Id }, d);
        }

        // DELETE: api/Door/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDoor(int id)
        {
            var door = await dataRepository.GetByIdAsync(id);
            if (door == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(door.Value);
            return NoContent();
        }
    }
}
