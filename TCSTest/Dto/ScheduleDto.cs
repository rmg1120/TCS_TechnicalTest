namespace TCSTest.Dto
{
    public class ScheduleDto
    {
        public ScheduleDto(Guid id, Guid channelId, Guid contentId, DateTime airTime, DateTime endTime)
        {
            ScheduleId = id;
            ChannelId = channelId;
            ContentId = contentId;
            AirTime = airTime;
            EndTime = endTime;
        }

        public Guid ScheduleId { get; set; }
        public Guid ChannelId { get; set; }
        public Guid ContentId { get; set; }
        public DateTime AirTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
