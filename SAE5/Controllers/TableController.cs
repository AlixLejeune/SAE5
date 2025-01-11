using Microsoft.AspNetCore.Mvc;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;
using SAE501_Blazor_API.Models.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAE501_Blazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly IDataRepository<Table> dataRepository;

        public TableController(IDataRepository<Table> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Table
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Table/getbyid/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
            var table = await dataRepository.GetByIdAsync(id);

            if (table == null)
            {
                return NotFound();
            }

            return table;
        }


        // PUT: api/Table/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTable(int id, Table d)
        {
            if (id != d.Id)
            {
                return BadRequest();
            }

            var tableUpdate = await dataRepository.GetByIdAsync(id);

            if (tableUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(tableUpdate.Value, d);
                return NoContent();
            }
        }

        // POST: api/Table
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Table>> PostTable(Table d)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(d);

            return CreatedAtAction("GetById", new { id = d.Id }, d);
        }

        // DELETE: api/Table/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var table = await dataRepository.GetByIdAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(table.Value);
            return NoContent();
        }
    }
}
