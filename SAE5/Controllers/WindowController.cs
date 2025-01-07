using Microsoft.AspNetCore.Mvc;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;
using SAE501_Blazor_API.Models.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAE501_Blazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        private readonly IDataRepository<Window> dataRepository;

        public WindowController(IDataRepository<Window> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Window
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Window>>> GetWindows()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Window/getbyid/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Window>> GetWindow(int id)
        {
            var window = await dataRepository.GetByIdAsync(id);

            if (window == null)
            {
                return NotFound();
            }

            return window;
        }


        // PUT: api/Window/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutWindow(int id, Window d)
        {
            if (id != d.Id)
            {
                return BadRequest();
            }

            var windowUpdate = await dataRepository.GetByIdAsync(id);

            if (windowUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(windowUpdate.Value, d);
                return NoContent();
            }
        }

        // POST: api/Window
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Window>> PostWindow(Window d)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(d);

            return CreatedAtAction("GetById", new { id = d.Id }, d);
        }

        // DELETE: api/Window/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWindow(int id)
        {
            var window = await dataRepository.GetByIdAsync(id);
            if (window == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(window.Value);
            return NoContent();
        }
    }
}
