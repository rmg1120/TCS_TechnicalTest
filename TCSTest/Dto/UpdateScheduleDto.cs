using System.ComponentModel.DataAnnotations;

namespace TCSTest.Dto
{
    public class UpdateScheduleDto
    {
        public DateTime AirTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
    }
}
