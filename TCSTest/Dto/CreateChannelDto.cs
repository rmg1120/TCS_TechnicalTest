using System.ComponentModel.DataAnnotations;

namespace TCSTest.Dto
{
    public class CreateChannelDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string? Provider { get; set; }
        public string? Language { get; set; }
        public string? Region { get; set; }
    }
}
