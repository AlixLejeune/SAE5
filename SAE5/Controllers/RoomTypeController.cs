using Microsoft.AspNetCore.Mvc;
using SAE501_Blazor_API.Models.DTO;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAE501_Blazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeRepository dataRepository;

        public RoomTypeController(IRoomTypeRepository dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/RoomType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomType>>> GetRoomTypes()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/RoomType/DTO
        [HttpGet("DTO")]
        public async Task<ActionResult<IEnumerable<RoomTypeDTO>>> GetRoomTypeDTOs()
        {
            return await dataRepository.GetAllDTOAsync();
        }

        // GET: api/RoomType/getbyid/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RoomType>> GetRoomType(int id)
        {
            var RoomType = await dataRepository.GetByIdAsync(id);

            if (RoomType?.Value is null)
            {
                return NotFound();
            }

            return RoomType;
        }


        // PUT: api/RoomType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutRoomType(int id, RoomType r)
        {
            if (id != r.Id)
            {
                return BadRequest();
            }

            var roomTypeUpdate = await dataRepository.GetByIdAsync(id);

            if (roomTypeUpdate?.Value is null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(roomTypeUpdate.Value, r);
                return NoContent();
            }
        }

        // PUT: api/RoomType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("DTO/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutDTORoomType(int id, RoomTypeDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var roomTypeUpdate = await dataRepository.GetByIdAsync(id);

            if (roomTypeUpdate?.Value is null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateFromDTOAsync(roomTypeUpdate.Value, dto);
                return NoContent();
            }
        }

        // POST: api/RoomType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RoomType>> PostRoomType(RoomType r)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(r);

            return CreatedAtAction("GetById", new { id = r.Id }, r);
        }

        // POST: api/RoomType/DTO
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("DTO")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RoomType>> PostDTORoomType(RoomTypeDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomType = await dataRepository.AddFromDTOAsync(dto);

            return CreatedAtAction("GetById", new { id = dto.Id }, roomType);
        }

        // DELETE: api/RoomType/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            var roomType = await dataRepository.GetByIdAsync(id);
            if (roomType?.Value is null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(roomType.Value);
            return NoContent();
        }
    }
}
