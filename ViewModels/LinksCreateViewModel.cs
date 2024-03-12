using System.ComponentModel.DataAnnotations;

namespace LinkStorage.ViewModels;

public class LinksCreateViewModel
{
    [Required]
    [Url]
    public string Link { get; set; }
    [Required]
    public string Site { get; set; }
    [Required]
    [Display(Name = "Make It Public ?")]
    public bool IsPublic { get; set; } = false;
}