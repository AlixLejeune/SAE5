using Microsoft.AspNetCore.Mvc;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;Furniture

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAE501_Blazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WallController : ControllerBase
    {
        private readonly IDataRepository<Wall> dataRepository;

        public WallController(IDataRepository<Wall> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Walls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wall>>> GetWalls()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Walls/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Wall>> GetWall(int id)
        {
            var Wall = await dataRepository.GetByIdAsync(id);

            if (Wall == null)
            {
                return NotFound();
            }

            return Wall;
        }


        // PUT: api/Walls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutWall(int id, Wall w)
        {
            if (id != w.Id)
            {
                return BadRequest();
            }

            var wallUpdate = await dataRepository.GetByIdAsync(id);

            if (wallUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(wallUpdate.Value, w);
                return NoContent();
            }
        }

        // POST: api/Wall
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Wall>> PostEtudiant(Wall w)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(w);

            return CreatedAtAction("GetById", new { id = w.Id }, w);
        }

        // DELETE: api/Wall/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWall(int id)
        {
            var wall = await dataRepository.GetByIdAsync(id);
            if (wall == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(wall.Value);
            return NoContent();
        }
    }
}
