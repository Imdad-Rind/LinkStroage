using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkStorage.Models
{
    [Table("Users_Table")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public ICollection<Links> LinksCollection { get; } = new List<Links>();
        
        public List<UserRoles> UsersRoles { get; } = [];
        public List<Roles> Roles { get; } = [];
    }
}
