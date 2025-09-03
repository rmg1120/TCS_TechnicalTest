using TCSTest.Dto;
using TCSTest.Models;
using TCSTest.Repositories;

namespace TCSTest.Services
{
    public class ContentService(IJsonRepository<ContentItem> repo) : IContentService
    {
        public async Task<ContentDto> CreateAsync(CreateContentDto dto, CancellationToken ct = default)
        {
            var entity = new ContentItem
            {
                Title = dto.Title,
                Type = dto.Type,
                Genre = dto.Genre ?? string.Empty,
                DurationMinutes = (int)dto.DurationMinutes,
                Rating = dto.Rating ?? string.Empty,
                Year = dto.Year,
                Season = dto.Season,
                Episode = dto.Episode
            };

            var saved = await repo.AddAsync(entity, ct);
            return MapToDto(saved);
        }

        public async Task<ContentDto?> UpdateAsync(Guid id, UpdateContentDto dto, CancellationToken ct = default)
        {
            var existing = await repo.GetByIdAsync(id, ct);
            if (existing is null) return null;

            existing.Title = dto.Title;
            existing.Type = dto.Type;
            existing.Genre = dto.Genre ?? string.Empty;
            existing.DurationMinutes = (int)dto.DurationMinutes;
            existing.Rating = dto.Rating ?? string.Empty;
            existing.Year = dto.Year;
            existing.Season = dto.Season;
            existing.Episode = dto.Episode;

            var updated = await repo.UpdateAsync(id, existing, ct);
            return updated is null ? null : MapToDto(updated);
        }


        public async Task<IReadOnlyList<ContentDto>> GetAllAsync(CancellationToken ct = default)
        {
            var items = await repo.GetAllAsync(ct);
            return items.Select(MapToDto).ToList();
        }

        public async Task<ContentDto?> GetAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await repo.GetByIdAsync(id, ct);
            return entity is null ? null : MapToDto(entity);
        }

        public Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
       => repo.DeleteAsync(id, ct);

        private static ContentDto MapToDto(ContentItem entity) =>
        new(entity.ContentId, entity.Title, entity.Type, entity.Genre, entity.DurationMinutes, entity.Rating, entity.Year, entity.Season, entity.Episode);
    }
}
