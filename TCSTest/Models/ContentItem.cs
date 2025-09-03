using System.Net.Mime;

namespace TCSTest.Models
{
    public class ContentItem
    {
        public Guid ContentId { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public ContentType Type { get; set; }
        public string Genre { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public string Rating { get; set; } = string.Empty;
        public int? Year { get; set; }
        public int? Season { get; set; }
        public int? Episode { get; set; }
    }
}
