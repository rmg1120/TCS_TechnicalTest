using TCSTest.Models;

namespace TCSTest.Repositories
{
    public class ScheduleRepository : JsonRepository<Schedule>
    {
        public ScheduleRepository(IWebHostEnvironment env)
       : base(Path.Combine(env.ContentRootPath, "Data", "channel_schedule.json"), s => s.ScheduleId, (s, id) => s.ScheduleId = id) { }
    }
}
