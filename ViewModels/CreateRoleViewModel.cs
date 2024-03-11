using System.ComponentModel.DataAnnotations;

namespace LinkStorage.ViewModels;

public class CreateRoleViewModel
{
    [Required]
    public string role { get; set; }
}