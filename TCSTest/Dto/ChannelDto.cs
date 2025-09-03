namespace TCSTest.Dto
{
    public class ChannelDto
    {
        public ChannelDto(Guid id, string name, string provider, string language, string region)
        {
            ChannelId = id;
            Name = name;
            Provider = provider;
            Language = language;
            Region = region;
        }

        public Guid ChannelId { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public string Language { get; set; }
        public string Region { get; set; }
    }
}
