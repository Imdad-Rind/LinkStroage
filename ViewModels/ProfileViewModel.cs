using LinkStorage.Models;

namespace LinkStorage.ViewModels;

public class ProfileViewModel
{
    public IEnumerable<Links> links { get; set; }
    public User User { get; set; }
}