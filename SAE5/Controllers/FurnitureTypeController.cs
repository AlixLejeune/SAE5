using Microsoft.AspNetCore.Mvc;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAE501_Blazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnitureTypeController : ControllerBase
    {
        private readonly IDataRepository<FurnitureType> dataRepository;

        public FurnitureTypeController(IDataRepository<FurnitureType> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/FurnitureType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FurnitureType>>> GetFurnitureTypes()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/FurnitureType/getbyid/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FurnitureType>> GetFurnitureType(int id)
        {
            var FurnitureType = await dataRepository.GetByIdAsync(id);

            if (FurnitureType == null)
            {
                return NotFound();
            }

            return FurnitureType;
        }


        // PUT: api/FurnitureType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutFurnitureType(int id, FurnitureType f)
        {
            if (id != f.Id)
            {
                return BadRequest();
            }

            var furnitureTypeUpdate = await dataRepository.GetByIdAsync(id);

            if (furnitureTypeUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(furnitureTypeUpdate.Value, f);
                return NoContent();
            }
        }

        // POST: api/FurnitureType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FurnitureType>> PostFurnitureType(FurnitureType f)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(f);

            return CreatedAtAction("GetById", new { id = f.Id }, f);
        }

        // DELETE: api/FurnitureType/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFurnitureType(int id)
        {
            var furnitureType = await dataRepository.GetByIdAsync(id);
            if (furnitureType == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(furnitureType.Value);
            return NoContent();
        }
    }
}
