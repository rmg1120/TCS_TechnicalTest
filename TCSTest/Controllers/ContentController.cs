using Microsoft.AspNetCore.Mvc;
using TCSTest.Dto;
using TCSTest.Services;

namespace TCSTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController(IContentService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentDto>>> GetAll(CancellationToken ct)
        => Ok(await service.GetAllAsync(ct));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContentDto>> Get(Guid id, CancellationToken ct)
            => (await service.GetAsync(id, ct)) is { } item ? Ok(item) : NotFound();

        [HttpPost]
        public async Task<ActionResult<ContentDto>> Create([FromBody] CreateContentDto dto, CancellationToken ct)
        {
            try
            {
                var created = await service.CreateAsync(dto, ct);
                return CreatedAtAction(nameof(Get), new { id = created.ContentId }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ContentDto>> Update(Guid id, [FromBody] UpdateContentDto dto, CancellationToken ct)
            => (await service.UpdateAsync(id, dto, ct)) is { } updated ? Ok(updated) : NotFound();

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
            => await service.DeleteAsync(id, ct) ? NoContent() : NotFound();
    }
}
