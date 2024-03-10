using System.ComponentModel.DataAnnotations;

namespace LinkStorage.Models
{
    public class Roles
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Authority { get; set; }
        
        public List<UserRoles> UsersRoles { get; } = [];
        public List<User> Users { get; } = [];
    }
}
