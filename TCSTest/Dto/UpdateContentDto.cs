using System.ComponentModel.DataAnnotations;
using TCSTest.Models;

namespace TCSTest.Dto
{
    public class UpdateContentDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public ContentType Type { get; set; }
        public string? Genre { get; set; }

        [Range(1, int.MaxValue)]
        public int? DurationMinutes { get; set; }
        public string? Rating { get; set; }
        public int? Year { get; set; }
        public int? Season { get; set; }
        public int? Episode { get; set; }
    }
}
