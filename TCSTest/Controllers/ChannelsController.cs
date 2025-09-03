using Microsoft.AspNetCore.Mvc;
using TCSTest.Dto;
using TCSTest.Services;

namespace TCSTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelsController(IChannelService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChannelDto>>> GetAll(CancellationToken ct)
       => Ok(await service.GetAllAsync(ct));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ChannelDto>> Get(Guid id, CancellationToken ct)
            => (await service.GetAsync(id, ct)) is { } channel ? Ok(channel) : NotFound();

        [HttpPost]
        public async Task<ActionResult<ChannelDto>> Create([FromBody] CreateChannelDto dto, CancellationToken ct)
        {
            try
            {
                var created = await service.CreateAsync(dto, ct);
                return CreatedAtAction(nameof(Get), new { id = created.ChannelId }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ChannelDto>> Update(Guid id, [FromBody] UpdateChannelDto dto, CancellationToken ct)
            => (await service.UpdateAsync(id, dto, ct)) is { } updated ? Ok(updated) : NotFound();

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
            => await service.DeleteAsync(id, ct) ? NoContent() : NotFound();
    }
}
