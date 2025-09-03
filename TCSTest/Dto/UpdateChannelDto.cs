using System.ComponentModel.DataAnnotations;

namespace TCSTest.Dto
{
    public class UpdateChannelDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string? Provider { get; set; }
        public string? Language { get; set; }
        public string? Region { get; set; }
    }
}
