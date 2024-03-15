using LinkStorage.Models;
using LinkStorage.Services;
using LinkStorage.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinkStorage.Controllers;

public class UsersController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly ILinkService _linkService;

    public UsersController(UserManager<User> userManager, ILinkService linkService)
    {
        _userManager = userManager;
        _linkService = linkService;
    }

    [HttpGet]
    public async Task<ActionResult> Profile(Guid? id, ProfileViewModel model)
    {
        var u = await _userManager.FindByIdAsync(id.ToString());
        var lnk = await _linkService.GetAllPublicLinksById(id);
        model.User = u;
        model.links = lnk;
        
        return View(model);
    }
}