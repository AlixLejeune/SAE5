using Microsoft.AspNetCore.Mvc;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAE501_Blazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnitureController : ControllerBase
    {
        private readonly IDataRepository<Furniture> dataRepository;

        public FurnitureController(IDataRepository<Furniture> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Furnitures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Furniture>>> GetFurnitures()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Furnitures/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Furniture>> GetFurniture(int id)
        {
            var furniture = await dataRepository.GetByIdAsync(id);

            if (furniture == null)
            {
                return NotFound();
            }

            return furniture;
        }


        // PUT: api/Furnitures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutFurniture(int id, Furniture f)
        {
            if (id != f.Id)
            {
                return BadRequest();
            }

            var furnitureUpdate = await dataRepository.GetByIdAsync(id);

            if (furnitureUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(furnitureUpdate.Value, f);
                return NoContent();
            }
        }

        // POST: api/Furniture
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Furniture>> PostEtudiant(Furniture f)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(f);

            return CreatedAtAction("GetById", new { id = f.Id }, f);
        }

        // DELETE: api/Furniture/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFurniture(int id)
        {
            var furniture = await dataRepository.GetByIdAsync(id);
            if (furniture == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(furniture.Value);
            return NoContent();
        }
    }
}
