using TCSTest.Dto;
using TCSTest.Models;
using TCSTest.Repositories;

namespace TCSTest.Services
{
    public class ChannelService(IJsonRepository<Channel> repo) : IChannelService
    {
        public async Task<ChannelDto> CreateAsync(CreateChannelDto dto, CancellationToken ct = default)
        {
            var entity = new Channel
            {
                Name = dto.Name,
                Provider = dto.Provider ?? string.Empty,
                Language = dto.Language ?? string.Empty,
                Region = dto.Region ?? string.Empty
            };

            var saved = await repo.AddAsync(entity, ct);
            return MapToDto(saved);
        }

        public Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
        => repo.DeleteAsync(id, ct);

        public async Task<IReadOnlyList<ChannelDto>> GetAllAsync(CancellationToken ct = default)
        {
            var items = await repo.GetAllAsync(ct);
            return items.Select(MapToDto).ToList();
        }

        public async Task<ChannelDto?> GetAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await repo.GetByIdAsync(id, ct);
            return entity is null ? null : MapToDto(entity);
        }

        public async Task<ChannelDto?> UpdateAsync(Guid id, UpdateChannelDto dto, CancellationToken ct = default)
        {
            var existing = await repo.GetByIdAsync(id, ct);
            if (existing is null) return null;

            existing.Name = dto.Name;
            existing.Provider = dto.Provider ?? string.Empty;
            existing.Language = dto.Language ?? string.Empty;
            existing.Region = dto.Region ?? string.Empty;

            var updated = await repo.UpdateAsync(id, existing, ct);
            return updated is null ? null : MapToDto(updated);
        }

        private static ChannelDto MapToDto(Channel entity) =>
        new(entity.ChannelId, entity.Name, entity.Provider, entity.Language, entity.Region);
    }
}
