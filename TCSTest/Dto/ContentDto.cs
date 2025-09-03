using TCSTest.Models;

namespace TCSTest.Dto
{
    public class ContentDto
    {
        public ContentDto(Guid id, string title, ContentType type, string genre, int durationMinutes, string rating, int? year, int? season, int? episode)
        {
            ContentId = id;
            Title = title;
            Type = type;
            Genre = genre;
            DurationMinutes = durationMinutes;
            Rating = rating;
            Year = year;
            Season = season;
            Episode = episode;
        }

        public Guid ContentId { get; set; }
        public string Title { get; set; }
        public ContentType Type { get; set; }
        public string Genre { get; set; }
        public int DurationMinutes { get; set; }
        public string Rating { get; set; }
        public int? Year { get; set; }
        public int? Season { get; set; }
        public int? Episode { get; set; }
    }
}
