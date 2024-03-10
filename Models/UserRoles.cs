using System.ComponentModel.DataAnnotations;

namespace LinkStorage.Models;

public class UserRoles
{
    [Key]
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    public Guid RolesId { get; set; }
    public User User { get; set; } = null;
    public Roles Roles { get; set; } = null;
}