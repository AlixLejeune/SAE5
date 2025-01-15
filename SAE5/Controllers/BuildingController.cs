using Microsoft.AspNetCore.Mvc;
using SAE501_Blazor_API.Models.DTO;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAE501_Blazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingRepository dataRepository;

        public BuildingController(IBuildingRepository dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Building
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Building
        [HttpGet("DTO")]
        public async Task<ActionResult<IEnumerable<BuildingListElementDTO>>> GetBuildingsDTO()
        {
            return await dataRepository.GetAllDTOAsync();
        }

        // GET: api/Building/getbyid/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Building>> GetBuilding(int id)
        {
            var building = await dataRepository.GetByIdAsync(id);

            if (building.Value is null)
            {
                return NotFound();
            }

            return building;
        }


        // PUT: api/Building/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutBuilding(int id, Building b)
        {
            if (id != b.Id)
            {
                return BadRequest();
            }

            var bUpdate = await dataRepository.GetByIdAsync(id);

            if (bUpdate.Value is null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(bUpdate.Value, b);
                return NoContent();
            }
        }

        // POST: api/Building
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Building>> PostBuilding(Building b)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(b);

            return CreatedAtAction("GetById", new { id = b.Id}, b);
        }

        // DELETE: api/Building/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBuilding(int id)
        {
            var building = await dataRepository.GetByIdAsync(id);
            if (building.Value is null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(building.Value);
            return NoContent();
        }
    }
}
