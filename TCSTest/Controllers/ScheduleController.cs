using Microsoft.AspNetCore.Mvc;
using TCSTest.Dto;
using TCSTest.Services;

namespace TCSTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _service;

        public ScheduleController(IScheduleService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleDto>>> GetAll(
            [FromQuery] Guid? channelId,
            [FromQuery] DateTime? date,
            [FromQuery] bool? currentlyAiring,
            CancellationToken ct)
        {
            var result = await _service.GetAllAsync(channelId, date, currentlyAiring, ct);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ScheduleDto>> Get(Guid id, CancellationToken ct)
        {
            var schedule = await _service.GetAsync(id, ct);
            return schedule is null ? NotFound() : Ok(schedule);
        }

        [HttpPost]
        public async Task<ActionResult<ScheduleDto>> Create(CreateScheduleDto dto, CancellationToken ct)
        {
            try
            {
                var created = await _service.CreateAsync(dto, ct);
                return CreatedAtAction(nameof(Get), new { id = created.ScheduleId }, created);
            }
            catch (Exception ex)
            {

                return BadRequest(new { error = ex.Message });
            }

        }

        [HttpGet("channel/{channelId:guid}")]
        public async Task<ActionResult<IEnumerable<ScheduleDto>>> GetByChannel(Guid channelId, CancellationToken ct)
        {
            var result = await _service.GetByChannelAsync(channelId, ct);
            return Ok(result);
        }

        [HttpGet("now")]
        public async Task<ActionResult<IEnumerable<ScheduleDto>>> GetCurrentlyAiring(CancellationToken ct)
        {
            var result = await _service.GetCurrentlyAiringAsync(ct);
            return Ok(result);
        }

        [HttpPut("{channelId:guid}/{contentId:guid}")]
        public async Task<ActionResult<ScheduleDto>> Update(Guid channelId, Guid contentId, UpdateScheduleDto dto, CancellationToken ct)
        {
            try
            {
                var updated = await _service.UpdateByChannelAndContentAsync(channelId, contentId, dto, ct);
                return updated is null ? NotFound() : Ok(updated);
            }
            catch (Exception ex)
            {

                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{channelId:guid}/{contentId:guid}")]
        public async Task<IActionResult> Delete(Guid channelId, Guid contentId, CancellationToken ct)
        {
            var deleted = await _service.DeleteByChannelAndContentAsync(channelId, contentId, ct);
            return deleted ? NoContent() : NotFound();
        }
    }
}
