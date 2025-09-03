using TCSTest.Models;

namespace TCSTest.Repositories
{
    public class ChannelRepository : JsonRepository<Channel>
    {
        public ChannelRepository(IWebHostEnvironment env)
        : base(Path.Combine(env.ContentRootPath, "Data", "channels.json"), c => c.ChannelId, (c, id) => c.ChannelId = id) { }
    }
}
