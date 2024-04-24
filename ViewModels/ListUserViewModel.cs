using System.ComponentModel.DataAnnotations;

namespace LinkStorage.ViewModels;

public class ListUserViewModel
{
    [Display(Name = "UserName")]
    public string UserName { get; set; }
    public string Email { get; set; }
    public long Followers { get; set; }
    public long Followings { get; set; }
    [Display(Name = "Public Posts")]
    public long PublicPost { get; set; }

    [Display(Name = "Roles")] public string Roles { get; set; } = null;
}