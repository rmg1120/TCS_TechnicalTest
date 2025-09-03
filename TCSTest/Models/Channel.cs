namespace TCSTest.Models
{
    public class Channel
    {
        public Guid ChannelId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
    }
}
