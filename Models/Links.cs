using System.ComponentModel.DataAnnotations;

namespace LinkStorage.Models
{
    public class Links
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Url]
        public string Link { get; set; }
        [Required]
        public string Site { get; set; }
        [Required]
        public bool IsPublic { get; set; } = false;
    }
}
