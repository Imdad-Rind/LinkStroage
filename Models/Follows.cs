namespace LinkStorage.Models;
using System.ComponentModel.DataAnnotations;

public class Follows
{
    [Key] public string id { get; set; } = Guid.NewGuid().ToString(); 
    public string Follower_Id { get; set; } = Guid.NewGuid().ToString();
    public virtual User Followers { get; set; }
    public string Following_Id { get; set; }  = Guid.NewGuid().ToString();
    public virtual User Following { get; set; }
}