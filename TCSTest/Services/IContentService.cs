using TCSTest.Dto;

namespace TCSTest.Services
{
    public interface IContentService
    {
        Task<IReadOnlyList<ContentDto>> GetAllAsync(CancellationToken ct = default);
        Task<ContentDto?> GetAsync(Guid id, CancellationToken ct = default);
        Task<ContentDto> CreateAsync(CreateContentDto dto, CancellationToken ct = default);
        Task<ContentDto?> UpdateAsync(Guid id, UpdateContentDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
