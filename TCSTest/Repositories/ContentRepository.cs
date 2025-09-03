using TCSTest.Models;

namespace TCSTest.Repositories
{
    public class ContentRepository : JsonRepository<ContentItem>
    {
        public ContentRepository(IWebHostEnvironment env)
        : base(Path.Combine(env.ContentRootPath, "Data", "content_catalog.json"), c => c.ContentId, (c, id) => c.ContentId = id) { }
    }
}
