using System.ComponentModel.DataAnnotations;

namespace TCSTest.Dto
{
    public class CreateScheduleDto
    {
        [Required]
        public Guid ChannelId { get; set; }
        [Required]
        public Guid ContentId { get; set; }
        [Required]
        public DateTime AirTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
    }
}
