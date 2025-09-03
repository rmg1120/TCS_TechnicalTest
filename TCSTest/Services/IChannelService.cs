using TCSTest.Dto;

namespace TCSTest.Services
{
    public interface IChannelService
    {
        Task<IReadOnlyList<ChannelDto>> GetAllAsync(CancellationToken ct = default);
        Task<ChannelDto?> GetAsync(Guid id, CancellationToken ct = default);
        Task<ChannelDto> CreateAsync(CreateChannelDto dto, CancellationToken ct = default);
        Task<ChannelDto?> UpdateAsync(Guid id, UpdateChannelDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
