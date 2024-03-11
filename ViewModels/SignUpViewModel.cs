using System.ComponentModel.DataAnnotations;

namespace LinkStorage.ViewModels;

public class SignUpViewModel
{
    [Required]
    public string UserName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}