using Microsoft.AspNetCore.Mvc;
using SAE501_Blazor_API.Models.EntityFramework;furniture
using SAE501_Blazor_API.Models.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAE501_Blazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly IDataRepository<Sensor> dataRepository;

        public SensorController(IDataRepository<Sensor> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Sensors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sensor>>> GetSensors()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Sensors/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Sensor>> GetSensor(int id)
        {
            var Sensor = await dataRepository.GetByIdAsync(id);

            if (Sensor == null)
            {
                return NotFound();
            }

            return Sensor;
        }


        // PUT: api/Sensors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutSensor(int id, Sensor s)
        {
            if (id != s.Id)
            {
                return BadRequest();
            }

            var sensorUpdate = await dataRepository.GetByIdAsync(id);

            if (sensorUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(sensorUpdate.Value, s);
                return NoContent();
            }
        }

        // POST: api/Sensor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Sensor>> PostEtudiant(Sensor s)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(s);

            return CreatedAtAction("GetById", new { id = s.Id }, s);
        }

        // DELETE: api/Sensor/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSensor(int id)
        {
            var sensor = await dataRepository.GetByIdAsync(id);
            if (sensor == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(sensor.Value);
            return NoContent();
        }
    }
}
