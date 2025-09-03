using TCSTest.Dto;

namespace TCSTest.Services
{
    public interface IScheduleService
    {
        Task<IReadOnlyList<ScheduleDto>> GetAllAsync(
        Guid? channelId = null,
        DateTime? date = null,
        bool? currentlyAiring = null,
        CancellationToken ct = default);

        Task<ScheduleDto?> GetAsync(Guid id, CancellationToken ct = default);

        Task<ScheduleDto> CreateAsync(CreateScheduleDto dto, CancellationToken ct = default);

        Task<IEnumerable<ScheduleDto>> GetByChannelAsync(Guid channelId, CancellationToken ct = default);

        Task<IEnumerable<ScheduleDto>> GetCurrentlyAiringAsync(CancellationToken ct = default);

        Task<ScheduleDto?> UpdateByChannelAndContentAsync(
            Guid channelId,
            Guid contentId,
            UpdateScheduleDto dto,
            CancellationToken ct = default);

        Task<bool> DeleteByChannelAndContentAsync(
            Guid channelId,
            Guid contentId,
            CancellationToken ct = default);
    }
}
