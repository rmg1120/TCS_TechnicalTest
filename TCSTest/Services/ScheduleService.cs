using TCSTest.Dto;
using TCSTest.Models;
using TCSTest.Repositories;

namespace TCSTest.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IJsonRepository<Schedule> _scheduleRepo;
        private readonly IJsonRepository<Channel> _channelRepo;
        private readonly IJsonRepository<ContentItem> _contentRepo;

        public ScheduleService(
            IJsonRepository<Schedule> scheduleRepo,
            IJsonRepository<Channel> channelRepo,
            IJsonRepository<ContentItem> contentRepo)
        {
            _scheduleRepo = scheduleRepo;
            _channelRepo = channelRepo;
            _contentRepo = contentRepo;
        }

        public async Task<IReadOnlyList<ScheduleDto>> GetAllAsync(
            Guid? channelId = null,
            DateTime? date = null,
            bool? currentlyAiring = null,
            CancellationToken ct = default)
        {
            var all = await _scheduleRepo.GetAllAsync(ct);

            var filtered = all.Where(s =>
                (!channelId.HasValue || s.ChannelId == channelId) &&
                (!date.HasValue || s.AirTime.Date == date.Value.Date) &&
                (!currentlyAiring.HasValue ||
                    (currentlyAiring.Value &&
                     s.AirTime <= DateTime.UtcNow &&
                     s.EndTime >= DateTime.UtcNow))
            );

            return filtered.Select(ToDto).ToList();
        }

        public async Task<ScheduleDto?> GetAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _scheduleRepo.GetByIdAsync(id, ct);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<ScheduleDto> CreateAsync(CreateScheduleDto dto, CancellationToken ct = default)
        {
            var channel = await _channelRepo.GetByIdAsync(dto.ChannelId, ct)
                ?? throw new ArgumentException("Channel not found");
            var content = await _contentRepo.GetByIdAsync(dto.ContentId, ct)
                ?? throw new ArgumentException("Content not found");

            var entity = new Schedule
            {
                ScheduleId = Guid.NewGuid(),
                ChannelId = channel.ChannelId,
                ContentId = content.ContentId,
                AirTime = dto.AirTime,
                EndTime = dto.EndTime
            };

            var created = await _scheduleRepo.AddAsync(entity, ct);
            return ToDto(created);
        }

        public async Task<IEnumerable<ScheduleDto>> GetByChannelAsync(Guid channelId, CancellationToken ct)
        {
            var all = await _scheduleRepo.GetAllAsync(ct);
            return all.Where(s => s.ChannelId == channelId).Select(ToDto);
        }

        public async Task<IEnumerable<ScheduleDto>> GetCurrentlyAiringAsync(CancellationToken ct)
        {
            var all = await _scheduleRepo.GetAllAsync(ct);
            var now = DateTime.UtcNow;

            return all.Where(s => s.AirTime <= now && s.EndTime >= now)
                      .Select(ToDto);
        }

        public async Task<ScheduleDto?> UpdateByChannelAndContentAsync(
            Guid channelId,
            Guid contentId,
            UpdateScheduleDto dto,
            CancellationToken ct)
        {
            var all = await _scheduleRepo.GetAllAsync(ct);
            var entity = all.FirstOrDefault(s => s.ChannelId == channelId && s.ContentId == contentId);
            if (entity is null) return null;

            entity.AirTime = dto.AirTime;
            entity.EndTime = dto.EndTime;

            var updated = await _scheduleRepo.UpdateAsync(entity.ScheduleId, entity, ct);
            return updated is null ? null : ToDto(updated);
        }

        public async Task<bool> DeleteByChannelAndContentAsync(Guid channelId, Guid contentId, CancellationToken ct)
        {
            var all = await _scheduleRepo.GetAllAsync(ct);
            var entity = all.FirstOrDefault(s => s.ChannelId == channelId && s.ContentId == contentId);
            if (entity is null) return false;

            return await _scheduleRepo.DeleteAsync(entity.ScheduleId, ct);
        }

        private static ScheduleDto ToDto(Schedule s) =>
            new(s.ScheduleId, s.ChannelId, s.ContentId, s.AirTime, s.EndTime);
    }
}
