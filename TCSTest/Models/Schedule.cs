namespace TCSTest.Models
{
    public class Schedule
    {
        public Guid ScheduleId { get; set; } = Guid.NewGuid();
        public Guid ChannelId { get; set; }
        public Guid ContentId { get; set; }
        public DateTime AirTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
