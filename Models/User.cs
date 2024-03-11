using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LinkStorage.Models
{
    [Table("Users_Table")]
    public class User : IdentityUser
    {
        public ICollection<Links>? LinksCollection { get; } = new List<Links>();
    }
}
