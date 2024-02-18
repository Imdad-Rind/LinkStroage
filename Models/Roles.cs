using System.ComponentModel.DataAnnotations;

namespace LinkStorage.Models
{
    public class Roles
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Authority { get; set; }
    }
}
